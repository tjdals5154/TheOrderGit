using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class M_Game : MonoBehaviour
{
    private static M_Game _instance;

    public static M_Game Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<M_Game>();
                if (null == _instance)
                {

                }
            }
            return _instance;
        }
    }
    public GameObject _MenuBG;
    bool _time;
    public GameObject _FBell;
    public GameObject _Bell;
    public GameObject _Shutter;
    public Memory _ordershow;
    public bool _openbell = false;
    public bool _pause;
    public Image _class;
    public GameObject _Cover;
    Vector2 _openShutter = new Vector2(540, 3300);
    Vector2 _closedShutter = new Vector2(540, 1425);
    public GameObject _OpenBoard;
    public GameObject _ClosedBoard;
    bool _off;
    [SerializeField]
    Slider _slider1 = null;
    [SerializeField]
    Slider _slider2 = null;
    [SerializeField]
    public Toggle _to;

    void Awake()
    {
        GameObject musicMgrObj = GameObject.Find("MusicManager");
        if (musicMgrObj == null)
        {
            GameObject musicMgrObjPrefab = Resources.Load("MusicManager") as GameObject;
            GameObject newMusicMgrObj = Instantiate(musicMgrObjPrefab);
            newMusicMgrObj.name = "MusicManager";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _off = true;
        _FBell.SetActive(false);
        _Cover.SetActive(true);
        _to.isOn = true;
        if (PlayerPrefs.HasKey("SliderA"))
            _slider1.value = PlayerPrefs.GetFloat("SliderA");

        if (PlayerPrefs.HasKey("SliderB"))
            _slider2.value = PlayerPrefs.GetFloat("SliderB");

        bool IsOn = false;
        if (PlayerPrefs.HasKey("IsOn"))
        {
            if (PlayerPrefs.GetInt("IsOn") == 1)
            {
                IsOn = true;
            }
            else
            {
                IsOn = false;
            }
            _to.isOn = IsOn;
        }

        _OpenBoard.SetActive(true);
        _ClosedBoard.SetActive(false);

        _pause = true;
        _class.fillAmount = 0.5f;
        _ordershow.enabled = false;
        _MenuBG.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SoundManager.Ins._Timer = GameObject.FindWithTag("Timer");
        SoundManager.Ins.TimerSource = SoundManager.Ins._Timer.GetComponent<AudioSource>();

        Shutter();
        if (Input.GetKey(KeyCode.D))
        {
            PlayerPrefs.DeleteKey("Money");
        }

        if (_class.fillAmount > 0.88f)
        {
            if (_time == false)
            {
                SoundManager.Ins.TimerSource.Play();
                _time = true;
            }

        }
        if (_class.fillAmount < 0.88f)
        {
            if (_time == true)
            {
                SoundManager.Ins.TimerSource.Stop();
                _time = false;
            }
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    void Shutter()
    {
        if (_pause == false)
        {
            if (_class.fillAmount < 1)
            {
                if (_off == true)
                {
                    vibOn();
                    SoundManager.Ins.PlaySound(SoundManager.FxTypes.ShutterSound);

                    _off = false;
                }
                _Shutter.transform.position = Vector2.MoveTowards(_Shutter.transform.position, _openShutter, 4200 * Time.deltaTime);
            }
            else if (_class.fillAmount >= 1)
            {
                if (_off == false)
                {
                    SoundManager.Ins.TimerSource.Stop();
                    vibOn();
                    SoundManager.Ins.PlaySound(SoundManager.FxTypes.ShutterSound);
                    _off = true;
                }
                _Shutter.transform.position = Vector2.MoveTowards(_Shutter.transform.position, _closedShutter, 4200 * Time.deltaTime);

                _OpenBoard.SetActive(false);
                _ClosedBoard.SetActive(true);
                _Cover.SetActive(true);
                _Bell.SetActive(true);
                _FBell.SetActive(false);

                Invoke("GameOver", 1.7f);
            }
        }
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("Combo",  Memory.Ins._Combo);
        PlayerPrefs.SetInt("Money", Memory.Ins._Money);

        PlayerPrefs.SetInt("Memory1", Memory.Ins._Memory);
        if (Memory.Ins._Memory >= Memory.Ins._BESTMemory)
        {
            Memory.Ins._BESTMemory = Memory.Ins._Memory;
            PlayerPrefs.SetInt("Memory", Memory.Ins._BESTMemory);
        }

        Memory.Ins._ORDERNUM.text = "" + Memory.Ins._ordernum.ToString();
        Memory.Ins._BESTMEMORYNUM.text = "" + Memory.Ins._BESTMemory.ToString();
        Memory.Ins._Reward.text = "" + string.Format("{0:#,###0}", Memory.Ins._Money.ToString());
        Memory.Ins._ComboText.text = "" + Memory.Ins._Combo.ToString();

        SceneManager.LoadScene("LobbyScene");
    }

    public void OnOpen()
    {
        _pause = false;
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.BellSound);
        _Bell.SetActive(false);
        _FBell.SetActive(true);
        _openbell = true;
        _ordershow.enabled = true;
        _Cover.SetActive(false);

    }

    public void OnMenu()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        _pause = true;
        Time.timeScale = 0;
        _MenuBG.SetActive(true);
    }

    public void OnBack()
    {
        _SaveOption();
        _MenuBG.SetActive(false);
    }

    public void OnHome()
    {
        _SaveOption();
        PlayerPrefs.SetInt("Money", Memory.Ins._Money);
        Invoke("Scene", 0.35f);
    }
    void Scene()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    void _SaveOption()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        _pause = false;
        Time.timeScale = 1;

        PlayerPrefs.SetFloat("SliderA", _slider1.value);
        PlayerPrefs.SetFloat("SliderB", _slider2.value);

        if (_to.isOn)
        {
            PlayerPrefs.SetInt("IsOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("IsOn", 0);
        }
    }

    public void SetSoundVolume(float volume1)
    {
        SoundManager.Ins.fxSource.volume = volume1;
        SoundManager.Ins.TimerSource.volume = volume1;
    }
    public void SetMusicVolume(float volume2)
    {
        MusicManager.Ins.bgSource.volume = volume2;
    }


    public void vibOn()
    {
        if (_to.isOn)
        {
            MyHandheld.Vibrate();
        }
    }
}

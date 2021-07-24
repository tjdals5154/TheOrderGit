using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

public class Lobby : NetworkBehaviour
{
    private static Lobby _instance;

    public static Lobby Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Lobby>();
                if (null == _instance)
                {

                }
            }
            return _instance;
        }
    }

    public GameObject _MenuBG;
    public GameObject _CouponBG;
    public GameObject _ShopBG;
    public GameObject _ChallengeBG;
    public GameObject _SignBG;
    public GameObject _PVPBG;

    public Text _PVPname;
    public Text _PVPname2;

    public GameObject _Win;
    public GameObject _Lose;
    public GameObject _RoomName;

    public GameObject _1;
    public GameObject _2;

    public GameObject _ok;
    public GameObject _okBtn;

    public InputField _name;
    string _Ca;
    public Text _LobbyName;

    int _BESTordernum;
    public Text _orderBest;
    public Text _order;
    int _clearnum;
    int _Money;
    public Text _MoneyT;
    public int _Combo;
    public Text _ComboText;
    public GameObject _ComboObj;

    int _MemoryInt;
    public Text _MemoryText;
    
    int _PVPInt;
    public Text _PVPText;
    int _TrainInt;
    public Text _TrainText;
    float _SpeedInt;
    public Text _SpeedText;
    int _BMemoryInt;
    public Text _BMemoryText;
    int _BTrainInt;
    public Text _BTrainText;
    float _BSpeedInt;
    public Text _BSpeedText;

    [SerializeField]
    Slider _slider1 = null;
    [SerializeField]
    Slider _slider2 = null;
    [SerializeField]
    public Toggle _to;

    void Awake()
    {
        Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);

        if (PlayerPrefs.HasKey("Sign"))
        {
            _LobbyName.text = PlayerPrefs.GetString("Sign");
            _LobbyName.text = _LobbyName.text.ToString();

            _SignBG.SetActive(false);

            GameObject musicMgrObj = GameObject.Find("MusicManager");
            if (musicMgrObj == null)
            {
                GameObject musicMgrObjPrefab = Resources.Load("MusicManager") as GameObject;
                GameObject newMusicMgrObj = Instantiate(musicMgrObjPrefab);
                newMusicMgrObj.name = "MusicManager";
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        _Combo = PlayerPrefs.GetInt("Combo", 0);
        _ComboText.text = "combo : " + (int)_Combo;
        
        _BESTordernum = PlayerPrefs.GetInt("TopScore", 0);
        _orderBest.text = "" + (int)_BESTordernum;
        _clearnum = PlayerPrefs.GetInt("TopScore1", 0);
        _order.text = "" + (int)_clearnum;

        _MemoryInt = PlayerPrefs.GetInt("Memory", 0);
        _MemoryText.text = "" + (int)_MemoryInt;
        _PVPInt = PlayerPrefs.GetInt("PVP", 0);
        _PVPText.text = "" + (int)_PVPInt;
        _TrainInt = PlayerPrefs.GetInt("Train", 0);
        _TrainText.text = "" + (int)_TrainInt;
        _SpeedInt = PlayerPrefs.GetFloat("Speed", 0);
        _SpeedText.text = "" + (float)_SpeedInt;

        _BMemoryInt = PlayerPrefs.GetInt("Memory1", 0);
        _BMemoryText.text = "" + (int)_BMemoryInt;
        _BTrainInt = PlayerPrefs.GetInt("Train1", 0);
        _BTrainText.text = "" + (int)_BTrainInt;
        _BSpeedInt = PlayerPrefs.GetFloat("Speed1", 0);
        _BSpeedText.text = "" + (float)_BSpeedInt;

        

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

        if (_Combo == 0)
        {
            _ComboObj.SetActive(false);
        }
        else if (_Combo > 0)
        {
            _ComboObj.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            PlayerPrefs.DeleteKey("Money");
        }

        _Money = PlayerPrefs.GetInt("Money", 0);
        _MoneyT.text = "" + string.Format("{0:#,###0}", _Money);

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    void Scene()
    {
        SceneManager.LoadScene("GameScene");
    }

    void Memory()
    {
        SceneManager.LoadScene("Memory");
    }
    public void OnGameStart()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        Invoke("Scene", 0.35f);
        
    }
    public void On1()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        _1.SetActive(true);
        _2.SetActive(false);
        _ok.SetActive(true);
        _okBtn.SetActive(true);
        _Win.SetActive(true);
        _Lose.SetActive(true);
        _RoomName.SetActive(false);
    }
    public void On2()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        _2.SetActive(true);
        _1.SetActive(false);
        _ok.SetActive(true);
        _okBtn.SetActive(true);
        _Win.SetActive(false);
        _Lose.SetActive(false);
        _RoomName.SetActive(true);
    }
    public void OnMemoryStart()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        Invoke("Memory", 0.35f);

    }
    public void OnTrainStart()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        Invoke("Train", 0.35f);

    }
    void Train()
    {
        SceneManager.LoadScene("Train");
    }
    public void OnSpeedStart()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        Invoke("Speed", 0.35f);

    }
    void Speed()
    {
        SceneManager.LoadScene("Speed");
    }
    public void OnLobbyMenu()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        _MenuBG.SetActive(true);
    }
    public void OnLobbyBack()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        _MenuBG.SetActive(false);

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
    public void OnPVP()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        Invoke("OnPvP", 0.35f);
        //_PVPname.text = PlayerPrefs.GetString("Sign");
        //_PVPname.text = _PVPname.text.ToString();
        //_PVPBG.SetActive(true);
        //_ChallengeBG.SetActive(false);
    }
    void OnPvP()
    {
        SceneManager.LoadScene("PVPRoom");
    }
    public void OnOK()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        Invoke("OK", 0.35f);
    }
    void OK()
    {
        SceneManager.LoadScene("PVPScene");
    }
    public void OnC()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        _PVPBG.SetActive(false);
        _1.SetActive(false);
        _2.SetActive(false);
        _ok.SetActive(false);
        _okBtn.SetActive(false);
        _Win.SetActive(true);
        _Lose.SetActive(true);
        _RoomName.SetActive(false);
    }

    public void OnShop()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        _ShopBG.SetActive(true);

        Shop.Ins._Green.SetActive(false);
        Shop.Ins. _ScrollPos = 0;
        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[0];
        MusicManager.Ins.bgSource.Play();
        MusicManager.Ins._BGMint = 0;
        PlayerPrefs.SetInt("BGM", MusicManager.Ins._BGMint);
    }
    public void OnChallenge()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        _ChallengeBG.SetActive(true);
    }
    public void OnChallengeBack()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        _ChallengeBG.SetActive(false);
    }

    public void OnSign()
    {
        GameObject musicMgrObj = GameObject.Find("MusicManager");
        if (musicMgrObj == null)
        {
            GameObject musicMgrObjPrefab = Resources.Load("MusicManager") as GameObject;
            GameObject newMusicMgrObj = Instantiate(musicMgrObjPrefab);
            newMusicMgrObj.name = "MusicManager";
        }

        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        _SignBG.SetActive(false);
        _Ca = _name.text;
        _LobbyName.text = _Ca.ToString();
        PlayerPrefs.SetString("Sign", _LobbyName.text);

        _PVPname.text = _Ca.ToString();
        PlayerPrefs.SetString("Sign", _PVPname.text);

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

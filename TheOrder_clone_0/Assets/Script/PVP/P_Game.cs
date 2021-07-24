using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class P_Game : NetworkBehaviour
{
    private static P_Game _instance;

    public static P_Game Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<P_Game>();
                if (null == _instance)
                {

                }
            }
            return _instance;
        }
    }
    

    public Text _WinText;
    public Text _WinText2;

    public GameObject _MenuBG;
    bool _time;
    public GameObject _FBell;
    public GameObject _Bell;
    public GameObject _Shutter;
    public PVP _ordershow;
    public bool _openbell = false;
    public bool _pause;

    public Image _class;
    public GameObject _Cover;
    Vector2 _openShutter = new Vector2(540, 3300);
    Vector2 _closedShutter = new Vector2(540, 1425);
    public GameObject _OpenBoard;
    public GameObject _ClosedBoard;
    bool _off;
    bool _321;
    public float _Count;
    public Text _CountText;

    public Text _MATCHNAME;
    public Text _RENAME;

    public Text _MATCHNAME2;
    public Text _RENAME2;

    public bool _Matching;

    public GameObject _Bellcover;
    public GameObject _321B;
    public GameObject _Restart;
    public GameObject _MATCHBG;
    public GameObject _REBG;

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
        //_MATCHNAME.text = HamburgerPlayer.Ins.playerName;
        //_MATCHNAME.text = _MATCHNAME.text.ToString();

        _RENAME.text = PlayerPrefs.GetString("Sign");
        _RENAME.text = _RENAME.text.ToString();

        _Count = 3;
        _Matching = false;
        _off = true;
        _321 = true;
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

        //NetworkRoomManager netRoomMgr = FindObjectOfType<NetworkRoomManager>();
        //if (netRoomMgr && NetworkClient.active)
        //{
        //    foreach (NetworkRoomPlayer p in netRoomMgr.roomSlots)
        //    {
        //        if (p.hasAuthority)
        //        {
        //            p.readyToBegin = true;
        //        }
        //        else
        //        {
        //            p.readyToBegin = true;
        //        }
        //    }
        //}
        //NetworkRoomPlayer.Ins.readyToBegin = true;
        _Matching = true;


        
    }


    // Update is called once per frame
    void Update()
    {
        
        //if (NetworkRoomPlayer.Ins.readyToBegin == true)
        //{
        //    _Matching = true;
        //}

        if (_Matching == true)
        {
            _Count -= Time.deltaTime ;
            _CountText.text = Mathf.Round(_Count).ToString();

            if (_Count <= 0)
            {
                _Count = 0;
                _pause = false;
                
                _Bell.SetActive(false);
                _FBell.SetActive(true);
                _openbell = true;
                _ordershow.enabled = true;
                _Cover.SetActive(false);

                GameObject bell = GameObject.Find("Canvas/Hamburger");
                bell.transform.SetSiblingIndex(2);

                GameObject bell2 = GameObject.Find("Canvas/Hamburger2");
                bell2.transform.SetSiblingIndex(3);

                if (_321 == true)
                {
                    SoundManager.Ins.PlaySound(SoundManager.FxTypes.BellSound);
                    _321 = false;
                }
            }

        }
        
        SoundManager.Ins._Timer = GameObject.FindWithTag("Timer");
        SoundManager.Ins.TimerSource = SoundManager.Ins._Timer.GetComponent<AudioSource>();

        Shutter();
        if (Input.GetKey(KeyCode.D))
        {
            PlayerPrefs.DeleteKey("Money");
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        //if (_class.fillAmount > 0.88f)
        //{
        //    if (_time == false)
        //    {
        //        SoundManager.Ins.TimerSource.Play();
        //        _time = true;
        //    }

        //}
        //if (_class.fillAmount < 0.88f)
        //{
        //    if (_time == true)
        //    {
        //        SoundManager.Ins.TimerSource.Stop();
        //        _time = false;
        //    }

        //}

    }

    

    public void WL()
    {
        HamburgerPlayer[] playerlist = FindObjectsOfType<HamburgerPlayer>();
        foreach (HamburgerPlayer p in playerlist)
        {
            NetworkIdentity n = p.netIdentity;

            if (NetworkClient.active && n.isLocalPlayer)
            {
                _WinText.text = "" + (int)p._Win;
            }
            else
            {
                _WinText2.text = "" + (int)p._Win;
            }
        }
    }

    public void ShName()
    {
        HamburgerPlayer[] playerlist = FindObjectsOfType<HamburgerPlayer>();
        foreach (HamburgerPlayer p in playerlist)
        {
            NetworkIdentity n = p.netIdentity;

            if (NetworkClient.active && n.isLocalPlayer)
            {
                _RENAME.text = p.playerName;
            }
            else
            {
                _RENAME2.text = p.playerName;
            }
        }
    }

    public void ShowPlayerName()
    {
        HamburgerPlayer[] playerlist = FindObjectsOfType<HamburgerPlayer>();
        foreach (HamburgerPlayer p in playerlist)
        {
            NetworkIdentity n = p.netIdentity;
            if (NetworkClient.active && n.isLocalPlayer)
            {
                _MATCHNAME.text = p.playerName;
            }
            else
            {
                _MATCHNAME2.text = p.playerName;
            }
        }
    }

    public void Over()
    {
        HamburgerPlayer[] playerlist = FindObjectsOfType<HamburgerPlayer>();
        foreach (HamburgerPlayer p in playerlist)
        {
            NetworkIdentity n = p.netIdentity;

            if (NetworkClient.active && n.isLocalPlayer)
            {
                p.Over();
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
                _321B.SetActive(false);
                _Restart.SetActive(true);
                _MATCHBG.SetActive(false);
                _REBG.SetActive(true);
                _OpenBoard.SetActive(false);
                _ClosedBoard.SetActive(true);
                _Cover.SetActive(true);
                _Bell.SetActive(true);
                _FBell.SetActive(false);
                _Bellcover.SetActive(false);
                Invoke("GameOver", 1.7f);
            }
        }
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("Money", PVP.Ins._Money);

        PlayerPrefs.SetInt("PVP1", PVP.Ins._PVP);
        if (PVP.Ins._PVP >= PVP.Ins._BESTPVP)
        {
            PVP.Ins._BESTPVP = PVP.Ins._PVP;
            PlayerPrefs.SetInt("PVP", PVP.Ins._BESTPVP);
        }

        PVP.Ins._ORDERNUM.text = "" + PVP.Ins._ordernum.ToString();
        PVP.Ins._BESTPVPNUM.text = "" + PVP.Ins._BESTPVP.ToString();
        PVP.Ins._Reward.text = "" + string.Format("{0:#,###0}", PVP.Ins._Money.ToString());
        Time.timeScale = 0;
        //SceneManager.LoadScene("PVPScene");
    }

    public void OnRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("PVPScene");
    }

    public void OnMenu()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        _pause = true;
        Time.timeScale = 0;
        _MenuBG.SetActive(true);

    }
    public void OnMatch()
    {
        //_Matching = true;
    }

    public void OnBack()
    {
        _SaveOption();
        _MenuBG.SetActive(false);
    }

    public void OnHome()
    {
        _SaveOption();
        PlayerPrefs.SetInt("Money", PVP.Ins._Money);
        Invoke("Scene", 0.35f);
    }
    public void OnPVPHome()
    {
        Time.timeScale = 1;
        NetworkIdentity netId = GetComponent<NetworkIdentity>();

        
        if (netId.isLocalPlayer)
        {
            NetworkManager.Ins.StopHost();
        }
        else
        {
            NetworkManager.Ins.StopClient();
        }


        //SceneManager.LoadScene("LobbyScene");
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

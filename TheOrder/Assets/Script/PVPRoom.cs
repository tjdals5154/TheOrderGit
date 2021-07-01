using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class PVPRoom : NetworkBehaviour
{
    private static PVPRoom _instance;

    public static PVPRoom Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PVPRoom>();
                if (null == _instance)
                {

                }
            }
            return _instance;
        }
    }
    public Text _PVPname;
    bool _Click;
    public int _PVPInt;
    public Text _PVPText;

    int _WinInt;
    public Text _WinText;

    public int _LoseInt;
    public Text _LoseText;

    public GameObject _Win;
    public GameObject _Lose;
    public GameObject _WinTest;
    public GameObject _LoseTest;
    public GameObject _RoomName;

    public GameObject _1;
    public GameObject _2;

    public GameObject _ok;
    public GameObject _okBtn;

    public GameObject _cBtn;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
        _PVPInt = PlayerPrefs.GetInt("PVP", 0);
        _PVPText.text = "" + (int)_PVPInt;

        _PVPname.text = PlayerPrefs.GetString("Sign");
        _PVPname.text = _PVPname.text.ToString();
        _cBtn.SetActive(false);

        if (PlayerPrefs.HasKey("Win"))
        {
            _WinInt = PlayerPrefs.GetInt("Win", 0);
            _WinText.text = "" + (int)_WinInt;
        }

        if (PlayerPrefs.HasKey("Lose"))
        {
            _LoseInt = PlayerPrefs.GetInt("Lose", 0);
            _LoseText.text = "" + (int)_LoseInt;
        }

        //NetworkRoomManager netRoomMgr = FindObjectOfType<NetworkRoomManager>();

        //if (netRoomMgr)
        //{
        //    foreach (NetworkRoomPlayer p in netRoomMgr.roomSlots)
        //    {
        //        if (p.isLocalPlayer)
        //        {
        //            p.CmdChangeReadyState(true);
        //        }
        //    }
        //}


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnOK()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        Invoke("OK", 0.35f);
    }
    void OK()
    {
        NetworkManager.Ins.StartClient();
        _cBtn.SetActive(true);
        _Click = true;
    }
    public void OnC()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        _1.SetActive(false);
        _2.SetActive(false);
        _ok.SetActive(false);
        _okBtn.SetActive(false);
        _Win.SetActive(true);
        _Lose.SetActive(true);
        _WinTest.SetActive(true);
        _LoseTest.SetActive(true);
        _RoomName.SetActive(false);
        Invoke("C", 0.35f);
    }
    void C()
    {
        if (_Click == true)
        {
            NetworkManager.Ins.StopHost();
            _Click = false;
            _cBtn.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("LobbyScene");
            _cBtn.SetActive(false);
        }

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
        _WinTest.SetActive(true);
        _LoseTest.SetActive(true);
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
        _WinTest.SetActive(false);
        _LoseTest.SetActive(false);
        _RoomName.SetActive(true);
    }
}

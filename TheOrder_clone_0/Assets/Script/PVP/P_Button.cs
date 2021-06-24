using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


public class P_Button : NetworkBehaviour
{
    private static P_Button _instance;

    public static P_Button Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<P_Button>();
                if (null == _instance)
                {

                }
            }
            return _instance;
        }
    }

    GameObject _Ins;
    public GameObject _bun;
    public GameObject _middlebun;
    public GameObject _tomato;
    public GameObject _cheese;
    public GameObject _lettuce;
    public GameObject _meat;


    public Image _BunUp;
    public Image _BunDown;
    public Sprite _BUp;
    public Sprite _BDown;

    public Vector2 _posion1;
    public Vector2 _posion2;
    public Vector2 _posion3;
    public Vector2 _posion4;
    public Vector2 _posion5;
    public Vector2 _posion6;

    public Text[] _numText;

    public List<int> _topping = new List<int>();
    //private NetworkIdentity _Playernetid;
    // Start is called before the first frame update
    void Start()
    {
        _BunDown.sprite = _BDown;
        _BunUp.sprite = _BDown;

        // 네트워크 플레이어(로드된 햄버거 프리팹)를 찾아서 Canvas 자식 객체로 만들어주기
        // NetworkIdentity 

        //Canvas canvas = FindObjectOfType<Canvas>();

        //NetworkIdentity[] netIdList = FindObjectsOfType<NetworkIdentity>();
        //foreach (NetworkIdentity netId in netIdList)
        //{
        //    if (netId.hasAuthority)
        //    {
        //        _Playernetid = netId;
                
        //    }
        //    else
        //    {

        //    }

           
        //}

    }

    // Update is called once per frame
    void Update()
    {
        for (int j = 0; j < _topping.Count; j++)
        {
            _numText[j].text = string.Format("{0}", _topping[j]).ToString();

            if (10 < _topping.Count)
            {
                Done();
                PVP.Ins.Same();

                _BunDown.sprite = _BDown;
                _BunUp.sprite = _BDown;
            }
        }

        if (_topping.Count == 1)
        {
            ResetNumText();
        }
        
    }

    



    public void ResetNumText()
    {
        for (int j = 0; j < 10; j++)
        {
            _numText[j].text = string.Format("{0}", 11).ToString();
        }
    }

    public void Done()
    {
        _topping.Clear();
        GameObject[] _B = GameObject.FindGameObjectsWithTag("C_Bun");
        foreach (GameObject b in _B)
        {
            Destroy(b, 0f);
        }
        GameObject[] _MB = GameObject.FindGameObjectsWithTag("C_MiddieBun");
        foreach (GameObject mb in _MB)
        {
            Destroy(mb, 0f);
        }
        GameObject[] _C = GameObject.FindGameObjectsWithTag("C_Cheese");
        foreach (GameObject c in _C)
        {
            Destroy(c, 0f);
        }
        GameObject[] _T = GameObject.FindGameObjectsWithTag("C_Tomato");
        foreach (GameObject t in _T)
        {
            Destroy(t, 0f);
        }
        GameObject[] _L = GameObject.FindGameObjectsWithTag("C_Lettuce");
        foreach (GameObject l in _L)
        {
            Destroy(l, 0f);
        }
        GameObject[] _M = GameObject.FindGameObjectsWithTag("C_Meat");
        foreach (GameObject m in _M)
        {
            Destroy(m, 0f);
        }
    }


    public void OnBun()
    {
        HamburgerPlayer[] playerlist = FindObjectsOfType<HamburgerPlayer>();
        foreach(HamburgerPlayer p in playerlist)
        {
            NetworkIdentity n = p.netIdentity;
      
            if (NetworkClient.active && n.isLocalPlayer )
            {
               p.OnBun();
            }
        }

        
    }

    
    public void _OnBun()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.BunBtn);
        Instantiate(_bun, _posion1, Quaternion.identity, GameObject.Find("Hamburger").transform);

        int _bunBtn = 0;
        _topping.Add(_bunBtn);

        _BunDown.sprite = _BUp;
        _BunUp.sprite = _BUp;
    }
    public void OnTomato()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.Tomato);
        Instantiate(_tomato, _posion2, Quaternion.identity, GameObject.Find("Hamburger").transform);

        int _tomatoBtn = 1;

        _topping.Add(_tomatoBtn);
    }
    public void OnCheese()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.Cheese);
        Instantiate(_cheese, _posion3, Quaternion.identity, GameObject.Find("Hamburger").transform);

        int _cheeseBtn = 2;

        _topping.Add(_cheeseBtn);
    }
    public void OnLettuce()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.LettuceBtn);
        Instantiate(_lettuce, _posion4, Quaternion.identity, GameObject.Find("Hamburger").transform);

        int _lettuceBtn = 3;

        _topping.Add(_lettuceBtn);
    }
    public void OnMeat()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.Meat);
        Instantiate(_meat, _posion5, Quaternion.identity, GameObject.Find("Hamburger").transform);

        int _meatBtn = 4;

        _topping.Add(_meatBtn);
    }
    public void OnMiddelbun()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.BunBtn);
        Instantiate(_middlebun, _posion6, Quaternion.identity, GameObject.Find("Hamburger").transform);

        int _middlebunBtn = 5;

        _topping.Add(_middlebunBtn);
    }

}

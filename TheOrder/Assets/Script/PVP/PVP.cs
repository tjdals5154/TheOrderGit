using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PVP : NetworkBehaviour
{
    private static PVP _instance;

    public static PVP Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PVP>();
                if (null == _instance)
                {

                }
            }
            return _instance;
        }
    }

    public Vector2 _order;

    Text _ordertext;
    GameObject _Ins;
    GameObject _Ins2;

    public Text _Reward;
    public int _Money;

    public int _ordernum;
    public int _BESTPVP;
    public int _PVP;
    public int _PVP2;
    public int _Win;
    public int _Win2;

    public Text _ORDERNUM;
    public Text _BESTPVPNUM;

    public Text _PVPNUM;
    public Text _PVPNUM2;
    public Text _ShMyOrder;
    public Text _ShMyOrder2;
    public Text _WinText;
    public Text _WinText2;

    public float _RandomTime = 0;

    public float _ResetTime;
    public float _VipSpeed;
    public bool _VipSpeedbool;
    public bool _Chochoice;
    bool _wrong;

    public GameObject _win1;
    public GameObject _win2;
    public GameObject _lose1;
    public GameObject _lose2;


    public List<GameObject> _Corderpaper = new List<GameObject>();
    public List<GameObject> _CVipOrder = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        _Money = PlayerPrefs.GetInt("Money", 0);
        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
        _VipSpeedbool = true;
        _Chochoice = true;
        _wrong = false;
        _BESTPVP = PlayerPrefs.GetInt("PVP", 0);

        InvokeRepeating("New", 1f, 4f);
        //StopCoroutine("New");
    }

    // Update is called once per frame
    void Update()
    {
        VipReset();

        if (_Money < 0)
        {
            _Reward.color = new Color(224 / 255f, 0 / 255f, 0 / 255f, 255 / 255f);
        }
        else
        {
            _Reward.color = new Color(48 / 255f, 219 / 255f, 0 / 255f, 255 / 255f);
        }

        _ORDERNUM.text = "" + _ordernum;
        _BESTPVPNUM.text = "" + _BESTPVP;
        //_PVPNUM.text = "" + _PVP;
        //_PVPNUM2.text = "" + _PVP;
        _ShMyOrder.text = "" + _PVP;
        _ShMyOrder2.text = "" + _PVP2;
        _WinText.text = "" + _Win;
        _WinText2.text = "" + _Win2;

        if (_PVP > _BESTPVP)
        {
            _BESTPVP = _PVP;
        }

        if (P_Game.Ins._openbell == true)
        {
            if (P_Game.Ins._pause == false)
            {
                //ClassSpeed();
            }
            else
            {

            }
        }

        if (_Corderpaper.Count >= 1)
        {
            Speed();
        }
        if (_CVipOrder.Count >= 1)
        {
            Speed2();
        }
    }
    public void PVPB()
    {
        HamburgerPlayer[] playerlist = FindObjectsOfType<HamburgerPlayer>();
        foreach (HamburgerPlayer p in playerlist)
        {
            NetworkIdentity n = p.netIdentity;

            if (NetworkClient.active && n.isLocalPlayer)
            {
                p.PVPBTn();
            }
        }
    }

    public void Lose()
    {
        _Win2 += 1;
        _WinText2.text = _Win2.ToString();
        _win1.SetActive(false);
        _lose1.SetActive(false);
        _win2.SetActive(true);
        _lose2.SetActive(true);
    }
    public void Win()
    {
        _Win += 1;
        _WinText.text = _Win.ToString();
        _win1.SetActive(true);
        _lose1.SetActive(true);
        _win2.SetActive(false);
        _lose2.SetActive(false);
    }

    void VipReset()
    {
        _RandomTime += Time.deltaTime;

        if (_Chochoice == true)
        {
            _ResetTime = Random.Range(70, 100);
            _Chochoice = false;
        }

        if (_RandomTime > _ResetTime)
        {
            Vip();
            _RandomTime = 0;
        }
    }
    //void ClassSpeed()
    //{
    //    if (_ordernum < 6)
    //    {
    //        P_Game.Ins._class.fillAmount += 0.00010f;
    //    }
    //    else if (_ordernum < 21)
    //    {
    //        P_Game.Ins._class.fillAmount += 0.00015f;
    //    }
    //    else if (_ordernum < 31)
    //    {
    //        P_Game.Ins._class.fillAmount += 0.00020f;
    //    }
    //    else if (_ordernum < 41)
    //    {
    //        P_Game.Ins._class.fillAmount += 0.00025f;
    //    }
    //    else if (_ordernum >= 41)
    //    {
    //        P_Game.Ins._class.fillAmount += 0.00030f;
    //    }
    //}

    void Speed()
    {
        for (int i = 0; i < _Corderpaper.Count; i++)
        {
            P_OrderPaper paper = _Corderpaper[i].GetComponent<P_OrderPaper>();

            if (paper._orderNum < 6)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 50 * Time.deltaTime);
            }
            else if (paper._orderNum < 21)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 100 * Time.deltaTime);
            }
            else if (paper._orderNum < 31)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 130 * Time.deltaTime);
            }
            else if (paper._orderNum < 41)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 180 * Time.deltaTime);
            }
            else if (paper._orderNum >= 41)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 200 * Time.deltaTime);
            }
        }
    }
    void Speed2()
    {
        for (int i = 0; i < _CVipOrder.Count; i++)
        {
            if (_VipSpeedbool == true)
            {
                _VipSpeed = Random.Range(40, 250);
                _VipSpeedbool = false;
            }

            VipOrder paper = _CVipOrder[i].GetComponent<VipOrder>();
            _CVipOrder[i].transform.Translate(Vector2.right * _VipSpeed * Time.deltaTime);
        }
    }

    public void OnFinishBtn()
    {
        Same();
        Same2();
        P_Button.Ins.Done();

        P_Button.Ins._BunDown.sprite = P_Button.Ins._BDown;
        P_Button.Ins._BunUp.sprite = P_Button.Ins._BDown;

        if (_wrong == false)
        {
            //_Money -= 5;
            _Reward.text = "" + string.Format("{0:#,###0}", _Money);
            //P_Game.Ins._class.fillAmount += 0.05f;
            SoundManager.Ins.PlaySound(SoundManager.FxTypes.BellFSound);
            //P_Game.Ins._class.fillAmount = 1;
            P_Game.Ins.Over();
        }
        else
        {
            SoundManager.Ins.PlaySound(SoundManager.FxTypes.BellSound);
        }
        _wrong = false;
    }

    public void PVPScore()
    {
        _PVP += 1;
        _PVPNUM.text = _PVP.ToString();
        _ShMyOrder.text = _PVP.ToString();
    }
    public void PVPScore2()
    {
        _PVP2 += 1;
        _PVPNUM2.text = _PVP2.ToString();
        _ShMyOrder2.text = _PVP2.ToString();
    }

    public void Same()
    {
        P_OrderPaper op = null;
        foreach (GameObject opObj in _Corderpaper)
        {
            op = opObj.GetComponent<P_OrderPaper>();
            if (op != null)
            {
                if (op._numText[0].text == P_Button.Ins._numText[0].text &&
                    op._numText[1].text == P_Button.Ins._numText[1].text &&
                    op._numText[2].text == P_Button.Ins._numText[2].text &&
                    op._numText[3].text == P_Button.Ins._numText[3].text &&
                    op._numText[4].text == P_Button.Ins._numText[4].text &&
                    op._numText[5].text == P_Button.Ins._numText[5].text &&
                    op._numText[6].text == P_Button.Ins._numText[6].text &&
                    op._numText[7].text == P_Button.Ins._numText[7].text &&
                    op._numText[8].text == P_Button.Ins._numText[8].text &&
                    op._numText[9].text == P_Button.Ins._numText[9].text)
                {
                    //string tempStr = "";
                    //foreach (Text t in op._numText)
                    //{
                    //    tempStr += t.text;
                    //}
                    //Debug.Log("오더 삭제: " + tempStr);

                    if (_ordernum < 6)
                    {
                        _Money += 3;
                        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                        //P_Game.Ins._class.fillAmount -= 0.10f;
                    }
                    else if (_ordernum < 21)
                    {
                        _Money += 5;
                        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                        //P_Game.Ins._class.fillAmount -= 0.15f;
                    }
                    else if (_ordernum < 31)
                    {
                        _Money += 8;
                        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                        //P_Game.Ins._class.fillAmount -= 0.20f;
                    }
                    else if (_ordernum < 41)
                    {
                        _Money += 12;
                        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                        //P_Game.Ins._class.fillAmount -= 0.25f;
                    }
                    else if (_ordernum >= 41)
                    {
                        _Money += 12;
                        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                        //P_Game.Ins._class.fillAmount -= 0.25f;
                    }
                    _Corderpaper.Remove(op.gameObject);
                    Destroy(op.gameObject);

                    P_Button.Ins.ResetNumText();
                    SoundManager.Ins.PlaySound(SoundManager.FxTypes.TearSound);

                    PVPB();

                    _wrong = true;
                    break;
                }
            }
        }
    }

    public void Same2()
    {
        VipOrder op2 = null;
        foreach (GameObject opObj2 in _CVipOrder)
        {
            op2 = opObj2.GetComponent<VipOrder>();
            if (op2 != null)
            {
                if (op2._numText[0].text == P_Button.Ins._numText[0].text &&
                    op2._numText[1].text == P_Button.Ins._numText[1].text &&
                    op2._numText[2].text == P_Button.Ins._numText[2].text &&
                    op2._numText[3].text == P_Button.Ins._numText[3].text &&
                    op2._numText[4].text == P_Button.Ins._numText[4].text &&
                    op2._numText[5].text == P_Button.Ins._numText[5].text &&
                    op2._numText[6].text == P_Button.Ins._numText[6].text &&
                    op2._numText[7].text == P_Button.Ins._numText[7].text &&
                    op2._numText[8].text == P_Button.Ins._numText[8].text &&
                    op2._numText[9].text == P_Button.Ins._numText[9].text)
                {
                    //string tempStr = "";
                    //foreach (Text t in op._numText)
                    //{
                    //    tempStr += t.text;
                    //}
                    //Debug.Log("오더 삭제: " + tempStr);

                    _Money += 50;
                    _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                    P_Game.Ins._class.fillAmount -= 0.10f;

                    _CVipOrder.Remove(op2.gameObject);
                    Destroy(op2.gameObject);

                    P_Button.Ins.ResetNumText();
                    SoundManager.Ins.PlaySound(SoundManager.FxTypes.TearSound);

                    _wrong = true;
                    _Chochoice = true;
                    _VipSpeedbool = true;
                    break;
                }
            }
        }
    }

    public void New()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.Printer);
        GameObject CorderPrefab = Resources.Load("C_PVP Paper") as GameObject;

        Transform parent = GameObject.Find("OrderPaper").transform;

        int childCount = parent.childCount;

        _Ins = Instantiate(CorderPrefab, _order, Quaternion.identity, parent);
        _Ins.gameObject.name = "C_PVP Paper_" + childCount;
        //_Ins.transform.SetAsFirstSibling();

        _Corderpaper.Add(_Ins);

        GameObject Level = _Ins.transform.Find("number").gameObject;

        _ordertext = Level.GetComponent<Text>() as Text;

        _ordernum += 1;
        _ordertext.text = _ordernum.ToString();

        P_OrderPaper paper = _Ins.GetComponent<P_OrderPaper>();
        paper._orderNum = _ordernum;
    }

    void Vip()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.Printer);
        GameObject CorderPrefab = Resources.Load("VipOrder") as GameObject;

        _Ins2 = Instantiate(CorderPrefab, _order, Quaternion.identity, GameObject.Find("OrderPaper").transform);

        _CVipOrder.Add(_Ins2);

        GameObject Level = _Ins2.transform.Find("number").gameObject;
    }
}

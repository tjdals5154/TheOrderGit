using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderShow : MonoBehaviour
{
    private static OrderShow _instance;

    public static OrderShow Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<OrderShow>();
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
    public int _BESTordernum;
    public int _clear;
    public int _Combo;

    public Text _ORDERNUM;
    public Text _BESTORDERNUM;
    public Text _CLEARNUM;
    public Text _ComboText;

    public float _RandomTime = 0;

    public float _ResetTime;
    public float _VipSpeed;
    public bool _VipSpeedbool;
    public bool _Chochoice;
    bool _wrong;

    public List<GameObject> _Corderpaper = new List<GameObject>();
    public List<GameObject> _CVipOrder = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        _Money = PlayerPrefs.GetInt("Money", 0);
        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
        _Combo = 0;
        _VipSpeedbool = true;
        _Chochoice = true;
        _wrong = false;
        _BESTordernum = PlayerPrefs.GetInt("TopScore", 0);

        InvokeRepeating("New", 1f, 3.9f);
        //InvokeRepeating("New", 1f, 2.73f);
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
        _BESTORDERNUM.text = "" + _BESTordernum;
        _CLEARNUM.text = "" + _clear;
        _ComboText.text = "" + _Combo;

        if (_clear > _BESTordernum)
        {
            _BESTordernum = _clear;
        }

        if (Game.Ins._openbell == true)
        {
            if (Game.Ins._pause == false)
            {
                ClassSpeed();
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
    void ClassSpeed()
    {
        if (_ordernum < 11)
        {
            Game.Ins._class.fillAmount += 0.00020f;
        }
        else if (_ordernum < 31)
        {
            Game.Ins._class.fillAmount += 0.00025f;
        }
        else if (_ordernum < 51)
        {
            Game.Ins._class.fillAmount += 0.00030f;
        }
        else if (_ordernum < 71)
        {
            Game.Ins._class.fillAmount += 0.00035f;
        }
        else if (_ordernum < 91)
        {
            Game.Ins._class.fillAmount += 0.00040f;
        }
        else if (_ordernum >= 91)
        {
            Game.Ins._class.fillAmount += 0.00040f;
        }
    }

    void Speed()
    {
        for (int i = 0; i < _Corderpaper.Count; i++)
        {
            Orderpaper paper = _Corderpaper[i].GetComponent<Orderpaper>();

            RectTransform rect = paper.transform as RectTransform;

            if (paper._orderNum < 6)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 70 * Time.deltaTime);
            }
            else if (paper._orderNum < 11)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 75 * Time.deltaTime);
            }
            else if (paper._orderNum < 16)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 80 * Time.deltaTime);
            }
            else if (paper._orderNum < 21)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 85 * Time.deltaTime);
            }
            else if (paper._orderNum < 26)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 90 * Time.deltaTime);
            }
            else if (paper._orderNum < 31)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 95 * Time.deltaTime);
            }
            else if (paper._orderNum < 36)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 100 * Time.deltaTime);
            }
            else if (paper._orderNum < 41)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 105 * Time.deltaTime);
            }
            else if (paper._orderNum < 46)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 110 * Time.deltaTime);
            }
            else if (paper._orderNum < 51)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 115 * Time.deltaTime);
            }
            else if (paper._orderNum < 56)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 120 * Time.deltaTime);
            }
            else if (paper._orderNum < 61)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 125 * Time.deltaTime);
            }
            else if (paper._orderNum < 66)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 130 * Time.deltaTime);
            }
            else if (paper._orderNum < 71)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 135 * Time.deltaTime);
            }
            else if (paper._orderNum < 76)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 140 * Time.deltaTime);
            }
            else if (paper._orderNum < 81)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 145 * Time.deltaTime);
            }
            else if (paper._orderNum < 86)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 150 * Time.deltaTime);
            }
            else if (paper._orderNum < 91)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 155 * Time.deltaTime);
            }
            else if (paper._orderNum < 96)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 160 * Time.deltaTime);
            }
            else if (paper._orderNum < 101)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 165 * Time.deltaTime);
            }
            else if (paper._orderNum < 106)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 170 * Time.deltaTime);
            }
            else if (paper._orderNum >= 106)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 170 * Time.deltaTime);
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

        
        Button.Ins.Done();

        Button.Ins._BunDown.sprite = Button.Ins._BDown;
        Button.Ins._BunUp.sprite = Button.Ins._BDown;

        if (_wrong == false)
        {
            _Money -= 5;
            _Reward.text = "" + string.Format("{0:#,###0}", _Money);
            Game.Ins._class.fillAmount += 0.05f;
            SoundManager.Ins.PlaySound(SoundManager.FxTypes.BellFSound);
            _Combo = 0;
            _ComboText.text = _Combo.ToString();
        }
        else
        {
            SoundManager.Ins.PlaySound(SoundManager.FxTypes.BellSound);
        }
        _wrong = false;


    }

    public void Same()
    {
        Orderpaper op = null;
        
        foreach ( GameObject opObj in _Corderpaper)
        {
            op = opObj.GetComponent<Orderpaper>();
            if(op!=null)
            {
                if (op._numText[0].text == Button.Ins._numText[0].text &&
                    op._numText[1].text == Button.Ins._numText[1].text &&
                    op._numText[2].text == Button.Ins._numText[2].text &&
                    op._numText[3].text == Button.Ins._numText[3].text &&
                    op._numText[4].text == Button.Ins._numText[4].text &&
                    op._numText[5].text == Button.Ins._numText[5].text &&
                    op._numText[6].text == Button.Ins._numText[6].text &&
                    op._numText[7].text == Button.Ins._numText[7].text &&
                    op._numText[8].text == Button.Ins._numText[8].text &&
                    op._numText[9].text == Button.Ins._numText[9].text)
                {
                    //string tempStr = "";
                    //foreach (Text t in op._numText)
                    //{
                    //    tempStr += t.text;
                    //}
                    //Debug.Log("오더 삭제: " + tempStr);

                    if (_ordernum < 11)
                    {
                        _Money += 3;
                        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                        Game.Ins._class.fillAmount -= 0.10f;
                    }
                    else if (_ordernum < 31)
                    {
                        _Money += 5;
                        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                        Game.Ins._class.fillAmount -= 0.12f;
                    }
                    else if (_ordernum < 51)
                    {
                        _Money += 7;
                        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                        Game.Ins._class.fillAmount -= 0.14f;
                    }
                    else if (_ordernum < 71)
                    {
                        _Money += 10;
                        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                        Game.Ins._class.fillAmount -= 0.16f;
                    }
                    else if (_ordernum < 91)
                    {
                        _Money += 12;
                        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                        Game.Ins._class.fillAmount -= 0.18f;
                    }
                    else if (_ordernum >= 91)
                    {
                        _Money += 12;
                        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                        Game.Ins._class.fillAmount -= 0.18f;
                    }
                    _Corderpaper.Remove(op.gameObject);
                    Destroy(op.gameObject);

                    Button.Ins.ResetNumText();
                    SoundManager.Ins.PlaySound(SoundManager.FxTypes.TearSound);

                    _clear += 1;
                    _CLEARNUM.text = _clear.ToString();
                    _wrong = true;
                    _Combo += 1;
                    _ComboText.text = _Combo.ToString();
                    Combo.Ins._animator.SetTrigger("Move");
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
                if (op2._numText[0].text == Button.Ins._numText[0].text &&
                    op2._numText[1].text == Button.Ins._numText[1].text &&
                    op2._numText[2].text == Button.Ins._numText[2].text &&
                    op2._numText[3].text == Button.Ins._numText[3].text &&
                    op2._numText[4].text == Button.Ins._numText[4].text &&
                    op2._numText[5].text == Button.Ins._numText[5].text &&
                    op2._numText[6].text == Button.Ins._numText[6].text &&
                    op2._numText[7].text == Button.Ins._numText[7].text &&
                    op2._numText[8].text == Button.Ins._numText[8].text &&
                    op2._numText[9].text == Button.Ins._numText[9].text)
                {
                    //string tempStr = "";
                    //foreach (Text t in op._numText)
                    //{
                    //    tempStr += t.text;
                    //}
                    //Debug.Log("오더 삭제: " + tempStr);

                    _Money += 30;
                    _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                    Game.Ins._class.fillAmount -= 0.10f;

                    _CVipOrder.Remove(op2.gameObject);
                    Destroy(op2.gameObject);

                    Button.Ins.ResetNumText();
                    SoundManager.Ins.PlaySound(SoundManager.FxTypes.TearSound);

                    _wrong = true;
                    _Chochoice = true;
                    _VipSpeedbool = true;
                    break;
                }
            }
        }
    }

    void New()
    {
        
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.Printer);
        GameObject CorderPrefab = Resources.Load("C_Order Paper") as GameObject;


        Transform parent = GameObject.Find("OrderPaper").transform;

        int childCount = parent.childCount;

        _Ins = Instantiate(CorderPrefab, _order, Quaternion.identity, parent);

        _Ins.gameObject.name = "C_Order Paper_" + childCount;
        //_Ins.transform.SetAsFirstSibling();

        
        _Corderpaper.Add(_Ins);

        GameObject Level = _Ins.transform.Find("number").gameObject;

        _ordertext = Level.GetComponent<Text>() as Text;

        _ordernum += 1;
        _ordertext.text = _ordernum.ToString();

        Orderpaper paper = _Ins.GetComponent<Orderpaper>();
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

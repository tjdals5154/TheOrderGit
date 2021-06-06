using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Speed : MonoBehaviour
{
    private static Speed _instance;

    public static Speed Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Speed>();
                if (null == _instance)
                {

                }
            }
            return _instance;
        }
    }

    public Vector2 _order1;
    public Vector2 _order2;
    public Vector2 _order3;
    public Vector2 _order4;
    public Vector2 _order5;
    public Vector2 _order6;
    public Vector2 _order7;
    public Vector2 _order8;
    public Vector2 _order9;
    public Vector2 _order10;
    public Vector2 _order11;
    public Vector2 _order12;
    public Vector2 _order13;
    public Vector2 _order14;
    public Vector2 _order15;
    public Vector2 _order16;
    public Vector2 _order17;
    public Vector2 _order18;

    //Text _ordertext;
    GameObject _Ins1;
    GameObject _Ins2;
    GameObject _Ins3;
    GameObject _Ins4;
    GameObject _Ins5;
    GameObject _Ins6;
    GameObject _Ins7;
    GameObject _Ins8;
    GameObject _Ins9;
    GameObject _Ins10;
    GameObject _Ins11;
    GameObject _Ins12;
    GameObject _Ins13;
    GameObject _Ins14;
    GameObject _Ins15;
    GameObject _Ins16;
    GameObject _Ins17;
    GameObject _Ins18;

    public Text _Reward;
    public int _Money;

    public int _ordernum;
    public float _BESTSpeed;
    public float _Speed;
    public int _Combo;

    public Text _ORDERNUM;
    public Text _BESTSPEEDNUM;
    public Text _SPEEDNUM;
    public Text _ComboText;

    public float _RandomTime = 0;
    bool _wrong;
    bool _Stop;

    public List<GameObject> _Corderpaper = new List<GameObject>();
    public List<GameObject> _CVipOrder = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        _Stop = false;
        _Money = PlayerPrefs.GetInt("Money", 0);
        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
        _Combo = 0;
        _wrong = false;
        _BESTSpeed = PlayerPrefs.GetFloat("Speed", 0);

        Invoke("New", 1f);
        //StopCoroutine("New");
    }

    // Update is called once per frame
    void Update()
    {
        if (_Money < 0)
        {
            _Reward.color = new Color(224 / 255f, 0 / 255f, 0 / 255f, 255 / 255f);
        }
        else
        {
            _Reward.color = new Color(48 / 255f, 219 / 255f, 0 / 255f, 255 / 255f);
        }

        if (S_Game.Ins._Time > _BESTSpeed)
        {
            _BESTSpeed = S_Game.Ins._Time; 
        }
        _ORDERNUM.text = "" + S_Game.Ins._Time;
        _BESTSPEEDNUM.text = "" + _BESTSpeed;
        _SPEEDNUM.text = "" + S_Game.Ins._Time;
        _ComboText.text = "" + _Combo;


        if (S_Game.Ins._openbell == true)
        {
            if (S_Game.Ins._pause == false)
            {
                ClassSpeed();
            }
            else
            {

            }
        }

        Invoke("GameStart", 1.2f);

        if (S_Game.Ins._class.fillAmount == 1)
        {
            if (S_Game.Ins._off == false)
            {
                //SoundManager.Ins.TimerSource.Stop();
                S_Game.Ins.vibOn();
                SoundManager.Ins.PlaySound(SoundManager.FxTypes.ShutterSound);
                S_Game.Ins._off = true;
            }
            S_Game.Ins._Shutter.transform.position = Vector2.MoveTowards(S_Game.Ins._Shutter.transform.position, S_Game.Ins._closedShutter, 4200 * Time.deltaTime);

            S_Game.Ins._OpenBoard.SetActive(false);
            S_Game.Ins._ClosedBoard.SetActive(true);
            S_Game.Ins._Cover.SetActive(true);
            S_Game.Ins._Bell.SetActive(true);
            S_Game.Ins._FBell.SetActive(false);

            Invoke("GameOver", 1.7f);
        }
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("Combo", _Combo);
        PlayerPrefs.SetInt("Money", _Money);
        PlayerPrefs.SetFloat("Speed1", S_Game.Ins._Time);

        float prevBestSpeed = PlayerPrefs.GetFloat("Speed");

        if (prevBestSpeed >= S_Game.Ins._Time)
        {
            PlayerPrefs.SetFloat("Speed", S_Game.Ins._Time);
        }

        _ORDERNUM.text = "" + _ordernum.ToString();
        _BESTSPEEDNUM.text = "" + S_Game.Ins._Time.ToString();
        _Reward.text = "" + string.Format("{0:#,###0}", _Money.ToString());
        _ComboText.text = "" + _Combo.ToString();

        SceneManager.LoadScene("LobbyScene");
    }

    void GameStart()
    {
        if (_Corderpaper.Count == 0)
        {

            S_Game.Ins._class.fillAmount = 1;
            _Stop = false;

        }
    }

    void ClassSpeed()
    {
        if (_Stop == false)
        {
            if (_Corderpaper.Count >= 1)
            {
                S_Game.Ins._Time += 1f * Time.deltaTime;
            }
        }
    }
        

    //void Speed1()
    //{
    //    for (int i = 0; i < _Corderpaper.Count; i++)
    //    {
    //        S_OrderPaper paper = _Corderpaper[i].GetComponent<S_OrderPaper>();

    //        if (paper._orderNum >= 0)
    //        {
    //            _Corderpaper[i].transform.Translate(Vector2.right * 50 * Time.deltaTime);
    //        }
    //    }
    //}

    public void OnFinishBtn()
    {
        Same();
        S_Button.Ins.Done();

        S_Button.Ins._BunDown.sprite = S_Button.Ins._BDown;
        S_Button.Ins._BunUp.sprite = S_Button.Ins._BDown;

        if (_wrong == false)
        {
            //_Money -= 50;
            _Reward.text = "" + string.Format("{0:#,###0}", _Money);
            //S_Game.Ins._class.fillAmount += 0.005f;
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
        S_OrderPaper op = null;
        foreach (GameObject opObj in _Corderpaper)
        {
            op = opObj.GetComponent<S_OrderPaper>();
            if (op != null)
            {
                if (op._numText[0].text == S_Button.Ins._numText[0].text &&
                    op._numText[1].text == S_Button.Ins._numText[1].text &&
                    op._numText[2].text == S_Button.Ins._numText[2].text &&
                    op._numText[3].text == S_Button.Ins._numText[3].text &&
                    op._numText[4].text == S_Button.Ins._numText[4].text &&
                    op._numText[5].text == S_Button.Ins._numText[5].text &&
                    op._numText[6].text == S_Button.Ins._numText[6].text &&
                    op._numText[7].text == S_Button.Ins._numText[7].text &&
                    op._numText[8].text == S_Button.Ins._numText[8].text &&
                    op._numText[9].text == S_Button.Ins._numText[9].text)
                {
                    if (_ordernum >= 0)
                    {
                        _Money += 1;
                        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                        //S_Game.Ins._class.fillAmount -= 0.10f;
                    }
                    _Corderpaper.Remove(op.gameObject);
                    Destroy(op.gameObject);

                    S_Button.Ins.ResetNumText();
                    SoundManager.Ins.PlaySound(SoundManager.FxTypes.TearSound);

                    //_Speed += 1;
                    //_SPEEDNUM.text = _Speed.ToString();
                    _wrong = true;
                    _Combo += 1;
                    _ComboText.text = _Combo.ToString();
                    Combo.Ins._animator.SetTrigger("Move");

                    

                    break;
                }
            }
        }

    }

    void New()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.Printer);
        GameObject CorderPrefab = Resources.Load("C_Speed Paper") as GameObject;

        Transform parent = GameObject.Find("OrderPaper").transform;


        //int childCount = parent.childCount;

        _Ins1 = Instantiate(CorderPrefab, _order1, Quaternion.identity, parent);
        _Ins2 = Instantiate(CorderPrefab, _order2, Quaternion.identity, parent);
        _Ins3 = Instantiate(CorderPrefab, _order3, Quaternion.identity, parent);
        _Ins4 = Instantiate(CorderPrefab, _order4, Quaternion.identity, parent);
        _Ins5 = Instantiate(CorderPrefab, _order5, Quaternion.identity, parent);
        _Ins6 = Instantiate(CorderPrefab, _order6, Quaternion.identity, parent);
        _Ins7 = Instantiate(CorderPrefab, _order7, Quaternion.identity, parent);
        _Ins8 = Instantiate(CorderPrefab, _order8, Quaternion.identity, parent);
        _Ins9 = Instantiate(CorderPrefab, _order9, Quaternion.identity, parent);
        _Ins10 = Instantiate(CorderPrefab, _order10, Quaternion.identity, parent);
        _Ins11 = Instantiate(CorderPrefab, _order11, Quaternion.identity, parent);
        _Ins12 = Instantiate(CorderPrefab, _order12, Quaternion.identity, parent);
        _Ins13 = Instantiate(CorderPrefab, _order13, Quaternion.identity, parent);
        _Ins14 = Instantiate(CorderPrefab, _order14, Quaternion.identity, parent);
        _Ins15 = Instantiate(CorderPrefab, _order15, Quaternion.identity, parent);
        _Ins16 = Instantiate(CorderPrefab, _order16, Quaternion.identity, parent);
        _Ins17 = Instantiate(CorderPrefab, _order17, Quaternion.identity, parent);
        _Ins18 = Instantiate(CorderPrefab, _order18, Quaternion.identity, parent);
        //_Ins.gameObject.name = "C_Speed Paper_" + childCount;
        _Ins1.transform.SetAsFirstSibling();
        _Ins2.transform.SetAsFirstSibling();
        _Ins3.transform.SetAsFirstSibling();
        _Ins4.transform.SetAsFirstSibling();
        _Ins5.transform.SetAsFirstSibling();
        _Ins6.transform.SetAsFirstSibling();
        _Ins7.transform.SetAsFirstSibling();
        _Ins8.transform.SetAsFirstSibling();
        _Ins9.transform.SetAsFirstSibling();
        _Ins10.transform.SetAsFirstSibling();
        _Ins11.transform.SetAsFirstSibling();
        _Ins12.transform.SetAsFirstSibling();
        _Ins13.transform.SetAsFirstSibling();
        _Ins14.transform.SetAsFirstSibling();
        _Ins15.transform.SetAsFirstSibling();
        _Ins16.transform.SetAsFirstSibling();
        _Ins17.transform.SetAsFirstSibling();
        _Ins18.transform.SetAsFirstSibling();

        _Corderpaper.Add(_Ins1);
        _Corderpaper.Add(_Ins2);
        _Corderpaper.Add(_Ins3);
        _Corderpaper.Add(_Ins4);
        _Corderpaper.Add(_Ins5);
        _Corderpaper.Add(_Ins6);
        _Corderpaper.Add(_Ins7);
        _Corderpaper.Add(_Ins8);
        _Corderpaper.Add(_Ins9);
        _Corderpaper.Add(_Ins10);
        _Corderpaper.Add(_Ins11);
        _Corderpaper.Add(_Ins12);
        _Corderpaper.Add(_Ins13);
        _Corderpaper.Add(_Ins14);
        _Corderpaper.Add(_Ins15);
        _Corderpaper.Add(_Ins16);
        _Corderpaper.Add(_Ins17);
        _Corderpaper.Add(_Ins18);
        

        GameObject Level1 = _Ins1.transform.Find("number").gameObject;
        GameObject Level2 = _Ins2.transform.Find("number").gameObject;
        GameObject Level3 = _Ins3.transform.Find("number").gameObject;
        GameObject Level4 = _Ins4.transform.Find("number").gameObject;
        GameObject Level5 = _Ins5.transform.Find("number").gameObject;
        GameObject Level6 = _Ins6.transform.Find("number").gameObject;
        GameObject Level7 = _Ins7.transform.Find("number").gameObject;
        GameObject Level8 = _Ins8.transform.Find("number").gameObject;
        GameObject Level9 = _Ins9.transform.Find("number").gameObject;
        GameObject Level10 = _Ins10.transform.Find("number").gameObject;
        GameObject Level11 = _Ins11.transform.Find("number").gameObject;
        GameObject Level12 = _Ins12.transform.Find("number").gameObject;
        GameObject Level13 = _Ins13.transform.Find("number").gameObject;
        GameObject Level14 = _Ins14.transform.Find("number").gameObject;
        GameObject Level15 = _Ins15.transform.Find("number").gameObject;
        GameObject Level16 = _Ins16.transform.Find("number").gameObject;
        GameObject Level17 = _Ins17.transform.Find("number").gameObject;
        GameObject Level18 = _Ins18.transform.Find("number").gameObject;

        //_ordertext = Level.GetComponent<Text>() as Text;

        //_ordernum += 1;
        //_ordertext.text = _ordernum.ToString();

        S_OrderPaper paper1 = _Ins1.GetComponent<S_OrderPaper>();
        S_OrderPaper paper2 = _Ins2.GetComponent<S_OrderPaper>();
        S_OrderPaper paper3 = _Ins3.GetComponent<S_OrderPaper>();
        S_OrderPaper paper4 = _Ins4.GetComponent<S_OrderPaper>();
        S_OrderPaper paper5 = _Ins5.GetComponent<S_OrderPaper>();
        S_OrderPaper paper6 = _Ins6.GetComponent<S_OrderPaper>();
        S_OrderPaper paper7 = _Ins7.GetComponent<S_OrderPaper>();
        S_OrderPaper paper8 = _Ins8.GetComponent<S_OrderPaper>();
        S_OrderPaper paper9 = _Ins9.GetComponent<S_OrderPaper>();
        S_OrderPaper paper10 = _Ins10.GetComponent<S_OrderPaper>();
        S_OrderPaper paper11 = _Ins11.GetComponent<S_OrderPaper>();
        S_OrderPaper paper12 = _Ins12.GetComponent<S_OrderPaper>();
        S_OrderPaper paper13 = _Ins13.GetComponent<S_OrderPaper>();
        S_OrderPaper paper14 = _Ins14.GetComponent<S_OrderPaper>();
        S_OrderPaper paper15 = _Ins15.GetComponent<S_OrderPaper>();
        S_OrderPaper paper16 = _Ins16.GetComponent<S_OrderPaper>();
        S_OrderPaper paper17 = _Ins17.GetComponent<S_OrderPaper>();
        S_OrderPaper paper18 = _Ins18.GetComponent<S_OrderPaper>();
        //paper._orderNum = _ordernum;
    }
}

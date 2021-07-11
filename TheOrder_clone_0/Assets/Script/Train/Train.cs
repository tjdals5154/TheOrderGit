using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Train : MonoBehaviour
{
    private static Train _instance;

    public static Train Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Train>();
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

    public Text _Reward;
    public int _Money;

    public int _ordernum;
    public int _BESTTrain;
    public int _Train;
    public int _Combo;

    public Text _ORDERNUM;
    public Text _BESTTRAINNUM;
    public Text _TRAINNUM;
    public Text _ComboText;

    public float _RandomTime = 0;

    bool _wrong;


    public List<GameObject> _Corderpaper = new List<GameObject>();
    public List<GameObject> _CVipOrder = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        _Money = PlayerPrefs.GetInt("Money", 0);
        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
        _Combo = 0;
        _wrong = false;
        _BESTTrain = PlayerPrefs.GetInt("Train", 0);

        InvokeRepeating("New", 1f, 1.8f);
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

        _ORDERNUM.text = "" + _ordernum;
        _BESTTRAINNUM.text = "" + _BESTTrain;
        _TRAINNUM.text = "" + _Train;
        _ComboText.text = "" + _Combo;

        if (_Train > _BESTTrain)
        {
            _BESTTrain = _Train;
        }

        if (T_Game.Ins._openbell == true)
        {
            if (T_Game.Ins._pause == false)
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
    }
    //void ClassSpeed()
    //{
    //    if (_ordernum >= 0)
    //    {
    //        T_Game.Ins._class.fillAmount += 0.00010f;
    //    }
    //}

    void Speed()
    {
        for (int i = 0; i < _Corderpaper.Count; i++)
        {
            T_OrderPaper paper = _Corderpaper[i].GetComponent<T_OrderPaper>();

            if (paper._orderNum >= 0)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 40 * Time.deltaTime);
            }
            
        }
    }

    public void OnFinishBtn()
    {
        Same();
        T_Button.Ins.Done();

        T_Button.Ins._BunDown.sprite = T_Button.Ins._BDown;
        T_Button.Ins._BunUp.sprite = T_Button.Ins._BDown;

        if (_wrong == false)
        {
            //_Money -= 50;
            _Reward.text = "" + string.Format("{0:#,###0}", _Money);
            //T_Game.Ins._class.fillAmount += 0.005f;
            SoundManager.Ins.PlaySound(SoundManager.FxTypes.BellFSound);
            _Combo = 0;
            _ComboText.text = _Combo.ToString();
            T_Game.Ins._class.fillAmount = 1;
        }
        else
        {
            SoundManager.Ins.PlaySound(SoundManager.FxTypes.BellSound);
        }
        _wrong = false;
    }

    public void Same()
    {
        T_OrderPaper op = null;
        foreach (GameObject opObj in _Corderpaper)
        {
            op = opObj.GetComponent<T_OrderPaper>();
            if (op != null)
            {
                if (op._numText[0].text == T_Button.Ins._numText[0].text &&
                    op._numText[1].text == T_Button.Ins._numText[1].text &&
                    op._numText[2].text == T_Button.Ins._numText[2].text &&
                    op._numText[3].text == T_Button.Ins._numText[3].text &&
                    op._numText[4].text == T_Button.Ins._numText[4].text &&
                    op._numText[5].text == T_Button.Ins._numText[5].text &&
                    op._numText[6].text == T_Button.Ins._numText[6].text &&
                    op._numText[7].text == T_Button.Ins._numText[7].text &&
                    op._numText[8].text == T_Button.Ins._numText[8].text &&
                    op._numText[9].text == T_Button.Ins._numText[9].text)
                {

                    if (_ordernum >= 1)
                    {
                        _Money += 1;
                        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                        //T_Game.Ins._class.fillAmount -= 0.10f;
                    }
                    
                    _Corderpaper.Remove(op.gameObject);
                    Destroy(op.gameObject);

                    T_Button.Ins.ResetNumText();
                    SoundManager.Ins.PlaySound(SoundManager.FxTypes.TearSound);

                    _Train += 1;
                    _TRAINNUM.text = _Train.ToString();
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
        GameObject CorderPrefab = Resources.Load("C_Train Paper") as GameObject;

        Transform parent = GameObject.Find("OrderPaper").transform;

        int childCount = parent.childCount;

        _Ins = Instantiate(CorderPrefab, _order, Quaternion.identity, parent);
        _Ins.gameObject.name = "C_Train Paper_" + childCount;
        _Ins.transform.SetAsFirstSibling();

        _Corderpaper.Add(_Ins);

        GameObject Level = _Ins.transform.Find("number").gameObject;

        _ordertext = Level.GetComponent<Text>() as Text;

        _ordernum += 1;
        _ordertext.text = _ordernum.ToString();

        T_OrderPaper paper = _Ins.GetComponent<T_OrderPaper>();
        paper._orderNum = _ordernum;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Memory : MonoBehaviour
{
    private static Memory _instance;

    public static Memory Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Memory>();
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
    public int _BESTMemory;
    public int _Memory;
    public int _Combo;

    public Text _ORDERNUM;
    public Text _BESTMEMORYNUM;
    public Text _MEMORYNUM;
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
        _BESTMemory = PlayerPrefs.GetInt("Memory", 0);

        InvokeRepeating("New", 1f, 2.5f);
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
        _BESTMEMORYNUM.text = "" + _BESTMemory;
        _MEMORYNUM.text = "" + _Memory;
        _ComboText.text = "" + _Combo;

        if (_Memory > _BESTMemory)
        {
            _BESTMemory = _Memory;
        }

        if (M_Game.Ins._openbell == true)
        {
            if (M_Game.Ins._pause == false)
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
            second();
        }
    }
    void ClassSpeed()
    {
        if (_ordernum >= 1)
        {
            M_Game.Ins._class.fillAmount += 0.00025f;
        }
    }

    void second()
    {
        for (int i = 0; i < _Corderpaper.Count; i++)
        {
            M_OrderPaper paper = _Corderpaper[i].GetComponent<M_OrderPaper>();

            if (paper._s > 2.9f)
            {
                paper._memory.SetActive(true);

                paper._s = 0;
            }

        }
    }

    void Speed()
    {
        for (int i = 0; i < _Corderpaper.Count; i++)
        {
            M_OrderPaper paper = _Corderpaper[i].GetComponent<M_OrderPaper>();

            if (paper._orderNum >= 1)
            {
                _Corderpaper[i].transform.Translate(Vector2.right * 110 * Time.deltaTime);
            }
            
        }
    }

    public void OnFinishBtn()
    {
        Same();
        M_Button.Ins.Done();

        M_Button.Ins._BunDown.sprite = M_Button.Ins._BDown;
        M_Button.Ins._BunUp.sprite = M_Button.Ins._BDown;

        if (_wrong == false)
        {
            //_Money -= 5;
            _Reward.text = "" + string.Format("{0:#,###0}", _Money);
            M_Game.Ins._class.fillAmount += 0.05f;
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
        M_OrderPaper op = null;
        foreach (GameObject opObj in _Corderpaper)
        {
            op = opObj.GetComponent<M_OrderPaper>();
            if (op != null)
            {
                if (op._numText[0].text == M_Button.Ins._numText[0].text &&
                    op._numText[1].text == M_Button.Ins._numText[1].text &&
                    op._numText[2].text == M_Button.Ins._numText[2].text &&
                    op._numText[3].text == M_Button.Ins._numText[3].text &&
                    op._numText[4].text == M_Button.Ins._numText[4].text &&
                    op._numText[5].text == M_Button.Ins._numText[5].text &&
                    op._numText[6].text == M_Button.Ins._numText[6].text &&
                    op._numText[7].text == M_Button.Ins._numText[7].text &&
                    op._numText[8].text == M_Button.Ins._numText[8].text &&
                    op._numText[9].text == M_Button.Ins._numText[9].text)
                {
                    if (_ordernum >= 1)
                    {
                        _Money += 1;
                        _Reward.text = "" + string.Format("{0:#,###0}", _Money);
                        M_Game.Ins._class.fillAmount -= 0.10f;
                    }
                    
                    _Corderpaper.Remove(op.gameObject);
                    Destroy(op.gameObject);

                    M_Button.Ins.ResetNumText();
                    SoundManager.Ins.PlaySound(SoundManager.FxTypes.TearSound);

                    _Memory += 1;
                    _MEMORYNUM.text = _Memory.ToString();
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
        GameObject CorderPrefab = Resources.Load("C_Memory Paper") as GameObject;

        Transform parent = GameObject.Find("OrderPaper").transform;

        int childCount = parent.childCount;

        _Ins = Instantiate(CorderPrefab, _order, Quaternion.identity, parent);
        _Ins.gameObject.name = "C_Memory Paper" + childCount;

        _Corderpaper.Add(_Ins);

        GameObject Level = _Ins.transform.Find("number").gameObject;

        _ordertext = Level.GetComponent<Text>() as Text;

        _ordernum += 1;
        _ordertext.text = _ordernum.ToString();

        M_OrderPaper paper = _Ins.GetComponent<M_OrderPaper>();
        paper._orderNum = _ordernum;
    }
}

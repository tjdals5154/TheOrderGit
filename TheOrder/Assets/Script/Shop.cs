using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private static Shop _instance;

    public static Shop Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Shop>();
                if (null == _instance)
                {

                }
            }
            return _instance;
        }
    }
    public GameObject _Scrollbar;
    public float _ScrollPos = 0;
    float[] _Pos;
    int _Posisi = 0;

    int _Money;
    public Text _MoneyT;

    bool _off;
    bool _not;
    public bool _reset;

    bool _buy2;
    bool _buy3;
    bool _buy4;
    bool _buy5;
    bool _buy6;

    int _keep2;
    int _keep3;
    int _keep4;
    int _keep5;
    int _keep6;

    public GameObject _Green;

    public GameObject _Cover2;
    public GameObject _Cover3;
    public GameObject _Cover4;
    public GameObject _Cover5;
    public GameObject _Cover6;
    // Start is called before the first frame update
    void Start()
    {
        _Green.SetActive(false);
        _off = true;
        _Money = PlayerPrefs.GetInt("Money", 0);
        _MoneyT.text = "" + string.Format("{0:#,###0}", _Money);
    }

    public void next()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        if (_Posisi < _Pos.Length - 1)
        {
            _not = false;
            _Posisi += 1;
            _ScrollPos = _Pos[_Posisi];
            _off = true;
            _Green.SetActive(false);
        }
    }
    public void prev()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        if (_Posisi > 0)
        {
            _not = false;
            _Posisi -= 1;
            _ScrollPos = _Pos[_Posisi];
            _off = true;
            _Green.SetActive(false);
        }
    }

    public void OnBack()
    {
        SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
        Lobby.Ins._ShopBG.SetActive(false);

        if (_not == true)
        {
            MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[0];
            MusicManager.Ins.bgSource.Play();
            MusicManager.Ins._BGMint = 0;
            PlayerPrefs.SetInt("BGM", MusicManager.Ins._BGMint);

            _not = false;
        }
    }

    public void OnBuy()
    {
        if (_Posisi == 1)
        {
            SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
            _Money -= 3000;
            _MoneyT.text = "" + string.Format("{0:#,###0}", _Money);
            PlayerPrefs.SetInt("Money", _Money);
            _Green.SetActive(false);
            _Cover2.SetActive(false);

            _keep2 = 1;
            PlayerPrefs.SetInt("BGM1", _keep2);
            _not = false;
        }
        if (_Posisi == 2)
        {
            SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
            _Money -= 3500;
            _MoneyT.text = "" + string.Format("{0:#,###0}", _Money);
            PlayerPrefs.SetInt("Money", _Money);
            _Green.SetActive(false);
            _Cover3.SetActive(false);

            _keep3 = 1;
            PlayerPrefs.SetInt("BGM2", _keep3);
            _not = false;
        }
        if (_Posisi == 3)
        {
            SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
            _Money -= 4000;
            _MoneyT.text = "" + string.Format("{0:#,###0}", _Money);
            PlayerPrefs.SetInt("Money", _Money);
            _Green.SetActive(false);
            _Cover4.SetActive(false);

            _keep4 = 1;
            PlayerPrefs.SetInt("BGM3", _keep4);
            _not = false;
        }
        if (_Posisi == 4)
        {
            SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
            _Money -= 4500;
            _MoneyT.text = "" + string.Format("{0:#,###0}", _Money);
            PlayerPrefs.SetInt("Money", _Money);
            _Green.SetActive(false);
            _Cover5.SetActive(false);

            _keep5 = 1;
            PlayerPrefs.SetInt("BGM4", _keep5);
            _not = false;
        }
        if (_Posisi == 5)
        {
            SoundManager.Ins.PlaySound(SoundManager.FxTypes.ButtonSound);
            _Money -= 5000;
            _MoneyT.text = "" + string.Format("{0:#,###0}", _Money);
            PlayerPrefs.SetInt("Money", _Money);
            _Green.SetActive(false);
            _Cover6.SetActive(false);

            _keep6 = 1;
            PlayerPrefs.SetInt("BGM5", _keep6);
            _not = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        _keep2 = PlayerPrefs.GetInt("BGM1");
        if (_keep2 == 1)
        {
            _buy2 = true;
            _Cover2.SetActive(false);
        }
        _keep3 = PlayerPrefs.GetInt("BGM2");
        if (_keep3 == 1)
        {
            _buy3 = true;
            _Cover3.SetActive(false);
        }
        _keep4 = PlayerPrefs.GetInt("BGM3");
        if (_keep4 == 1)
        {
            _buy4 = true;
            _Cover4.SetActive(false);
        }
        _keep5 = PlayerPrefs.GetInt("BGM4");
        if (_keep5 == 1)
        {
            _buy5 = true;
            _Cover5.SetActive(false);
        }
        _keep6 = PlayerPrefs.GetInt("BGM5");
        if (_keep6 == 1)
        {
            _buy6 = true;
            _Cover6.SetActive(false);
        }

        
        _Pos = new float[transform.childCount];
        float distance = 1f / (_Pos.Length -1f);
        for (int i = 0; i < _Pos.Length; i++)
        {
            _Pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            _ScrollPos = _Scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < _Pos.Length; i++)
            {
                if (_ScrollPos < _Pos[i] + (distance / 2) && _ScrollPos > _Pos[i] - (distance / 2))
                {
                    _Scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(_Scrollbar.GetComponent<Scrollbar>().value, _Pos[i], 0.15f);
                    _Posisi = i;
                }
            }
        }
        if (_Posisi == 0)
        {
            if (_off == true)
            {
                MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[0];
                MusicManager.Ins.bgSource.Play();
                MusicManager.Ins._BGMint = 0;
                PlayerPrefs.SetInt("BGM", MusicManager.Ins._BGMint);

                _off = false;
            }
        }
        if (_Posisi == 1)
        {
            if (_off == true)
            {
                if (_Money >= 3000) // 돈이 있다
                {
                    if (_buy2 == true) // 돈이있고 이미 샀다
                    {
                        _Green.SetActive(false);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[1];
                        MusicManager.Ins.bgSource.Play();
                        MusicManager.Ins._BGMint = 1;
                        PlayerPrefs.SetInt("BGM", MusicManager.Ins._BGMint);

                        _keep2 = 1;
                        PlayerPrefs.SetInt("BGM1", _keep2);
                    }
                    else // 돈이 있고 아직 사지 않았다
                    {
                        _Green.SetActive(true);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[1];
                        MusicManager.Ins.bgSource.Play();
                        _not = true;
                    }
                }
                else // 돈이 없다
                {
                    if (_buy2 == true) // 돈이 없고 이미 샀다
                    {
                        _Green.SetActive(false);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[1];
                        MusicManager.Ins.bgSource.Play();
                        MusicManager.Ins._BGMint = 1;
                        PlayerPrefs.SetInt("BGM", MusicManager.Ins._BGMint);

                        _keep2 = 1;
                        PlayerPrefs.SetInt("BGM1", _keep2);
                    }
                    else // 돈이 없고 아직 사지 않았다
                    {
                        MusicManager.Ins.bgSource.Stop();
                        _not = true;
                    }
                    
                }    
                _off = false;
            }
        }
        if (_Posisi == 2)
        {
            if (_off == true)
            {
                if (_Money >= 3500)
                {
                    if (_buy3 == true)
                    {
                        _Green.SetActive(false);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[2];
                        MusicManager.Ins.bgSource.Play();
                        MusicManager.Ins._BGMint = 2;
                        PlayerPrefs.SetInt("BGM", MusicManager.Ins._BGMint);

                        _keep3 = 1;
                        PlayerPrefs.SetInt("BGM2", _keep3);
                    }
                    else
                    {
                        _Green.SetActive(true);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[2];
                        MusicManager.Ins.bgSource.Play();
                        _not = true;
                    }
                }
                else
                {
                    if (_buy3 == true)
                    {
                        _Green.SetActive(false);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[2];
                        MusicManager.Ins.bgSource.Play();
                        MusicManager.Ins._BGMint = 2;
                        PlayerPrefs.SetInt("BGM", MusicManager.Ins._BGMint);

                        _keep3 = 1;
                        PlayerPrefs.SetInt("BGM2", _keep3);
                    }
                    else
                    {
                        MusicManager.Ins.bgSource.Stop();
                        _not = true;
                    }

                }
                _off = false;
            }
        }
        if (_Posisi == 3)
        {
            if (_off == true)
            {
                if (_Money >= 4000)
                {
                    if (_buy4 == true)
                    {
                        _Green.SetActive(false);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[3];
                        MusicManager.Ins.bgSource.Play();
                        MusicManager.Ins._BGMint = 3;
                        PlayerPrefs.SetInt("BGM", MusicManager.Ins._BGMint);

                        _keep4 = 1;
                        PlayerPrefs.SetInt("BGM3", _keep4);
                    }
                    else
                    {
                        _Green.SetActive(true);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[3];
                        MusicManager.Ins.bgSource.Play();
                        _not = true;
                    }
                }
                else
                {
                    if (_buy4 == true)
                    {
                        _Green.SetActive(false);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[3];
                        MusicManager.Ins.bgSource.Play();
                        MusicManager.Ins._BGMint = 3;
                        PlayerPrefs.SetInt("BGM", MusicManager.Ins._BGMint);

                        _keep4 = 1;
                        PlayerPrefs.SetInt("BGM3", _keep4);
                    }
                    else
                    {
                        MusicManager.Ins.bgSource.Stop();
                        _not = true;
                    }

                }
                _off = false;
            }
        }
        if (_Posisi == 4)
        {
            if (_off == true)
            {
                if (_Money >= 4500)
                {
                    if (_buy5 == true)
                    {
                        _Green.SetActive(false);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[4];
                        MusicManager.Ins.bgSource.Play();
                        MusicManager.Ins._BGMint = 4;
                        PlayerPrefs.SetInt("BGM", MusicManager.Ins._BGMint);

                        _keep5 = 1;
                        PlayerPrefs.SetInt("BGM4", _keep5);
                    }
                    else
                    {
                        _Green.SetActive(true);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[4];
                        MusicManager.Ins.bgSource.Play();
                        _not = true;
                    }
                    
                }
                else
                {
                    if (_buy5 == true)
                    {
                        _Green.SetActive(false);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[4];
                        MusicManager.Ins.bgSource.Play();
                        MusicManager.Ins._BGMint = 4;
                        PlayerPrefs.SetInt("BGM", MusicManager.Ins._BGMint);

                        _keep5 = 1;
                        PlayerPrefs.SetInt("BGM4", _keep5);
                    }
                    else
                    {
                        MusicManager.Ins.bgSource.Stop();
                        _not = true;
                    }

                }
                _off = false;
            }
        }
        if (_Posisi == 5)
        {
            if (_off == true)
            {
                if (_Money >= 5000)
                {
                    if (_buy6 == true)
                    {
                        _Green.SetActive(false);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[5];
                        MusicManager.Ins.bgSource.Play();
                        MusicManager.Ins._BGMint = 5;
                        PlayerPrefs.SetInt("BGM", MusicManager.Ins._BGMint);

                        _keep6 = 1;
                        PlayerPrefs.SetInt("BGM5", _keep6);
                    }
                    else
                    {
                        _Green.SetActive(true);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[5];
                        MusicManager.Ins.bgSource.Play();
                        _not = true;
                    }
                    
                }
                else
                {
                    if (_buy6 == true)
                    {
                        _Green.SetActive(false);
                        MusicManager.Ins.bgSource.clip = MusicManager.Ins._BGM[5];
                        MusicManager.Ins.bgSource.Play();
                        MusicManager.Ins._BGMint = 5;
                        PlayerPrefs.SetInt("BGM", MusicManager.Ins._BGMint);

                        _keep6 = 1;
                        PlayerPrefs.SetInt("BGM5", _keep6);
                    }
                    else
                    {
                        MusicManager.Ins.bgSource.Stop();
                        _not = true;

                    }

                }
                _off = false;
            }
        }

    }
}

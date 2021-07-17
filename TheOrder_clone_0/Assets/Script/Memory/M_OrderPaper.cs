using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_OrderPaper : MonoBehaviour
{
    public int _orderNum = 0;

    public float _s = 0;
    public GameObject _memory;
    public GameObject _orderpaper;

    public Image[] _images;
    public Text[] _numText;

    public Text _PriceText;

    public List<int> _topping = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        _memory.SetActive(false);
        _topping.Clear();

        Level();

        for (int j = 0; j < _topping.Count; j++)
        {
            _numText[j].text = string.Format("{0}", _topping[j]).ToString();
            ImageChange(_topping[j], j);
        }
    }
    // Update is called once per frame
    void Update()
    {
        _s += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Side")
        {
            M_Game.Ins.vibOn();
            M_Game.Ins._class.fillAmount += 0.07f;
            Memory.Ins._Corderpaper.Remove(_orderpaper);
            Destroy(_orderpaper);

            //Memory.Ins._Money -= 7;
            Memory.Ins._Reward.text = "" + string.Format("{0:#,###0}", Memory.Ins._Money);
        }
    }

    void Level()
    {
        if (Memory.Ins._ordernum < 31)
        {
            for (int i = 0; i < 6; i++)
            {
                int h = 0;

                if (0 < i && i < 9)
                {
                    h = Random.Range(1, 5);
                }
                _topping.Add(h);
            }
            _topping.Add(0);
            _PriceText.text = 1.ToString();
        }
        else if (Memory.Ins._ordernum < 51)
        {
            for (int i = 0; i < 7; i++)
            {
                int h = 0;

                if (0 < i && i < 9)
                {
                    h = Random.Range(1, 5);
                }
                _topping.Add(h);
            }
            _topping.Add(0);
            _PriceText.text = 1.ToString();
        }
        else if (Memory.Ins._ordernum < 61)
        {
            for (int i = 0; i < 8; i++)
            {
                int h = 0;

                if (0 < i && i < 9)
                {
                    h = Random.Range(1, 5);
                }
                _topping.Add(h);
            }
            _topping.Add(0);
            _PriceText.text = 1.ToString();
        }
        else if (Memory.Ins._ordernum < 71)
        {
            for (int i = 0; i < 9; i++)
            {
                int h = 0;

                if (0 < i && i < 9)
                {
                    h = Random.Range(1, 5);
                }
                _topping.Add(h);
            }
            _topping.Add(0);
            _PriceText.text = 1.ToString();
        }
        else if (Memory.Ins._ordernum >= 71)
        {
            for (int i = 0; i < 9; i++)
            {
                int h = 0;

                if (0 < i && i < 9)
                {
                    h = Random.Range(1, 5);
                }
                _topping.Add(h);
            }
            _topping.Add(0);
            _PriceText.text = 1.ToString();
        }

    }

    void ImageChange(int a, int b)
    {
        if (a == 0)
        {
            _images[b].color = new Color(197 / 255f, 109 / 255f, 4 / 255f, 255 / 255f);
        }
        else if (a == 1)
        {
            _images[b].color = new Color(224 / 255f, 0 / 255f, 0 / 255f, 255 / 255f);
        }
        else if (a == 2)
        {
            _images[b].color = new Color(255 / 255f, 212 / 255f, 0 / 255f, 255 / 255f);
        }
        else if (a == 3)
        {
            _images[b].color = new Color(48 / 255f, 219 / 255f, 0 / 255f, 255 / 255f);
        }
        else if (a == 4)
        {
            _images[b].color = new Color(99 / 255f, 0 / 255f, 17 / 255f, 255 / 255f);
        }
        else if (a == 5)
        {
            _images[b].color = new Color(197 / 255f, 109 / 255f, 4 / 255f, 255 / 255f);
        }
    }


}

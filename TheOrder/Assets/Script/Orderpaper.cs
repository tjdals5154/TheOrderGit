using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orderpaper : MonoBehaviour
{
    public int _orderNum = 0;

    public GameObject _orderpaper;
    public Image[] _images;
    public Text[] _numText;

    public Text _PriceText;

    public List<int> _topping = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
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

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Side")
        {
            Game.Ins.vibOn();
            Game.Ins._class.fillAmount += 0.07f;
            OrderShow.Ins._Corderpaper.Remove(_orderpaper);
            Destroy(_orderpaper);

            OrderShow.Ins._Money -= 7;
            OrderShow.Ins._Reward.text = "" + string.Format("{0:#,###0}", OrderShow.Ins._Money);

        }
    }

    void Level()
    {
        if (OrderShow.Ins._ordernum < 11)
        {
            for (int i = 0; i < 4; i++)
            {
                int h = 0;

                if (0 < i && i < 9)
                {
                    h = Random.Range(1, 5);
                }
                _topping.Add(h);
            }
            _topping.Add(0);
            _PriceText.text = 3.ToString();
        }
        else if (OrderShow.Ins._ordernum < 31)
        {
            for (int i = 0; i < 5; i++)
            {
                int h = 0;

                if (0 < i && i < 9)
                {
                    h = Random.Range(1, 5);
                }
                _topping.Add(h);
            }
            _topping.Add(0);
            _PriceText.text = 5.ToString();
        }
        else if (OrderShow.Ins._ordernum < 51)
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
            _PriceText.text = 7.ToString();
        }
        else if (OrderShow.Ins._ordernum < 71)
        {
            for (int i = 0; i < 9; i++)
            {
                int h = 0;

                if (0 < i && i < 9)
                {
                    h = Random.Range(1, 6);
                }
                _topping.Add(h);
            }
            _topping.Add(0);
            _PriceText.text = 10.ToString();
        }
        else if (OrderShow.Ins._ordernum < 91)
        {
            for (int i = 0; i < 9; i++)
            {
                int h = 0;

                if (0 < i && i < 9)
                {
                    h = Random.Range(1, 6);
                }
                _topping.Add(h);
            }
            _topping.Add(0);
            _PriceText.text = 12.ToString();
        }
        else if (OrderShow.Ins._ordernum >= 91)
        {
            for (int i = 0; i < 9; i++)
            {
                int h = 0;

                if (0 < i && i < 9)
                {
                    h = Random.Range(1, 6);
                }
                _topping.Add(h);
            }
            _topping.Add(0);
            _PriceText.text = 12.ToString();
        }
    }

    void ImageChange(int a, int b)
    {
        if(a == 0)
        {
            _images[b].color = new Color(197 / 255f, 109 / 255f, 4 / 255f, 255 / 255f);
        }
        else if(a == 1)
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

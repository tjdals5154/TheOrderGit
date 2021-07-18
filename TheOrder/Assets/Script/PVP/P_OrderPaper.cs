using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class P_OrderPaper : NetworkBehaviour
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

       


    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Side")
        {
            P_Game.Ins.vibOn();
            //P_Game.Ins._class.fillAmount += 0.07f;
            PVP.Ins._Corderpaper.Remove(_orderpaper);
            Destroy(_orderpaper);

            //PVP.Ins._Money -= 7;
            //PVP.Ins._Reward.text = "" + string.Format("{0:#,###0}", PVP.Ins._Money);
            //P_Game.Ins._class.fillAmount = 1;
            //P_Game.Ins.Over();
        }
    }

    public void Level(List<int> randomList)
    {
        string tempStr = "";
        foreach (int i in randomList)
            tempStr += i.ToString() + " ";

        Debug.Log("[Client] randomList: " + tempStr);

        //if (PVP.Ins._ordernum >= 1)
        {
            _topping.AddRange(randomList);
            _topping.Add(0);
            _PriceText.text = 0.ToString();

            for (int j = 0; j < _topping.Count; j++)
            {
                _numText[j].text = string.Format("{0}", _topping[j]).ToString();
                ImageChange(_topping[j], j);
            }
        }


    }


    public void ImageChange(int a, int b)
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

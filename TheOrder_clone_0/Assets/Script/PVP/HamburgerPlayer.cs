using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class HamburgerPlayer : NetworkBehaviour
{
    private static HamburgerPlayer _instance;

    public static HamburgerPlayer Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<HamburgerPlayer>();
                if (null == _instance)
                {

                }
            }
            return _instance;
        }
    }
    

    [SyncVar]
    public int _Win;

    [SyncVar]
    public string playerName;

    void Start()
    {

        Canvas canvas = FindObjectOfType<Canvas>();
        
        NetworkIdentity netId = GetComponent<NetworkIdentity>();

        if (netId.hasAuthority)
        {
            netId.gameObject.name = "Hamburger";
            
        }
        else
        {
            netId.gameObject.name = "Hamburger2";
        }

        netId.transform.parent = canvas.transform;


        if (isLocalPlayer)
        {
            _Win = PlayerPrefs.GetInt("Win", 0);
        }

        if (isLocalPlayer)
        {
            playerName = PlayerPrefs.GetString("Sign");
        }

        P_Game.Ins.ShName();
        P_Game.Ins.ShowPlayerName();
        P_Game.Ins.WL();

        if (isServer && netId.gameObject.name == "Hamburger")
        {
           StartCoroutine(NewOrder());
        }
    }

    bool newOrderStarted = false;
    IEnumerator NewOrder()
    {
        if (newOrderStarted == false)
        {
            newOrderStarted = true;

            yield return new WaitForSeconds(5.0f);

            List<int> toppings = new List<int>();

            while (true)
            {
                toppings.Clear();

                for (int i = 0; i < 5; i++)
                {
                    int h = 0;

                    if (0 < i && i < 9)
                    {
                        h = Random.Range(1, 5);
                    }
                    toppings.Add(h);
                }

                Debug.Log("[Server] Generate Random Toppings");

                RpcNewOrder(toppings);

                yield return new WaitForSeconds(2.5f);
            }
        }
    }

    [ClientRpc]
    void RpcNewOrder(List<int> list)
    {
        PVP.Ins.New(list);
    }

    [Command]
    public void Over()
    {
        OverRPC();

    }
    [ClientRpc]
    public void OverRPC()
    {
        if (isLocalPlayer)
        {
            P_Game.Ins._class.fillAmount = 1;
            PVP.Ins.LoseL();
        }
        else
        {
            P_Game.Ins._class.fillAmount = 1;
            PVP.Ins.LoseNL();
        }
    }


    [Command]
    public void PVPBTn()
    {
        PVPRPC();
    }
    [ClientRpc]
    public void PVPRPC()
    {
        if (isLocalPlayer)
        {
            PVP.Ins.PVPScore();
        }
        else
        {
            PVP.Ins.PVPScore2();
        }
    }
    
    [Command]
    public void Done()
    {
        DoneRPC();
    }
    [ClientRpc]
    public void DoneRPC()
    {
        if (isLocalPlayer)
        {
            P_Button.Ins._Done();
            
        }
        else
        {
            P_Button.Ins._Done2();
        }
    }
    [Command]
    public void OnBun()
    {
        OnBunRPC();
    }
    [ClientRpc]
    public void OnBunRPC()
    {
        if (isLocalPlayer)
        {
            P_Button.Ins._OnBun();
        }
        else
        {
            P_Button.Ins.B();
        }
    }

    [Command]
    public void OnTomato()
    {
        OnTomatoRPC();
    }
    [ClientRpc]
    public void OnTomatoRPC()
    {
        if (isLocalPlayer)
        {
            P_Button.Ins._OnTomato();
        }
        else
        {
            P_Button.Ins.T();
        }
    }

    [Command]
    public void OnCheese()
    {
        OnCheeseRPC();
    }
    [ClientRpc]
    public void OnCheeseRPC()
    {
        if (isLocalPlayer)
        {
            P_Button.Ins._OnCheese();
        }
        else
        {
            P_Button.Ins.C();
        }
    }

    [Command]
    public void OnLettuce()
    {
        OnLettuceRPC();
    }
    [ClientRpc]
    public void OnLettuceRPC()
    {
        if (isLocalPlayer)
        {
            P_Button.Ins._OnLettuce();
        }
        else
        {
            P_Button.Ins.L();
        }
    }

    [Command]
    public void OnMeat()
    {
        OnMeatRPC();
    }
    [ClientRpc]
    public void OnMeatRPC()
    {
        if (isLocalPlayer)
        {
            P_Button.Ins._OnMeat();
        }
        else
        {
            P_Button.Ins.M();
        }
    }

    [Command]
    public void OnMiddelbun()
    {
        OnMiddelbunRPC();
    }
    [ClientRpc]
    public void OnMiddelbunRPC()
    {
        if (isLocalPlayer)
        {
            P_Button.Ins._OnMiddelbun();
        }
        else
        {
            P_Button.Ins.MB();
        }
    }

}

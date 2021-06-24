using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class HamburgerPlayer : NetworkBehaviour
{
    //int count = 0;
    void Start()
    {
        // 네트워크 플레이어(로드된 햄버거 프리팹)를 찾아서 Canvas 자식 객체로 만들어주기
        // NetworkIdentity 

        Canvas canvas = FindObjectOfType<Canvas>();

        NetworkIdentity netId = GetComponent<NetworkIdentity>();

        if (netId.hasAuthority)
        {
            netId.gameObject.name = "Hamburger";
            
        }
        else
        {
            netId.gameObject.name = "Hamburger";
        }

        netId.transform.parent = canvas.transform;
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
            Debug.Log("onbunrpc");
        }
        
        
    }
    
    
}

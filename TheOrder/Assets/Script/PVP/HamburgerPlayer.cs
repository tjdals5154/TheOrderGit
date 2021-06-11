using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class HamburgerPlayer : MonoBehaviour
{
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
            netId.gameObject.name = "Player2";
        }

        netId.transform.parent = canvas.transform;


    }
}

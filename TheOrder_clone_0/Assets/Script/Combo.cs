using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    private static Combo _instance;

    public static Combo Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Combo>();
                if (null == _instance)
                {

                }
            }
            return _instance;
        }
    }
    public Animator _animator;
    // Start is called before the first frame update

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;

    public static MusicManager Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MusicManager>();
                if (null == _instance)
                {

                }
            }
            return _instance;
        }
    }

    public GameObject _MusicManager;
    public AudioSource bgSource;
    public AudioClip[] _BGM;

    public int _BGMint;

    void Start()
    {
        DontDestroyOnLoad(_MusicManager);
        _MusicManager = GameObject.Find("MusicManager");
        bgSource = _MusicManager.GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("BGM"))
        {
            _BGMint = PlayerPrefs.GetInt("BGM");
            bgSource.clip = _BGM[_BGMint];
            bgSource.Play();
        }
        else if(!PlayerPrefs.HasKey("BGM"))
        {
            bgSource.clip = _BGM[0];
            bgSource.Play();
        }
    }

}

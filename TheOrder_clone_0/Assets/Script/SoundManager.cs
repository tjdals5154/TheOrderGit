using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public static SoundManager Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();
                if (null == _instance)
                {

                }
            }
            return _instance;
        }
    }
    public GameObject _Timer;
    public AudioSource TimerSource;
    public AudioSource fxSource;
    public AudioClip
            _BellSound,
            _BellFSound,
            _ShutterSound,
            _TearSound,
            _ButtonSound,
            _BunBtn,
            _Lettuce,
            _Cheese,
            _Meat,
            _Tomato,
            _Printer,
            _Paper;

    public void PlaySound(FxTypes fxTypes)
    {
        switch (fxTypes)
        {
            case FxTypes.BellSound:
                fxSource.PlayOneShot(_BellSound);
                break;
            case FxTypes.BellFSound:
                fxSource.PlayOneShot(_BellFSound);
                break;
            case FxTypes.ShutterSound:
                fxSource.PlayOneShot(_ShutterSound);
                break;
            case FxTypes.TearSound:
                fxSource.PlayOneShot(_TearSound);
                break;
            case FxTypes.ButtonSound:
                fxSource.PlayOneShot(_ButtonSound);
                break;
            case FxTypes.BunBtn:
                fxSource.PlayOneShot(_BunBtn);
                break;
            case FxTypes.LettuceBtn:
                fxSource.PlayOneShot(_Lettuce);
                break;
            case FxTypes.Cheese:
                fxSource.PlayOneShot(_Cheese);
                break;
            case FxTypes.Meat:
                fxSource.PlayOneShot(_Meat);
                break;
            case FxTypes.Tomato:
                fxSource.PlayOneShot(_Tomato);
                break;
            case FxTypes.Printer:
                fxSource.PlayOneShot(_Printer);
                break;
            case FxTypes.Paper:
                fxSource.PlayOneShot(_Paper);
                break;
        }

    }
    public enum FxTypes
    {
        BellSound,
        BellFSound,
        ShutterSound,
        TearSound,
        ButtonSound,
        BunBtn,
        LettuceBtn,
        Cheese,
        Meat,
        Tomato,
        Printer,
        Paper
    }

    
}

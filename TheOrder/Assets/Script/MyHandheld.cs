using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MyHandheld
{
    public static void Vibrate()
    {
#if UNITY_STANDALONE

#else
        //Handheld.Vibrate();

#endif
    }
}


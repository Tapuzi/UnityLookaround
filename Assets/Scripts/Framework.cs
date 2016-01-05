using UnityEngine;
using System.Collections;
using System;

[Serializable]
public static class Framework
{
    public static Quaternion Calibration;
    public static bool RunningOnPc()
    {
        if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
            return true;
        return false;
    }
    
}

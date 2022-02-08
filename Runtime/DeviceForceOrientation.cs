using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AS.SetDeviceOrientation
{

    public class DeviceForceOrientation
    {
        static bool isTablet(DeviceForceOrientationSettings settings)
        {

#if UNITY_EDITOR
            return true;
#elif UNITY_IOS
            return SystemInfo.deviceModel.Contains("iPad");
#else
            return (Mathf.Sqrt(Screen.width * Screen.width + Screen.height * Screen.height) / Screen.dpi) > settings.tabletInch;
#endif
        }

        [RuntimeInitializeOnLoadMethod]
        static void SetDeviceOrientation()
        {
            DeviceForceOrientationSettings settings = Resources.Load("DeviceOrientation") as DeviceForceOrientationSettings;
            if (!settings)
                return;

            if (isTablet(settings))
            {
                Debug.Log("Set tablet orientation");
                Screen.autorotateToLandscapeLeft = settings.tabletLandscapeLeft;
                Screen.autorotateToLandscapeRight = settings.tabletLandscapeRight;
                Screen.autorotateToPortrait = settings.tabletPortrait;
                Screen.autorotateToPortraitUpsideDown = settings.tabletPortraitUpsideDown;
            }
            else
            {
                Debug.Log("Set mobile orientation");
                Screen.autorotateToLandscapeLeft = settings.mobileLandscapeLeft;
                Screen.autorotateToLandscapeRight = settings.mobileLandscapeRight;
                Screen.autorotateToPortrait = settings.mobilePortrait;
                Screen.autorotateToPortraitUpsideDown = settings.mobilePortraitUpsideDown;
            }
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
}

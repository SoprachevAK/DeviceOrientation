using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AS.SetDeviceOrientation
{
    // [CreateAssetMenu(fileName = "DeviceForceOrientation", menuName = "Settings/DeviceForceOrientation", order = 0)]
    public class DeviceForceOrientationSettings : ScriptableObject
    {
        [Header("Phone")]
        public bool mobileLandscapeLeft = false;
        public bool mobileLandscapeRight = false;
        public bool mobilePortrait = true;
        public bool mobilePortraitUpsideDown = true;

        [Header("Tablet")]
        public bool tabletLandscapeLeft = true;
        public bool tabletLandscapeRight = true;
        public bool tabletPortrait = true;
        public bool tabletPortraitUpsideDown = true;

        [Space]
        [Tooltip("Only to determinate tablet on Android. iPad detected automaticly")]
        [Range(0f, 10f)]
        public float tabletInch = 6.1f;
    }
}

#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace AS.SetDeviceOrientation
{
    public class OpenSettings : IPreprocessBuildWithReport
    {
        int IOrderedCallback.callbackOrder => -100;


        void IPreprocessBuildWithReport.OnPreprocessBuild(BuildReport report)
        {
            var settings = Resources.Load("DeviceOrientation");
            if (!settings)
            {
                bool create = EditorUtility.DisplayDialog("Device Orientation", "Can not find settings file.", "Create", "Cancel");
                if (create)
                {
                    settings = CreateSettingsAsset();
                    Selection.activeObject = settings;
                    EditorGUIUtility.PingObject(settings);
                    throw new UnityEditor.Build.BuildFailedException("Build was canceled to create DeviceOrientation settings");
                }

            }
        }

        [MenuItem("AS/Device Orientation Settings")]
        public static void Open()
        {
            var settings = Resources.Load("DeviceOrientation");
            if (!settings)
            {
                settings = CreateSettingsAsset();
            }
            Selection.activeObject = settings;
            EditorGUIUtility.PingObject(settings);
        }

        public static DeviceForceOrientationSettings CreateSettingsAsset()
        {
            var path = EditorUtility.SaveFilePanel("Save settings asset", "Assets/", "Settings", "");

            var dir = Path.GetDirectoryName(path);
            if (Directory.Exists(dir))
            {
                dir = dir.Replace(Application.dataPath, "Assets");

                if (!dir.Split(Path.DirectorySeparatorChar).Contains("Resources"))
                {
                    dir = Path.Combine(dir, "Resources");
                    Directory.CreateDirectory(dir);
                }

                DeviceForceOrientationSettings asset = ScriptableObject.CreateInstance<DeviceForceOrientationSettings>();
                AssetDatabase.CreateAsset(asset, Path.Combine(dir, "DeviceOrientation.asset"));
                AssetDatabase.SaveAssets();

                EditorUtility.FocusProjectWindow();
                return asset;
            }
            return null;
        }

    }
}

#endif

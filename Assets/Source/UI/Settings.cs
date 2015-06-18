using UnityEngine;
using System.Collections;
 
public class Settings : MonoBehaviour {
    public enum SettingsType {
        LEVEL,
        ANTIALIASING,
        TRIPLE_BUFFER,
        ANISOTROPIC,
        RESOLUTION,
        FREQUENCY,
        VSYNC,
    };

    public static void Set(SettingsType type, int data){
        switch(type){
            case SettingsType.LEVEL:
                QualitySettings.SetQualityLevel(data);
                break;
            case SettingsType.ANTIALIASING:
                //0- None, 2- 2xAA, 4- 4xAA, 8- 8xAA
                QualitySettings.antiAliasing = data;
                break;
            default:
                Debug.LogWarning("Incorrect Settings argument.");
                break;
        }
    }

    public static void Set(SettingsType type, bool data) {
        switch (type) {
            case SettingsType.ANISOTROPIC:
                QualitySettings.anisotropicFiltering = data? AnisotropicFiltering.ForceEnable : AnisotropicFiltering.Disable;
                break;
            case SettingsType.TRIPLE_BUFFER:
                QualitySettings.maxQueuedFrames = data? 3 : 0;
                break;
            case SettingsType.VSYNC:
                QualitySettings.vSyncCount = data?1:0;
                break;
            default:
                Debug.LogWarning("Incorrect Settings argument.");
                break;
        }
    }

    public static void SetResolution(Vector2 resolution, bool fullScreen, int frequency) {
        Screen.SetResolution((int)resolution.x, (int)resolution.y, fullScreen, frequency);
    }

    public static Resolution[] GetResolutions() {
        return Screen.resolutions;
    }
}
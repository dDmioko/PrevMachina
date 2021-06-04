using UnityEditor;
using UnityEngine;

/// <summary>
/// Get version
/// </summary>
public class Version
{
    private const string REPOSITORY_LINK = "https://github.com/ip613s07/ModuleBallistics/releases/tag/";
    private const string VERSION = "1.0.0";

    [MenuItem("ModuleBallistics/GetVersion/" + VERSION)]
    public static void GetVersion() 
    { 
        Application.OpenURL(REPOSITORY_LINK + VERSION);
    }
}

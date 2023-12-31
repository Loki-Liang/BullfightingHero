using UnityEditor;
using System.IO;
public class AssetBuldle : Editor
{
    [MenuItem("Tools/CreateAssetBundle for Android")]
  
    static void CreateAssetBundle()
    {

        string path = "Assets/StreamingAssets";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.Android);
        UnityEngine.Debug.Log("Android Finish!");
    }

    [MenuItem("Tools/CreateAssetBundle for IOS")]
    static void BuildAllAssetBundlesForIOS()
    {
        string dirName = "AssetBundles/IOS";
        if (!Directory.Exists(dirName))
        {
            Directory.CreateDirectory(dirName);
        }
        BuildPipeline.BuildAssetBundles(dirName, BuildAssetBundleOptions.CollectDependencies, BuildTarget.iOS);
        UnityEngine.Debug.Log("IOS Finish!");

    }


    [MenuItem("Tools/CreateAssetBundle for Win")]
    static void CreatPCAssetBundleForwINDOWS()
    {
        string path = "AB";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        UnityEngine.Debug.Log("Windows Finish!");
    }
}
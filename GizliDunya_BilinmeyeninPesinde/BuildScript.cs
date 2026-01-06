using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class BuildScript
{
    [MenuItem("Tools/Build Game")]
    public static void BuildGame()
    {
        // Get the path to build the game to
        string buildPath = EditorUtility.OpenFolderPanel("Build Location", "", "");
        if (string.IsNullOrEmpty(buildPath))
        {
            Debug.LogError("Build cancelled - no path selected");
            return;
        }

        // Define scenes to build
        List<string> scenes = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                scenes.Add(scene.path);
            }
        }

        if (scenes.Count == 0)
        {
            Debug.LogError("No scenes enabled for build");
            return;
        }

        // Build player options
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = scenes.ToArray();
        buildPlayerOptions.locationPathName = buildPath + "/GizliDunya.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;

        // Start the build process
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.LogError("Build failed");
        }
    }
    
    [MenuItem("Tools/Set Build Scenes")]
    public static void SetBuildScenes()
    {
        EditorBuildSettingsScene[] scenes = {
            new EditorBuildSettingsScene("Assets/Scenes/Level1_AmazonJungle.unity", true),
            new EditorBuildSettingsScene("Assets/Scenes/Level2_Atlantis.unity", true)
        };
        
        EditorBuildSettings.scenes = scenes;
        Debug.Log("Build scenes set!");
    }
}
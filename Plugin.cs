using BepInEx;
using BepInEx.Configuration;
using Receiver2;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;
using System.Linq;
using System;

namespace GunSceneReenabler
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<string> load_key;
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            load_key = Config.Bind("Activation Key", "Load key", "l", "This is the key that will let you load into the Gun Explosion Scene");
        }
        internal void Update()
        {
            Scene scene = SceneManager.GetActiveScene();
            if (load_key.Value != "")
            {
                if (Input.GetKeyDown(load_key.Value))
                {
                    SceneManager.UnloadSceneAsync(scene); //unity's mad but we need to do this I'm pretty sure otherwise the game just throws up errors like me after christmas eve (NOT GOOD!)
                    SceneManager.UnloadSceneAsync("Receiver2BaseScene"); //unity's mad but we need to do this I'm pretty sure otherwise the game just throws up errors like me after christmas eve (NOT GOOD!)
                    SceneManager.LoadScene("GunExplosionScene");
                }
            }
            // Get build scenes
            /*
            var sceneNumber = SceneManager.sceneCountInBuildSettings;
            string[] arrayOfNames;
            arrayOfNames = new string[sceneNumber];
            for (int i = 0; i < sceneNumber; i++)
            {
                arrayOfNames[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                foreach(string name in arrayOfNames)
                {
                  Debug.Log(name);
                }
            }*/
        }
    }
}
using BepInEx;
using BepInEx.Logging;
using System.IO;
using System;
using UnityEngine;
using System.Reflection;
using Comfort.Common;
using EFT.UI;
using StashSearch.Config;
using StashSearch.Patches;

#pragma warning disable

namespace StashSearch
{
    [BepInPlugin("com.dirtbikercj.HardcoreUI", "HardcoreUI", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin? Instance;
        public static ManualLogSource Log;

        internal void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);

            Log = Logger;

            StashSearchConfig.InitConfig(Config);


            new ContainersPanelShowPatch().Enable();
           
        }
    }
}

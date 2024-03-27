using BepInEx;
using BepInEx.Logging;
using System.IO;
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

            new ContainersPanelShowPatch().Enable();
           
        }
    }
}

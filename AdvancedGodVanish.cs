using System.IO;
using JetBrains.Annotations;
using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;

namespace RedstonePlugins.AdvancedGodVanish
{
    public class AdvancedGodVanish : RocketPlugin<Configuration>
    {
        public static AdvancedGodVanish Instance;


        public override TranslationList DefaultTranslations => new TranslationList
        {
            {
                "god_turned_on","{0} has turned on the god mode for the player {1}"
            },
            {
                "god_turned_off","{0} has turned off the god mode for the player {1}"
            },
            {
                "vanish_turned_on","{0} has turned on the vanish mode for the player {1}"
            },
            {
                "vanish_turned_off","{0} has turned off the vanish mode for the player {1}"
            },
            {
                "your_vanish_turned_on", "Your vanish mode has been turned on."
            },
            {
                "your_vanish_turned_off", "Your vanish mode has been turned off."
            },
            {
                "your_god_turned_on", "Your god mode has been turned on."
            },
            {
                "your_god_turned_off", "Your god mode has been turned off."
            }
        };

        [CanBeNull] public string CurrentDirectory = System.IO.Directory.GetCurrentDirectory() + "/..";
        protected override void Load()
        {
            Instance = this;
            if (!File.Exists(CurrentDirectory + "/GodVanishLog.txt"))
                File.CreateText(CurrentDirectory + "/GodVanishLog.txt");
            
            Logger.Log("Plugin loaded correctly! by educatalan02#1236");
            Logger.Log($"Version {Assembly.GetName().Version}");
        }

        protected override void Unload()
        {
            Instance = null;
        }
    }
}
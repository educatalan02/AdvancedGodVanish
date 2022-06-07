using System.Collections.Generic;
using System.IO;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;

namespace RedstonePlugins.AdvancedGodVanish.Commands
{
    public class CommandVanish : IRocketCommand
    {
        private string Directory => AdvancedGodVanish.Instance.CurrentDirectory;
        public void Execute(IRocketPlayer caller, string[] command)
        {
            var player = caller as UnturnedPlayer;
            if (player == null || command.Length != 0) return;
            using var writer = File.AppendText(Directory + "GodVanishLog.txt");
            if (player.VanishMode)
            {
                player.VanishMode = false;
                UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("your_vanish_turned_off"));
                writer.WriteLine(
                    $"[Vanish] {caller.DisplayName} {AdvancedGodVanish.Instance.Translate("your_vanish_turned_off")}");
            }
            else
            {
                player.VanishMode = true;
                UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("your_vanish_turned_on"));
                writer.WriteLine(
                    $"[Vanish] {caller.DisplayName} {AdvancedGodVanish.Instance.Translate("your_vanish_turned_on")}");
            }
        }

        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "vanish";
        public string Help => "Enables vanish mode";
        public string Syntax => "Syntax: /vanish";
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string>() { "vanish" };
    }
}
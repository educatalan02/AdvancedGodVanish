using System.Collections.Generic;
using System.IO;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;

namespace RedstonePlugins.AdvancedGodVanish.Commands
{
    public class CommandGod : IRocketCommand
    {
        private string Directory => AdvancedGodVanish.Instance.CurrentDirectory;
        public void Execute(IRocketPlayer caller, string[] command)
        {
            var player = caller as UnturnedPlayer;
            if (player == null || command.Length != 0) return;
            using var writer = File.AppendText(Directory + "GodVanishLog.txt");
            if (player.GodMode)
            {
                player.GodMode = false;
                UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("your_god_turned_off"));
                writer.WriteLine(
                    $"[God] {caller.DisplayName} {AdvancedGodVanish.Instance.Translate("your_god_turned_off")}");
            }
            else
            {
                player.GodMode = true;
                UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("your_god_turned_on"));
                writer.WriteLine(
                    $"[God] {caller.DisplayName} {AdvancedGodVanish.Instance.Translate("your_god_turned_on")}");
            }
        }

        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "god";
        public string Help => "Enables god mode";
        public string Syntax => "Syntax: /god";
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string>() { "god" };
    }
}
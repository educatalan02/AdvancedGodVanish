using System.Collections.Generic;
using System.IO;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;

namespace RedstonePlugins.AdvancedGodVanish.Commands
{
    public class CommandRemoteGod : IRocketCommand
    {
        private string Directory => AdvancedGodVanish.Instance.CurrentDirectory;
        public void Execute(IRocketPlayer caller, string[] command)
        {

            if (command.Length != 1)
            {
                UnturnedChat.Say(caller,Syntax);
                return;
            }
            var player = UnturnedPlayer.FromName(command[0]);
            if (player == null) return;
            
            using var writer = File.AppendText(Directory + "GodVanishLog.txt");
            if (player.GodMode)
            {
                player.GodMode = false;
                UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("god_turned_off", caller.DisplayName, player.DisplayName));
                writer.WriteLine(
                    $"[RemoteGod] {AdvancedGodVanish.Instance.Translate("god_turned_off", caller.DisplayName, player.DisplayName)}");
            }
            else
            {
                player.GodMode = true;
                UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("god_turned_on", caller.DisplayName, player.DisplayName));
                writer.WriteLine(
                    $"[RemoteGod] {caller.DisplayName} {AdvancedGodVanish.Instance.Translate("god_turned_on", caller.DisplayName, player.DisplayName)}");
            }
        }

        public AllowedCaller AllowedCaller => AllowedCaller.Both;
        public string Name => "remotegod";
        public string Help => "Enables god mode";
        public string Syntax => "Syntax: /god <Player>";
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string>() { "remotegod" };
    }
}
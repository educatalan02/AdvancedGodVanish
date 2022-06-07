using System.Collections.Generic;
using System.IO;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;

namespace RedstonePlugins.AdvancedGodVanish.Commands
{
    public class CommandRemoteVanish : IRocketCommand
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
            if (player.VanishMode)
            {
                player.VanishMode = false;
                UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("vanish_turned_off", caller.DisplayName, player.DisplayName));
                writer.WriteLine(
                    $"[RemoteGod] {AdvancedGodVanish.Instance.Translate("vanish_turned_off", caller.DisplayName, player.DisplayName)}");
            }
            else
            {
                player.VanishMode = true;
                UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("vanish_turned_on", caller.DisplayName, player.DisplayName));
                writer.WriteLine(
                    $"[RemoteGod] {caller.DisplayName} {AdvancedGodVanish.Instance.Translate("vanish_turned_on", caller.DisplayName, player.DisplayName)}");
            }
        }

        public AllowedCaller AllowedCaller => AllowedCaller.Both;
        public string Name => "remotevanish";
        public string Help => "Enables vanish mode";
        public string Syntax => "Syntax: /vanish <Player>";
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string>() { "remotevanish" };
    }
}
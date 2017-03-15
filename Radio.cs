using System;
using System.IO;
using UnityEngine;
using Rocket.API;
using Rocket.Unturned.Player;
using Rocket.Unturned;
using Rocket.Unturned.Commands;
using Rocket.Unturned.Chat;
using System.Collections.Generic;
using SDG.Unturned;
using Rocket.Core.Plugins;

namespace RPRadio
{
    public class RPRadio : IRocketCommand
    {


        public AllowedCaller AllowedCaller
        {
            get { return AllowedCaller.Both; }
        }

        public string Name
        {
            get { return "radio"; }
        }

        public string Help
        {
            get { return "Text-Based RP Radio."; }
        }

        public string Syntax
        {
            get { return "<Message>"; }
        }

        public List<string> Aliases
        {
            get { return new List<string>() { "rr" }; }
        }
        public void Execute(IRocketPlayer caller, params string[] command)
        {
            if (command.Length != 1)
            {
                UnturnedChat.Say(caller, Syntax, Color.red);
                return;
            }
            foreach (SteamPlayer p in Provider.clients)
            {
                UnturnedPlayer player = UnturnedPlayer.FromSteamPlayer(p);
                if (player.HasPermission("radio.allow"))
                {
                    UnturnedChat.Say(player, "[RADIO] " + caller.DisplayName + ": " + command[0], Color.red);
                }
            }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string>
              {
                  "radio.allow"
                };
            }
        }
    }
}
 
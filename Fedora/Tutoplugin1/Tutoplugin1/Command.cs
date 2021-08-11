using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System;

namespace Tutoplugin1
{
    internal class Command : IScript
    {
        public Command()
        {
            CommandHandler.RegisterCommand("nick", new Action<ShPlayer, string>(message), null, null);
        }

        public void message(ShPlayer player, string message)
        {
            ChatHandler.SendToAll(player.ID + " à changer son nom en " + message);
            player.svPlayer.SvUpdateDisplayName(message);
        }
    }
}
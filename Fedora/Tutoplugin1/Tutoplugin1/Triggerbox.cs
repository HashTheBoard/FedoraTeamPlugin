using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Required;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutoplugin1
{
    internal class Triggerbox
    {
        private List<ShPlayer> pd = new List<ShPlayer>();

        [CustomTarget]
        public void safezoneEnter(ShEntity trigger, ShPhysical physical)
        {
            if (physical is ShPlayer player)
            {
                if (!player.svPlayer.IsTargetValid())
                {
                    player.svPlayer.SendGameMessage("&2[SAFEZONE] you're in SafeZone");
                    player.svPlayer.StartCoroutine(entersfz(player));
                    pd.Add(player);
                }
            }
        }

        private IEnumerator entersfz(ShPlayer player)
        {
            player.svPlayer.StartJailTimer(5f);
            yield return new WaitForSecondsRealtime(5f);
            player.svPlayer.SendGameMessage("&2[SAFEZONE] you're in godmod now");
            player.svPlayer.godMode = true;
            
                yield break;
        }

        [CustomTarget]
        public void safezoneLeave(ShEntity trigger, ShPhysical physical)
        {
            if (physical is ShPlayer player)
            {
                if (!player.svPlayer.IsTargetValid())
                {
                    player.svPlayer.SendGameMessage("&4[SAFEZONE] you leaved the SafeZone");
                    player.svPlayer.StopCoroutine(entersfz(player));
                    player.svPlayer.StartJailTimer(0.4f);
                    player.svPlayer.godMode = false;
                    pd.Remove(player);
                }
            }
        }
    }
}
using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Required;
using System.Collections.Generic;
using BrokeProtocol.Managers;
using UnityEngine;

namespace Fedora  {
    class Debuglog : IScript
    {

        [Target(GameSourceEvent.PlayerDamage, ExecutionMode.Event)]
        public void OnDamage(ShPlayer player, DamageIndex damageIndex, float amount, ShPlayer attacker, Collider collider, float hitY)
        {
            switch(damageIndex)
            {
                case DamageIndex.Collision:
                    if (player.IsDriving)
                    {
                        Debug.Log($"[ FEDORA ] Le joueur {player.username} à fait un accident de la route !");
                    }
                    break;
                case DamageIndex.Gun:
                    Debug.Log($"[ FEDORA ] Le joueur {player.username} c'est pris la balle de sa vie par {attacker.username}");
                    break;
                case DamageIndex.Melee:
                    Debug.Log($"[ FEDORA ] Le joueur {player.username} c'est fait prendre en octogon par {attacker.username}");
                    break;
                case DamageIndex.Stun:
                    Debug.Log($"[ FEDORA ] &6Le joueur {player.username} c'est fait tazer par {attacker.username}");
                    break;
            }
        }

        [Target(GameSourceEvent.ManagerStart, ExecutionMode.Event)]
        public void onstart(SvManager manager)
        {
            manager.SvSetWeatherFraction(0);
            Debug.Log("&0[ FEDORA ] &bRemove the weather...");
        }
    }
}
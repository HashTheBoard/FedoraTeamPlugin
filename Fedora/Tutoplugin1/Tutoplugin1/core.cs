using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using BrokeProtocol.API;


namespace Tutoplugin1
{
    public class Tuto : Plugin
    {
        public Tuto()
        {
            Info = new PluginInfo("Tutoplugin1", "fed");
        }
    }
}
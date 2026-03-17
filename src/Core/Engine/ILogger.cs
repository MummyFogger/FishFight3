using FishFight3.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Engine
{
    public enum LogLevel { Info, Warning, Error, Debug }

    public interface ILogger
    {
        void Write(string message, LogLevel level = LogLevel.Info);
        void Write(PlayerInput p1, PlayerInput p2, LogLevel level = LogLevel.Info);
    }
}

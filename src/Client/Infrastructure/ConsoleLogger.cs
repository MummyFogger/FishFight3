using System;
using FishFight3.Core.Engine;
using FishFight3.Core.Input;

namespace FishFight3.Client.Infrastructure
{
    internal class ConsoleLogger : ILogger
    {
        public void Write(string message, LogLevel level = LogLevel.Info)
        {
            Console.WriteLine($"{DateTime.Now} | {level} | {message}");
        }

        public void Write(PlayerInput p1, PlayerInput p2, LogLevel level = LogLevel.Info)
        {
            Console.WriteLine($"{DateTime.Now} | {level} | P1 Direction: {p1.Direction} P1 Buttons: {p1.Buttons}");
            Console.WriteLine($"{DateTime.Now} | {level} | P2 Direction: {p2.Direction} P2 Buttons: {p2.Buttons}");
        }
    }
}

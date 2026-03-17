using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Engine
{
    public interface ITimeProvider
    {
        public double GetElapsedMilliseconds();
        public void Start();
        public void Stop();
        public void Reset();
        public bool IsRunning { get; }
        }
}

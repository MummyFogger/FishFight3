using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishFight3.Core.Physics;

namespace FishFight3.Core.Rendering
{
    public interface IRenderer
    {
        public void Draw(GameState state, float alpha);
    }
}

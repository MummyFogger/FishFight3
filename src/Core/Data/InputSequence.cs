using FishFight3.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Data
{
    public class InputSequence
    {
        public required InputState[] Sequence { get; init; }
        public bool Matches(FighterState fighterState, uint currentFrame)
        {
            int currentMatchIndex = Sequence.Length - 1;
            for (int i = 0; i < fighterState.InputBuffer.Length; i++)
            {
                InputState? input = fighterState.GetInput(currentFrame - (uint)i);
                if (input == null)
                {
                    break;
                }
                if (Sequence[currentMatchIndex].IsSubsetOf(input.Value))
                {
                    if (currentMatchIndex == 0)
                    {
                        return true;
                    }
                    else
                    {
                        currentMatchIndex--;
                    }
                }
            }
            return false;
        }
    }
}

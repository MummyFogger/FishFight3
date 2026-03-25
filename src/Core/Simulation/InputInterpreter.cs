using FishFight3.Core.Data;
using FishFight3.Core.State;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Simulation
{
    public class InputInterpreter : IInputInterpreter
    {
        private readonly Dictionary<uint, FighterData> _fighterTable;
        private readonly ILogger<InputInterpreter> _logger;

        public InputInterpreter(ILogger<InputInterpreter> logger, IDataLoader dataLoader)
        {
            _logger = logger;
            _fighterTable = dataLoader.GetFighterTable();
        }

        public void InterpretInputs(SimulationState state, uint currentFrame)
        {
            FighterState[] fighterStates = [state.P1State, state.P2State, state.P3State, state.P4State];
            for (int i = 0; i < fighterStates.Length; i++)
            {
                FighterState fighterState = fighterStates[i];
                if (fighterState.FighterId == 0)
                {
                    continue;
                }
                if (_fighterTable.TryGetValue(fighterState.FighterId, out FighterData? fighterData))
                {
                    if (fighterData != null)
                    {
                        for (int j = 0; j < fighterData.MoveList.Length; j++)
                        {
                            MoveData move = fighterData.MoveList[j];
                            if (move.MatchesInput(fighterState, currentFrame))
                            {
                                // TODO figure out how to handle whether fighter can switch to move
                            }
                        }
                    }
                    else
                    {
                        _logger.LogError("Fighter table returned null on fighter ID: {fighterID}", fighterStates[i].FighterId);
                    }
                }
                else
                {
                    _logger.LogError("Fighter table missing fighter ID: {fighterID}", fighterStates[i].FighterId);
                }
            }
        }
    }
}

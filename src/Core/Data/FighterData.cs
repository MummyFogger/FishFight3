using FishFight3.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Data
{
    public class FighterData
    {
        public required string Name { get; init; }
        public required uint Id { get; init; }
        public uint MaxHealth { get; init; } = 1000;
        public FixedPointLong WeightMultiplier { get; init; } = FixedPointLong.FromFloat(1.0f);
        public FixedPointLong MeterGainMultiplier { get; init; } = FixedPointLong.FromFloat(1.0f);
        // MoveList is sorted by MoveType then priority (highest first)
        public MoveData[] MoveList { get; init; } = [];
        // MoveTable is just the MoveList indexed by MoveData.Id for O(1) access during simulation
        public Dictionary<uint, MoveData> MoveTable { get; init; } = [];
    }
}

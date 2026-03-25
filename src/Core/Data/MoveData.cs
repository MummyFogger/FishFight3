using FishFight3.Core.State;

namespace FishFight3.Core.Data
{
    public enum MoveType
    {
        Super,
        AirSpecial,
        AirCommandNormal,
        AirNormal,
        Special,
        CommandNormal,
        Throw,
        Dodge,
        Normal,
        Block,
        Movement,
        Idle,
        Hitstun,
        Blockstun,
        Knockdown,
        HardKnockdown,
        ThrowTech
    }

    public class MoveData
    {
        public required string Name { get; init; }
        public required uint Id { get; init; }
        public required uint TotalFrames { get; init; }
        public required uint Priority { get; init; }
        public required MoveType Type { get; init; }
        public uint MeterCost { get; init; } = 0;
        public InputSequence[] ValidInputSequences { get; init; } = [];
        public StageData[] Stages { get; init; } = [];

        public bool MatchesInput(FighterState fighterState, uint currentFrame)
        {
            for (int i=0; i < ValidInputSequences.Length; i++)
            {
                if (ValidInputSequences[i].Matches(fighterState, currentFrame))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

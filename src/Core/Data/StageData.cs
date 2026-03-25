using FishFight3.Core.Simulation;
using FishFight3.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Data
{
    public enum PositionType
    {
        Absolute, // Absolute position in the stage's coordinate system
        Self, // Relative to the fighter's current position (e.g. for a dash attack)
        ScreenRelative, // Relative to the screen (e.g. for a projectile that always spawns at the same place on the screen)
        NearestOpponent, // Relative to the nearest opponent (e.g. for a homing attack)
        FurthestOpponent // Relative to the furthest opponent (e.g. for a zoning attack)
    }

    public class StageData
    {
        public required string Name { get; init; }
        public required uint Id { get; init; }
        public required uint TotalFrames { get; init; }
        public FixedPointLong VelocityX { get; init; } = FixedPointLong.FromFloat(0.0f);
        public FixedPointLong VelocityY { get; init; } = FixedPointLong.FromFloat(0.0f);
        public PositionType OffsetType { get; init; } = PositionType.Self;
        public FixedPointLong OffsetX { get; init; } = FixedPointLong.FromFloat(0.0f);
        public FixedPointLong OffsetY { get; init; } = FixedPointLong.FromFloat(0.0f);
        public uint Damage { get; init; } = 0;
        public uint MeterGain { get; init; } = 0;
        public uint Hitstun { get; init; } = 0;
        public uint BlockStun { get; init; } = 0;
        public uint[] SpecialCancelableMoves { get; init; } = [];

        // TODO Bools for the various special effects that a stage can have (e.g. knockdown, wallbounce, etc.)
        // TODO some system for generating visual effects (e.g. hit sparks, screen shake, etc.) that can be triggered by stages
        // TODO some system for generating sound effects that can be triggered by stages
        // TODO some system for generating entities (e.g. projectiles, hitboxes, etc.) that can be triggered by stages

        public CollisionBox[] HitBoxes { get; init; } = [];
        public CollisionBox[] HurtBoxes { get; init; } = [];
        public CollisionBox[] PushBoxes { get; init; } = [];
    }
}

using FishFight3.Core.State;
using ICSharpCode.Decompiler.IL;

namespace FishFight3.Core.Simulation;

public struct CollisionBox
{
    public FixedPointLong X;
    public FixedPointLong Y;
    public FixedPointLong Width;
    public FixedPointLong Height;

    public CollisionBox(FixedPointLong x, FixedPointLong y, FixedPointLong width, FixedPointLong height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    /// <summary>
    /// Deterministic AABB check using FixedPointLong math.
    /// </summary>
    public readonly bool Intersects(CollisionBox other)
    {
        return X < (other.X + other.Width) &&
               (X + Width) > other.X &&
               Y < (other.Y + other.Height) &&
               (Y + Height) > other.Y;
    }

    public readonly CollisionBox GetWorldBox(FixedPointLong playerX, FixedPointLong playerY, bool facingRight)
    {
        FixedPointLong worldX = facingRight
            ? playerX + X
            : playerX - X - Width;

        return new CollisionBox(worldX, playerY + Y, Width, Height);
    }

}


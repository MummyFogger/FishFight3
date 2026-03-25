using System.Runtime.InteropServices;

namespace FishFight3.Core.State
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FixedPointLong
    {
        private readonly long _rawValue;
        private const int Shift = 32;
        private const long One = 1L << Shift;

        public static readonly FixedPointLong Zero = FromInt(0);
        public static readonly FixedPointLong Half = FromFloat(0.5f);
        public static readonly FixedPointLong Quarter = FromFloat(0.25f);
        public static readonly FixedPointLong FrictionConstant = FromFloat(0.9f);

        private FixedPointLong(long rawValue) => _rawValue = rawValue;

        public static FixedPointLong FromInt(int value) => new((long)value << Shift);
        public static FixedPointLong FromFloat(float value) => new((long)(value * One));

        public readonly float ToFloat() => (float)_rawValue / One;

        // Arithmetic
        public static FixedPointLong operator +(FixedPointLong a, FixedPointLong b) => new FixedPointLong(a._rawValue + b._rawValue);
        public static FixedPointLong operator -(FixedPointLong a, FixedPointLong b) => new FixedPointLong(a._rawValue - b._rawValue);

        // Comparison
        public static bool operator <(FixedPointLong a, FixedPointLong b) => a._rawValue < b._rawValue;
        public static bool operator >(FixedPointLong a, FixedPointLong b) => a._rawValue > b._rawValue;

        // Multiplication: (a * b) / One to maintain scale
        public static FixedPointLong operator *(FixedPointLong a, FixedPointLong b)
        {
            return new FixedPointLong((a._rawValue * b._rawValue) >> Shift);
        }

        // Division: (a * One) / b to maintain scale
        public static FixedPointLong operator /(FixedPointLong a, FixedPointLong b)
        {
            return new FixedPointLong((a._rawValue << Shift) / b._rawValue);
        }


        public override readonly string ToString() => ToFloat().ToString();
    }
}

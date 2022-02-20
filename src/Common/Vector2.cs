using System.Runtime.CompilerServices;

namespace System.Numerics
{
    public static class Vector2Extension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(in this Vector2 a, in Vector2 b)
        {
            return Vector2.Dot(a, b);
        }

        // this method returns normalized vector, origin vector remains unchanged
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Normalized(in this Vector2 a)
        {
            return Vector2.Normalize(a);
        }

        // this method alter the origin vector
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normalize(ref this Vector2 a)
        {
            var invLength = 1 / a.Length();
            a *= invLength;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cross(in this Vector2 a, in Vector2 b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Cross(in this Vector2 v, float a)
        {
            return new Vector2(a * v.Y, -a * v.X);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Cross(this float a, in Vector2 v)
        {
            return new Vector2(-a * v.Y, a * v.X);
        }
    }
}
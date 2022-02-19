using System.Numerics;
using System.Runtime.CompilerServices;

namespace Dyn2d.Math
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
        public static ref Vector2 Normalize(ref this Vector2 a)
        {
            var invLength = 1 / a.Length();
            a.X *= invLength;
            a.Y *= invLength;
            return ref a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static float Cross(in this Vector2 a, in Vector2 b) {
            return Vector2.
        }
    }
}
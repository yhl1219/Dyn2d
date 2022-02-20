using System.Runtime.CompilerServices;

namespace System.Numerics
{
    public struct Matrix2
    {
        public float M00, M01, M10, M11;

        public Matrix2()
        {
            M00 = M11 = 1;
            M10 = M01 = 0;
        }

        public Matrix2(float m00, float m11)
        {
            M00 = m00;
            M11 = m11;
            M10 = M01 = 0;
        }

        public Matrix2(float m00, float m01, float m10, float m11)
        {
            M00 = m00;
            M01 = m01;
            M10 = m10;
            M11 = m11;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Matrix2 Transposed()
        {
            return new Matrix2(M00, M10, M01, M11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Transpose()
        {
            float temp = M01;
            M01 = M10;
            M10 = temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 operator +(in Matrix2 a, in Matrix2 b)
        {
            return new Matrix2(a.M00 + b.M00, a.M01 + b.M01, a.M10 + b.M10, a.M11 + b.M11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 operator -(in Matrix2 a, in Matrix2 b)
        {
            return new Matrix2(a.M00 - b.M00, a.M01 - b.M01, a.M10 - b.M10, a.M11 - b.M11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 operator *(in Matrix2 a, float b)
        {
            return new Matrix2(a.M00 * b, a.M01 * b, a.M10 * b, a.M11 * b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 operator /(in Matrix2 a, float b)
        {
            return new Matrix2(a.M00 / b, a.M01 / b, a.M10 / b, a.M11 / b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(in Matrix2 a, in Vector2 b)
        {
            return new Vector2(a.M00 * b.X + a.M01 * b.Y, a.M10 * b.X + a.M11 * b.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 operator *(in Matrix2 a, in Matrix2 r)
        {
            return new Matrix2(a.M00 * r.M00 + a.M01 * r.M10, a.M00 * r.M01 + a.M01 * r.M11, a.M10 * r.M00 + a.M11 * r.M10, a.M10 * r.M01 + a.M11 * r.M11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Rotate(float radians)
        {
            float c = MathF.Cos(radians), s = MathF.Sin(radians);
            return new Matrix2(c, -s, s, c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Matrix2 Scale(float sx, float sy)
        {
            return new Matrix2(sx, 0, 0, sy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetScale(float sx, float sy)
        {
            M00 = sx;
            M11 = sy;
            M10 = M01 = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetRotate(float radians)
        {
            float c = MathF.Cos(radians), s = MathF.Sin(radians);
            M00 = M11 = c;
            M01 = -s;
            M10 = s;
        }
    }
}
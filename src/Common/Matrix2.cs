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

        public Matrix2 Transposed()
    }
}
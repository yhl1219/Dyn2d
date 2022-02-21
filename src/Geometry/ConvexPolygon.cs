using System.Numerics;

namespace Dyn2d.Geometry
{
    public class ConvexPolgyon : Shape
    {
        public Vector2[] Vertices { get; }

        public Vector2[] Normals { get; }

        // unit property to calculate mass and inertia
        private readonly float _unitMass;

        private readonly float _unitInertia;

        private readonly Matrix2 _orientation;

        public ConvexPolgyon(Vector2[] originalVertices, out Vector2 centroid) : base(ShapeType.ConvexPolygon)
        {
            Vertices = new Vector2[originalVertices.Length];
            Normals = new Vector2[originalVertices.Length];
            _orientation = new Matrix2(1, 0, 0, 1);

            // copy the vertices so we won't make change to the orignal ones
            originalVertices.CopyTo(Vertices, 0);

            const float v = 0.25f / 3.0f;

            var c = new Vector2(0, 0); // centroid
            _unitMass = _unitInertia = 0;

            for (var i = 0; i < Vertices.Length; ++i)
            {
                var j = i + 1 == Vertices.Length ? 0 : i + 1;

                // get the vertices and calculate the area of the triangle (signed)
                Vector2 p1 = Vertices[i], p2 = Vertices[j];
                float signedD = p1.Cross(p2), signedS = signedD / 2.0f;

                // accumulate the unit_mass and move the centroid
                _unitMass += signedS;
                c += signedS * (p1 + p2) / 3.0f;

                // integrate the inertia, using cross-axis theorem and parallel-axis
                // theorem
                float ix = p1.X * p1.X + p1.X * p2.X + p2.X * p2.X;
                float iy = p1.Y * p1.Y + p1.Y * p2.Y + p2.Y * p2.Y;
                _unitInertia += v * signedD * (ix + iy);

                // also, calculate the normal
                Vector2 face = p2 - p1;
                Normals[i] = new Vector2(face.Y, -face.X).Normalized();
            }

            // figure out the centroid
            c /= _unitMass;
            centroid = c;

            // making them positive
            _unitMass = MathF.Abs(_unitMass);
            _unitInertia = MathF.Abs(_unitInertia);

            // shift vertices to centroid (0 0)
            for (var i = 0; i < Vertices.Length; ++i)
            {
                Vertices[i] -= c;
            }
        }

        // only for clone
        private ConvexPolgyon(Vector2[] vertices, Vector2[] normals, float unitMass, float unitInertia, in Matrix2 orientation) : base(ShapeType.ConvexPolygon)
        {
            _unitMass = unitMass;
            _unitInertia = unitInertia;
            _orientation = orientation;

            Vertices = new Vector2[vertices.Length];
            vertices.CopyTo(Vertices, 0);

            Normals = new Vector2[normals.Length];
            normals.CopyTo(Normals, 0);
        }

        public override Shape Clone()
        {
            return new ConvexPolgyon(Vertices, Normals, _unitMass, _unitInertia, _orientation);
        }

        public override float GetInertia(float density)
        {
            return _unitInertia * density;
        }

        public override float GetMass(float density)
        {
            return _unitMass * density;
        }

        public override void SetOrient(float radian)
        {
            _orientation.SetRotate(radian);
        }
    }
}
using Dyn2d.Common;

namespace Dyn2d.Geometry
{
    public enum ShapeType
    {
        Circle,
        ConvexPolygon,
    }

    public abstract class Shape : ICloneable<Shape>
    {
        public abstract float GetMass(float density);

        public abstract float GetInertia(float density);

        public abstract void SetOrient(float radian);

        public abstract Shape Clone();

        public ShapeType Type { get; }

        public Shape(ShapeType type)
        {
            Type = type;
        }
    }
}
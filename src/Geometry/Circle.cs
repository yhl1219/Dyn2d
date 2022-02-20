namespace Dyn2d.Geometry
{
    public class Circle : Shape
    {
        public float Radius { get; }

        public Circle(float radius) : base(ShapeType.Circle)
        {
            Radius = radius;
        }

        public override Circle Clone()
        {
            return new Circle(Radius);
        }

        public override float GetInertia(float density)
        {
            return GetMass(density) * Radius * Radius;
        }

        public override float GetMass(float density)
        {
            return MathF.PI * Radius * Radius * density;
        }

        public override void SetOrient(float radian)
        {
            // no nothing
        }
    }
}
using System.Numerics;

using Dyn2d.Geometry;

namespace Dyn2d.Dynamic
{
    public class RigidBody
    {
        public Shape Shape { get; }

        public float Restitution { get; set; }

        public float DynamicFriction { get; set; }

        public float StaticFriction { get; set; }

        private float _invMass;

        public float Mass => _invMass == 0.0f ? 0 : 1.0f / _invMass;

        private float _invInertia;

        public float Inertia => _invInertia == 0.0f ? 0 : 1.0f / _invInertia;

        private float _density;

        public float Density
        {
            get => _density;
            set
            {
                _density = value;
                if (!_static)
                {
                    SetMassAndInertia();
                }
            }
        }

        private void SetMassAndInertia()
        { 
            _invMass = 1.0f / Shape.GetMass(_density);
            _invInertia = 1.0f / Shape.GetInertia(_density);
        }

        public Vector2 Position { get; set; }

        public Vector2 Velocity { get; set; }

        public Vector2 Force { get; set; }

        private float _orientation;

        public float Orientation
        {
            get => _orientation;
            set
            {
                _orientation = value;
                Shape.SetOrient(_orientation);
            }
        }

        public float AngularVelocity { get; set; }

        public float Torque { get; set; }

        private bool _static;

        public bool Static
        {
            get => _static;
            set
            {
                _static = value;
                if (_static)
                {
                    _invInertia = _invMass = 0.0f;
                }
                else
                {
                    SetMassAndInertia();
                }
            }
        }

        public RigidBody(Shape shape, float restitution, float dynamicFriction, float staticFriction, float density,
            in Vector2 position, in Vector2 velocity, in Vector2 force, float orientation, float angularVelocity, float torque)
        {
            Shape = shape.Clone();
            Restitution = restitution;
            DynamicFriction = dynamicFriction;
            StaticFriction = staticFriction;
            Density = density;
            Position = position;
            Velocity = velocity;
            Force = force;
            Orientation = orientation;
            AngularVelocity = angularVelocity;
            Torque = torque;
        }

        public T GetShapeAs<T>() where T : Shape
        {
            return (T)Shape;
        }

        public void SetStatic()
        {
            _invInertia = _invMass = 0.0f;
        }

        public void SetMovable()
        {
            Density = _density;
        }
    }
}
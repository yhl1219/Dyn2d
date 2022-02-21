namespace Dyn2d.Dynamic
{
    public interface IPhysicsBody
    {
        public float Restitution { get; set; }

        public float DynamicFriction { get; set; }

        public float StaticFriction { get; set; }
    }
}
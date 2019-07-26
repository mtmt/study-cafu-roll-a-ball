using UnityEngine;

namespace StudyCafuRollABall.Domain.Entity
{
    public class PlayerEntity : IPlayerEntity
    {
        public PlayerEntity(Rigidbody rigidbody)
        {
            this.rigidbody = rigidbody;
        }

        readonly Rigidbody rigidbody;
        public Vector3 Position => rigidbody.position;

        public void AddForce(Vector3 force)
        {
            rigidbody.AddForce(force);
        }
    }
}
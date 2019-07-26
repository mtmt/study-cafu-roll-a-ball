using UnityEngine;

namespace StudyCafuRollABall.Domain.Entity
{
    public class PlayerEntity : IPlayerEntity
    {
        public PlayerEntity(Rigidbody rigidbody)
        {
            Rigidbody = rigidbody;
        }

        public Rigidbody Rigidbody { get; }

        public void AddForce(Vector3 force)
        {
            Rigidbody.AddForce(force);
        }
    }
}
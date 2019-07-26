using CAFU.Core;
using UnityEngine;

namespace StudyCafuRollABall.Domain.Entity
{
    public interface IPlayerEntity : IEntity
    {
        Rigidbody Rigidbody { get; }
        void AddForce(Vector3 force);
    }
}
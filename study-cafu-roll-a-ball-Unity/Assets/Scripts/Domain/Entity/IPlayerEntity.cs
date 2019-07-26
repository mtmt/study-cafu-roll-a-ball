using CAFU.Core;
using UnityEngine;

namespace StudyCafuRollABall.Domain.Entity
{
    public interface IPlayerEntity : IEntity
    {
        Vector3 Position { get; }
        void AddForce(Vector3 force);
    }
}
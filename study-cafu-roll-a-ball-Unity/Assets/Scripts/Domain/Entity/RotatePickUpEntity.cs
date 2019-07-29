using UnityEngine;
using Zenject;

namespace StudyCafuRollABall.Domain.Entity
{
    public class RotatePickUpEntity : IRotatePickUpEntity, ITickable
    {
        public RotatePickUpEntity(Transform transform)
        {
            this.transform = transform;
        }

        readonly Transform transform;

        public void Tick()
        {
            transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
        }
    }
}
using UnityEngine;
using Zenject;

namespace StudyCafuRollABall.Domain.Entity
{
    public class CameraEntity : ICameraEntity, ILateTickable
    {
        public CameraEntity(Transform cameraTransform, Transform targetTransform)
        {
            this.transform = cameraTransform;
            this.targetTransform = targetTransform;
            offset = transform.position - targetTransform.position;
        }

        readonly Transform transform;
        readonly Transform targetTransform;
        readonly Vector3 offset;

        public void LateTick()
        {
            transform.position = targetTransform.position + offset;
        }
    }
}
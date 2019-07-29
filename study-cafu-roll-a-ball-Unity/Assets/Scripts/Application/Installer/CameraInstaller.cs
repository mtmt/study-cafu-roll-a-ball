using System;
using StudyCafuRollABall.Domain.Entity;
using UnityEngine;
using Zenject;

namespace StudyCafuRollABall.Application.Installer
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] Settings settings = default;

        public override void InstallBindings()
        {
            // entity
            Container.BindInterfacesTo<CameraEntity>().AsCached()
                .WithArguments(settings.cameraTransform, settings.targetTransform);
        }

        [Serializable]
        public class Settings
        {
            public Transform cameraTransform;
            public Transform targetTransform;
        }
    }
}
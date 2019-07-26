using System;
using StudyCafuRollABall.Domain.Entity;
using UnityEngine;
using Zenject;

namespace StudyCafuRollABall.Application.Installer
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] Settings settings = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerEntity>().AsCached()
                .WithArguments(settings.Rigidbody);
        }

        [Serializable]
        public class Settings
        {
            public Rigidbody Rigidbody;
        }
    }
}
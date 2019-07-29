using System;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.UseCase;
using StudyCafuRollABall.Presentation.Controller;
using StudyCafuRollABall.Presentation.View;
using UnityEngine;
using Zenject;

namespace StudyCafuRollABall.Application.Installer
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] Settings settings = default;

        public override void InstallBindings()
        {
            // entity
            Container.BindInterfacesTo<PlayerEntity>().AsCached()
                .WithArguments(settings.Rigidbody);

            // use case
            Container.BindInterfacesTo<MovePlayerInteractor>().AsCached()
                .WithArguments(settings.Speed);

            // controller
            Container.BindInterfacesTo<MovePlayerController>().AsCached();

            // view
            Container.BindInterfacesTo<MovePlayerInputHandler>().AsCached();
        }

        [Serializable]
        public class Settings
        {
            public Rigidbody Rigidbody;
            public float Speed = 10;
        }
    }
}
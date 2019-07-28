using System;
using StudyCafuRollABall.Domain.UseCase;
using StudyCafuRollABall.Presentation.Controller;
using StudyCafuRollABall.Presentation.View;
using UnityEngine;
using Zenject;

namespace StudyCafuRollABall.Application.Installer
{
    public class RollABallSceneInstaller : MonoInstaller
    {
        [SerializeField] Settings settings;

        public override void InstallBindings()
        {
            // use case
            Container.BindInterfacesTo<CollectPickUpInteractor>().AsCached();

            // presenter
            Container.BindInterfacesTo<CollectPickUpController>().AsCached();

            // view
            Container.BindInterfacesTo<CollectPickUpView>()
                .FromNewComponentOn(settings.Player).AsCached();
        }

        [Serializable]
        public class Settings
        {
            public GameObject Player;
        }

    }
}
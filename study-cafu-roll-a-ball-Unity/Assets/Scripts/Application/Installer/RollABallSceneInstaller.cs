using System;
using StudyCafuRollABall.Domain.Structure;
using StudyCafuRollABall.Domain.UseCase;
using StudyCafuRollABall.Presentation.Controller;
using StudyCafuRollABall.Presentation.View;
using UnityEngine;
using Zenject;

namespace StudyCafuRollABall.Application.Installer
{
    public class RollABallSceneInstaller : MonoInstaller
    {
        [SerializeField] Settings settings = default;

        public override void InstallBindings()
        {
            // structure
            Container.BindIFactory<string, ICollectPickUpStructure>().To<CollectPickUpStructure>();

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
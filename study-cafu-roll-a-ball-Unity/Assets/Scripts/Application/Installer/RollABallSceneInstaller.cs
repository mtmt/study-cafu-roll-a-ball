using System;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using StudyCafuRollABall.Domain.UseCase;
using StudyCafuRollABall.Presentation.Controller;
using StudyCafuRollABall.Presentation.Presenter;
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
            // entity
            Container.BindIFactory<int, IPointEntity>().To<PointEntity>();
            Container.BindInterfacesTo<ScoreEntity>().AsCached();

            // structure
            Container.BindIFactory<string, ICollectPickUpStructure>().To<CollectPickUpStructure>();

            // use case
            Container.BindInterfacesTo<CollectPickUpInteractor>().AsCached();
            Container.BindInterfacesTo<RenderWinTextInteractor>().AsCached();

            // presenter
            Container.BindInterfacesTo<CollectPickUpController>().AsCached();
            Container.BindInterfacesTo<RenderWinTextPresenter>().AsCached();

            // view
            Container.BindInterfacesTo<CollectPickUpView>()
                .FromNewComponentOn(settings.Player).AsCached();
            Container.BindInterfacesTo<RenderWinTextView>().AsCached();
        }

        [Serializable]
        public class Settings
        {
            public GameObject Player;
        }

    }
}
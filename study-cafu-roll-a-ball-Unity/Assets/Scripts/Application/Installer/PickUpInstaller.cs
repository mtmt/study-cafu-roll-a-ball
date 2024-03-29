using System;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using StudyCafuRollABall.Domain.Translator;
using StudyCafuRollABall.Domain.UseCase;
using StudyCafuRollABall.Presentation.Presenter;
using StudyCafuRollABall.Presentation.View;
using UnityEngine;
using Zenject;

namespace StudyCafuRollABall.Application.Installer
{
    public class PickUpInstaller : MonoInstaller
    {
        [SerializeField] Settings settings = default;

        public override void InstallBindings()
        {
            // entity
            Container.BindInterfacesTo<RenderPickUpEntity>().AsCached()
                .WithArguments(true);
            Container.BindInterfacesTo<RotatePickUpEntity>().AsCached()
                .WithArguments(settings.transform);

            // structure
            Container.BindIFactory<bool, IRenderPickUpStructure>()
                .To<RenderPickUpStructure>();

            // translator
            Container.BindInterfacesTo<RenderPickUpTranslator>().AsCached();

            // use case
            Container.BindInterfacesTo<RenderPickUpInteractor>().AsCached();
            Container.BindInterfacesTo<DespawnPickUpInteractor>().AsCached()
                .WithArguments(gameObject.name);

            // presenter
            Container.BindInterfacesTo<RenderPickUpPresenter>().AsCached();

            // view
            Container.BindInterfacesTo<RenderPickUpView>().AsCached();
        }

        [Serializable]
        public class Settings
        {
            public Transform transform;
        }

    }
}
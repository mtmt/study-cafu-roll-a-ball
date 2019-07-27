using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using StudyCafuRollABall.Domain.Translator;
using StudyCafuRollABall.Domain.UseCase;
using StudyCafuRollABall.Presentation.Presenter;
using StudyCafuRollABall.Presentation.View;
using Zenject;

namespace StudyCafuRollABall.Application.Installer
{
    public class PickUpInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // entity
            Container.BindInterfacesTo<RenderPickUpEntity>().AsCached()
                .WithArguments(true);

            // structure
            Container.BindIFactory<bool, IRenderPickUpStructure>()
                .To<RenderPickUpStructure>();

            // translator
            Container.BindInterfacesTo<RenderPickUpTranslator>().AsCached();

            // use case
            Container.BindInterfacesTo<RenderPickUpInteractor>().AsCached();

            // presenter
            Container.BindInterfacesTo<RenderPickUpPresenter>().AsCached();

            // view
            Container.BindInterfacesTo<RenderPickUpView>().AsCached();
        }
    }
}
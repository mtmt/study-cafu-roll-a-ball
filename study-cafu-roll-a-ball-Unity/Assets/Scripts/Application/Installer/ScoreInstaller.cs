using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using StudyCafuRollABall.Domain.Translator;
using StudyCafuRollABall.Domain.UseCase;
using StudyCafuRollABall.Presentation.Presenter;
using StudyCafuRollABall.Presentation.View;
using Zenject;

namespace StudyCafuRollABall.Application.Installer
{
    public class ScoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // structure
            Container.BindIFactory<IScoreEntity, IRenderScoreStructure>().To<RenderScoreStructure>();

            // translator
            Container.BindInterfacesTo<RenderScoreTranslator>().AsCached();

            // use case
            Container.BindInterfacesTo<RenderScoreInteractor>().AsCached();

            // presenter
            Container.BindInterfacesTo<RenderScorePresenter>().AsCached();

            // view
            Container.BindInterfacesTo<RenderScoreView>().AsCached();
        }
    }
}
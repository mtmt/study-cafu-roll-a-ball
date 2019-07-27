using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Translator;

namespace StudyCafuRollABall.Domain.UseCase
{
    public class RenderPickUpInteractor : IRenderPickUpUseCase
    {
        public RenderPickUpInteractor(IRenderPickUpTranslator translator, IRenderPickUpPresenter presenter)
        {
            this.translator = translator;
            this.presenter = presenter;
        }

        readonly IRenderPickUpTranslator translator;
        readonly IRenderPickUpPresenter presenter;

        public void Render(IRenderPickUpEntity entity)
        {
            var structure = translator.Translate(entity);
            presenter.Render(structure);
        }
    }
}
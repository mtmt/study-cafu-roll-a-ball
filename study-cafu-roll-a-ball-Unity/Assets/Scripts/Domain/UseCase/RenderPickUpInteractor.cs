using System;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Translator;
using UniRx;

namespace StudyCafuRollABall.Domain.UseCase
{
    public class RenderPickUpInteractor : IRenderPickUpUseCase, IDisposable
    {
        public RenderPickUpInteractor(
            IRenderPickUpEntity entity,
            IRenderPickUpTranslator translator,
            IRenderPickUpPresenter presenter
        )
        {
            this.translator = translator;
            this.presenter = presenter;
            entity.IsVisible.Subscribe(_ => Render(entity)).AddTo(disposable);
        }

        readonly IRenderPickUpTranslator translator;
        readonly IRenderPickUpPresenter presenter;
        readonly CompositeDisposable disposable = new CompositeDisposable();

        public void Render(IRenderPickUpEntity entity)
        {
            var structure = translator.Translate(entity);
            presenter.Render(structure);
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}
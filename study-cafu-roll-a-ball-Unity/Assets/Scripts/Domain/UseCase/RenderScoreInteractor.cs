using System;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Translator;
using UniRx;

namespace StudyCafuRollABall.Domain.UseCase
{
    public class RenderScoreInteractor : IRenderScoreUseCase, IDisposable
    {
        public RenderScoreInteractor(
            IScoreEntity scoreEntity,
            IRenderScorePresenter presenter,
            IRenderScoreTranslator translator
        )
        {
            this.presenter = presenter;
            this.translator = translator;
            disposable = new CompositeDisposable();
            scoreEntity.Points.Subscribe(_ => Render(scoreEntity)).AddTo(disposable);
        }

        readonly IRenderScorePresenter presenter;
        readonly IRenderScoreTranslator translator;
        readonly CompositeDisposable disposable;

        public void Render(IScoreEntity scoreEntity)
        {
            var structure = translator.Translate(scoreEntity);
            presenter.Render(structure);
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}
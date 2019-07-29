using System;
using StudyCafuRollABall.Domain.Entity;
using UniRx;

namespace StudyCafuRollABall.Domain.UseCase
{
    public class RenderWinTextInteractor : IRenderWinTextUseCase, IDisposable
    {
        public RenderWinTextInteractor(IScoreEntity score, IRenderWinTextPresenter presenter)
        {
            presenter.SetText("");

            disposable = new CompositeDisposable();
            score.Points.Where(point => point.Value >= 12)
                .Subscribe(_ => presenter.SetText("You Win!"))
                .AddTo(disposable);
        }

        readonly CompositeDisposable disposable;

        public void Dispose()
        {
            disposable?.Dispose();
        }
    }
}
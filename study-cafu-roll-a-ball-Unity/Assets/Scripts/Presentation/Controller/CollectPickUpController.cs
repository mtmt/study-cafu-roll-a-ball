using System;
using StudyCafuRollABall.Domain.UseCase;
using UniRx;

namespace StudyCafuRollABall.Presentation.Controller
{
    public class CollectPickUpController : IDisposable
    {
        public CollectPickUpController(ICollectPickUpUseCase useCase, ICollectPickUpView view)
        {
            view.OnCollectAsObservable().Select(x => x.gameObject.name)
                .Subscribe(name => useCase.Collent(name))
                .AddTo(disposable);
        }

        readonly CompositeDisposable disposable = new CompositeDisposable();

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}
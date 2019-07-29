using System;
using StudyCafuRollABall.Domain.UseCase;
using UniRx;

namespace StudyCafuRollABall.Presentation.Controller
{
    public class MovePlayerController : IDisposable
    {
        public MovePlayerController(IMovePlayerUseCase useCase, IDirectionTrigger trigger)
        {
            trigger.Stream.Subscribe(useCase.Move).AddTo(disposable);
        }

        readonly CompositeDisposable disposable = new CompositeDisposable();

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}
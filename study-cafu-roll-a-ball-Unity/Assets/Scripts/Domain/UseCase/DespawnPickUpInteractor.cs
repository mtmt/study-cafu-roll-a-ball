using System;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using UniRx;

namespace StudyCafuRollABall.Domain.UseCase
{
    public class DespawnPickUpInteractor : IDespawnPickUpUseCase, IDisposable
    {
        public DespawnPickUpInteractor(string name, IRenderPickUpEntity entity)
        {
            MessageBroker.Default.Receive<ICollectPickUpStructure>()
                .Where(structure => structure.Name == name)
                .Subscribe(_ => entity.Hide())
                .AddTo(disposable);
        }

        readonly CompositeDisposable disposable = new CompositeDisposable();

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}
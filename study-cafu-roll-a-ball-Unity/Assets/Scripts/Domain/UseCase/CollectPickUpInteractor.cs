using StudyCafuRollABall.Domain.Structure;
using UniRx;
using Zenject;

namespace StudyCafuRollABall.Domain.UseCase
{
    public class CollectPickUpInteractor : ICollectPickUpUseCase
    {
        public CollectPickUpInteractor(IFactory<string, ICollectPickUpStructure> factory)
        {
            this.factory = factory;
        }

        readonly IFactory<string, ICollectPickUpStructure> factory;

        public void Collect(string name)
        {
            var structure = factory.Create(name);
            MessageBroker.Default.Publish(structure);
        }
    }
}
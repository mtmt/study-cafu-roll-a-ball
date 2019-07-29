using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using UniRx;
using Zenject;

namespace StudyCafuRollABall.Domain.UseCase
{
    public class CollectPickUpInteractor : ICollectPickUpUseCase
    {
        public CollectPickUpInteractor(
            IFactory<int, IPointEntity> pointFactory,
            IScoreEntity score,
            IFactory<string, ICollectPickUpStructure> structureFactory
            )
        {
            this.pointFactory = pointFactory;
            this.score = score;
            this.structureFactory = structureFactory;
        }

        readonly IFactory<int, IPointEntity> pointFactory;
        readonly IScoreEntity score;
        readonly IFactory<string, ICollectPickUpStructure> structureFactory;

        public void Collect(string name)
        {
            var structure = structureFactory.Create(name);
            MessageBroker.Default.Publish(structure);

            var point = pointFactory.Create(1);
            score.Add(point);
        }
    }
}
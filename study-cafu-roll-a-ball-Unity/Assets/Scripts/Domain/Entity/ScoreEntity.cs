using UniRx;
using Zenject;

namespace StudyCafuRollABall.Domain.Entity
{
    public class ScoreEntity : IScoreEntity
    {
        public ScoreEntity(IFactory<int, IPointEntity> pointEntityFactory)
        {
            this.pointEntityFactory = pointEntityFactory;

            var pointEntity = pointEntityFactory.Create(0);
            points = new ReactiveProperty<IPointEntity>(pointEntity);
        }

        readonly ReactiveProperty<IPointEntity> points;
        public IReadOnlyReactiveProperty<IPointEntity> Points => points;

        readonly IFactory<int, IPointEntity> pointEntityFactory;

        public IPointEntity Set(IPointEntity pointEntity)
        {
            points.Value = pointEntity;
            return points.Value;
        }

        public IPointEntity Add(IPointEntity pointEntity)
        {
            var newPoints = points.Value.Add(pointEntity);
            return Set(newPoints);
        }
    }
}
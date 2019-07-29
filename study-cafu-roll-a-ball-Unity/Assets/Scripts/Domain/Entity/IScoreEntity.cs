using CAFU.Core;
using UniRx;

namespace StudyCafuRollABall.Domain.Entity
{
    public interface IScoreEntity : IEntity
    {
        IReadOnlyReactiveProperty<IPointEntity> Points { get; }

        IPointEntity Set(IPointEntity pointEntity);
        IPointEntity Add(IPointEntity pointEntity);
    }
}
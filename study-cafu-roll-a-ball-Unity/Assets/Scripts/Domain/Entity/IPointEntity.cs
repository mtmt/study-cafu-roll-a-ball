namespace StudyCafuRollABall.Domain.Entity
{
    public interface IPointEntity
    {
        int Value { get; }

        IPointEntity Add(IPointEntity pointEntity);
    }
}
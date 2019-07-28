namespace StudyCafuRollABall.Domain.Entity
{
    public class PointEntity : IPointEntity
    {
        public PointEntity(int value = 0)
        {
            Value = value;
        }

        public int Value { get; }

        public IPointEntity Add(IPointEntity pointEntity)
        {
            var value = Value + pointEntity.Value;
            return new PointEntity(value);
        }
    }
}
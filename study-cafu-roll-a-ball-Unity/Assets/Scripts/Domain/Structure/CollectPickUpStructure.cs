namespace StudyCafuRollABall.Domain.Structure
{
    public struct CollectPickUpStructure : ICollectPickUpStructure
    {
        public CollectPickUpStructure(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
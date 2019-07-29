namespace StudyCafuRollABall.Domain.Structure
{
    public struct RenderPickUpStructure : IRenderPickUpStructure
    {
        public RenderPickUpStructure(bool isVisible)
        {
            IsVisible = isVisible;
        }

        public bool IsVisible { get; }
    }
}
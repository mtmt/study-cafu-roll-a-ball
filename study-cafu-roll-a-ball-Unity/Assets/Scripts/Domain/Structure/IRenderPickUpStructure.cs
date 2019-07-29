using CAFU.Core;

namespace StudyCafuRollABall.Domain.Structure
{
    public interface IRenderPickUpStructure : IStructure
    {
        bool IsVisible { get; }
    }
}
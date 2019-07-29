using CAFU.Core;

namespace StudyCafuRollABall.Domain.Structure
{
    public interface IRenderScoreStructure : IStructure
    {
        string ScoreText { get; }
    }
}
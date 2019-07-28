using StudyCafuRollABall.Domain.Entity;

namespace StudyCafuRollABall.Domain.Structure
{
    public struct RenderScoreStructure : IRenderScoreStructure
    {
        public RenderScoreStructure(IScoreEntity scoreEntity)
        {
            ScoreText = scoreEntity.Points.Value.Value.ToString();
        }

        public string ScoreText { get; }
    }
}
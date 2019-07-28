using CAFU.Core;
using StudyCafuRollABall.Domain.Structure;

namespace StudyCafuRollABall.Domain.UseCase
{
    public interface IRenderScorePresenter : IPresenter
    {
        void Render(IRenderScoreStructure presentationScoreStructure);
    }
}
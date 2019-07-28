using CAFU.Core;
using StudyCafuRollABall.Domain.Entity;

namespace StudyCafuRollABall.Domain.UseCase
{
    public interface IRenderScoreUseCase : IUseCase
    {
        void Render(IScoreEntity scoreEntity);
    }
}
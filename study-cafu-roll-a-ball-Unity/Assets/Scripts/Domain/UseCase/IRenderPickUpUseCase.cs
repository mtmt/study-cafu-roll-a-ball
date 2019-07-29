using CAFU.Core;
using StudyCafuRollABall.Domain.Entity;

namespace StudyCafuRollABall.Domain.UseCase
{
    public interface IRenderPickUpUseCase : IUseCase
    {
        void Render(IRenderPickUpEntity entity);
    }
}
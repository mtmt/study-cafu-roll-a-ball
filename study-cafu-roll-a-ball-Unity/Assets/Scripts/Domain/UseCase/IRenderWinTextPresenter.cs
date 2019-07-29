using CAFU.Core;

namespace StudyCafuRollABall.Domain.UseCase
{
    public interface IRenderWinTextPresenter : IPresenter
    {
        void SetText(string text);
    }
}
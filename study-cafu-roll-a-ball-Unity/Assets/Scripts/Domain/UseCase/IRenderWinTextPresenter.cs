using CAFU.Core;

namespace StudyCafuRollABall.Domain.UseCase
{
    public interface IRenderWinTextPresenter : IPresenter
    {
        void Show();
        void Hide();
    }
}
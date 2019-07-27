using CAFU.Core;

namespace StudyCafuRollABall.Presentation.Presenter
{
    public interface IRenderPickUpView : IView
    {
        void Render(bool isVisible);
    }
}
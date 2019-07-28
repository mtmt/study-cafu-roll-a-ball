using CAFU.Core;

namespace StudyCafuRollABall.Presentation.Presenter
{
    public interface IRenderScoreView : IView
    {
        void Render(string scoreText);
    }
}
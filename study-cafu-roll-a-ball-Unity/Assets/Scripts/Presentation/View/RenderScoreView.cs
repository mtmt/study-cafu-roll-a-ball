using StudyCafuRollABall.Presentation.Presenter;
using UnityEngine.UI;
using Zenject;

namespace StudyCafuRollABall.Presentation.View
{
    public class RenderScoreView : IRenderScoreView
    {
        public RenderScoreView([Inject(Id = "CountText")]Text text)
        {
            this.text = text;
        }

        Text text;

        public void Render(string scoreText)
        {
            text.text = scoreText;
        }
    }
}
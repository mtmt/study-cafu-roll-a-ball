using StudyCafuRollABall.Domain.Structure;
using StudyCafuRollABall.Domain.UseCase;

namespace StudyCafuRollABall.Presentation.Presenter
{
    public class RenderScorePresenter : IRenderScorePresenter
    {
        public RenderScorePresenter(IRenderScoreView view)
        {
            this.view = view;
        }

        readonly IRenderScoreView view;

        public void Render(IRenderScoreStructure presentationScoreStructure)
        {
            view.Render(presentationScoreStructure.ScoreText);
        }
    }
}
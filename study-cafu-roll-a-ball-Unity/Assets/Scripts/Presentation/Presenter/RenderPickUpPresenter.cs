using StudyCafuRollABall.Domain.Structure;
using StudyCafuRollABall.Domain.UseCase;

namespace StudyCafuRollABall.Presentation.Presenter
{
    public class RenderPickUpPresenter : IRenderPickUpPresenter
    {
        public RenderPickUpPresenter(IRenderPickUpView view)
        {
            this.view = view;
        }

        IRenderPickUpView view;

        public void Render(IRenderPickUpStructure structure)
        {
            view.Render(structure.IsVisible);
        }
    }
}
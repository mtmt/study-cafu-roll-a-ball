using StudyCafuRollABall.Domain.UseCase;

namespace StudyCafuRollABall.Presentation.Presenter
{
    class RenderWinTextPresenter : IRenderWinTextPresenter
    {
        public RenderWinTextPresenter(IRenderWinTextView view)
        {
            this.view = view;
        }
        
        readonly IRenderWinTextView view;

        public void SetText(string text)
        {
            view.SetText(text);
        }
    }
}
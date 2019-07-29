using StudyCafuRollABall.Presentation.Presenter;
using UnityEngine.UI;
using Zenject;

namespace StudyCafuRollABall.Presentation.View
{
    public class RenderWinTextView : IRenderWinTextView
    {
        public RenderWinTextView([Inject(Id = "WinText")]Text text)
        {
            this.text = text;
        }

        readonly Text text;

        public void SetText(string text)
        {
            this.text.text = text;
        }
    }
}
using StudyCafuRollABall.Presentation.Presenter;
using UnityEngine;
using Zenject;

namespace StudyCafuRollABall.Presentation.View
{
    public class RenderPickUpView : IRenderPickUpView
    {
        public RenderPickUpView([Inject(Id = "PickUp")] Transform transform)
        {
            gameObject = transform.gameObject;
        }

        readonly GameObject gameObject;

        public void Render(bool isVisible)
        {
            gameObject.SetActive(isVisible);
        }
    }
}
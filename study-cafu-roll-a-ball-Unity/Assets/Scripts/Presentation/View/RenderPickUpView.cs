using StudyCafuRollABall.Presentation.Presenter;
using UnityEngine;
using Zenject;

namespace StudyCafuRollABall.Presentation.View
{
    public class RenderPickUpView : IRenderPickUpView
    {
        public RenderPickUpView([Inject(Id = "PickUp")]Transform transform)
        {
            this.transform = transform;
        }

        readonly Transform transform;

        public void Render(bool isVisible)
        {
            transform.gameObject.SetActive(isVisible);
        }
    }
}
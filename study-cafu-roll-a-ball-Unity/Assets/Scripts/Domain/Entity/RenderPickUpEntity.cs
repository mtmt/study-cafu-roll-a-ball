using UniRx;

namespace StudyCafuRollABall.Domain.Entity
{
    public class RenderPickUpEntity : IRenderPickUpEntity
    {
        public RenderPickUpEntity(bool isVisible)
        {
            IsVisible = new BoolReactiveProperty(isVisible);
        }

        public BoolReactiveProperty IsVisible { get; }

        public void Show()
        {
            IsVisible.Value = true;
        }

        public void Hide()
        {
            IsVisible.Value = false;
        }
    }
}
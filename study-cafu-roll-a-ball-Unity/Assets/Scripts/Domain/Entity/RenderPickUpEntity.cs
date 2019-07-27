using UniRx;

namespace StudyCafuRollABall.Domain.Entity
{
    public class RenderPickUpEntity : IRenderPickUpEntity
    {
        public BoolReactiveProperty IsVisible { get; } = new BoolReactiveProperty();
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
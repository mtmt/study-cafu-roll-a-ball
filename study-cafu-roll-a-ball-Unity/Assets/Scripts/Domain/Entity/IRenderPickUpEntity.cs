using CAFU.Core;
using UniRx;

namespace StudyCafuRollABall.Domain.Entity
{
    public interface IRenderPickUpEntity : IEntity
    {
        BoolReactiveProperty IsVisible { get; }
        void Show();
        void Hide();
    }
}
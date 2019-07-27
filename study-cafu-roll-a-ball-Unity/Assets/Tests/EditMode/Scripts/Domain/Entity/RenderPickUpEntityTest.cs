using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using UniRx;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.Entity
{
    public class RenderPickUpEntityTest : ZenjectUnitTestFixture
    {
        [Inject] IFactory<bool, IRenderPickUpEntity> factory;

        [SetUp]
        public void 前準備()
        {
            Container.BindIFactory<bool, IRenderPickUpEntity>()
                .To<RenderPickUpEntity>();

            Container.Inject(this);
        }

        [Test]
        public void 生成できる()
        {
            var actual = factory.Create(false);
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void 表示状態にできる()
        {
            var entity = factory.Create(false);
            entity.Show();
            var actual = entity.IsVisible.Value;

            Assert.That(actual, Is.True);
        }

        [Test]
        public void 非表示状態にできる()
        {
            var entity = factory.Create(true);
            entity.Hide();
            var actual = entity.IsVisible.Value;

            Assert.That(actual, Is.False);
        }

        [Test]
        public void 状態の変化を検出できる()
        {
            var entity = factory.Create(false);
            var actual = false;
            entity.IsVisible.Subscribe(r => actual = r);

            Assert.That(actual, Is.False);

            entity.Show();
            Assert.That(actual, Is.True);

            entity.Hide();
            Assert.That(actual, Is.False);
        }
    }
}
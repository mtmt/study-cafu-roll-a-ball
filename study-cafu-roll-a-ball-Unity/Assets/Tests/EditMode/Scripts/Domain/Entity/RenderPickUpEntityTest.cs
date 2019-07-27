using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using UniRx;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.Entity
{
    public class RenderPickUpEntityTest : ZenjectUnitTestFixture
    {
        [Inject] IRenderPickUpEntity entity;

        [SetUp]
        public void 前準備()
        {
            Container.BindInterfacesTo<RenderPickUpEntity>().AsCached();

            Container.Inject(this);
        }

        [Test]
        public void 生成できる()
        {
            Assert.That(entity, Is.Not.Null);
        }

        [Test]
        public void 表示状態にできる()
        {
            entity.Show();
            var actual = entity.IsVisible.Value;

            Assert.That(actual, Is.True);
        }

        [Test]
        public void 非表示状態にできる()
        {
            entity.Hide();
            var actual = entity.IsVisible.Value;

            Assert.That(actual, Is.False);
        }

        [Test]
        public void 状態の変化を検出できる()
        {
            var actual = false;
            entity.IsVisible.Subscribe(r => actual = r);

            entity.Show();
            Assert.That(actual, Is.True);

            entity.Hide();
            Assert.That(actual, Is.False);

            entity.Show();
            Assert.That(actual, Is.True);
        }
    }
}
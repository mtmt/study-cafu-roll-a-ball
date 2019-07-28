using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.Entity
{
    [TestFixture]
    public class PointEntityTest : ZenjectUnitTestFixture
    {
        [Inject] IFactory<int, IPointEntity> factory = default;

        [SetUp]
        public void 前準備()
        {
            // entity
            Container.BindIFactory<int, IPointEntity>().To<PointEntity>();

            Container.Inject(this);
        }

        [Test]
        public void 生成できる()
        {
            var actual = factory.Create(0);

            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void 初期値を設定できる()
        {
            const int expected = 100;
            var actual = factory.Create(expected).Value;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void 加算できる()
        {
            const int p1 = 200;
            const int p2 = 300;
            const int expected = p1 + p2;
            var points1 = factory.Create(p1);
            var points2 = factory.Create(p2);
            var actual = points1.Add(points2).Value;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
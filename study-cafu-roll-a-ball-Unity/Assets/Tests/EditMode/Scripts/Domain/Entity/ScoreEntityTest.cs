using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using UniRx;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.Entity
{
    [TestFixture]
    public class ScoreEntityTest : ZenjectUnitTestFixture
    {
        [Inject] IFactory<int, IPointEntity> pointFactory;
        [Inject] IScoreEntity score;

        [SetUp]
        public void 前準備()
        {
            // entity
            Container.BindIFactory<int, IPointEntity>().To<PointEntity>();
            Container.BindInterfacesTo<ScoreEntity>().AsCached();

            Container.Inject(this);
        }

        [Test]
        public void 生成できる()
        {
            Assert.That(score, Is.Not.Null);
        }

        [Test]
        public void 値を設定できる()
        {
            const int expected = 100;
            var points = pointFactory.Create(expected);
            score.Set(points);

            var actual = score.Points.Value.Value;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void 得点の変更を検知できる()
        {
            var actual = 0;
            score.Points.Subscribe(x => actual = x.Value);

            Assert.That(actual, Is.Zero);

            const int expected = 200;
            var points = pointFactory.Create(expected);
            score.Set(points);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void 加点できる()
        {
            var actual = 0;
            score.Points.Subscribe(x => actual = x.Value);

            Assert.That(actual, Is.Zero);

            const int initialExpected = 200;
            var initialPoints = pointFactory.Create(initialExpected);
            score.Set(initialPoints);

            Assert.That(actual, Is.EqualTo(initialExpected));

            const int addition = 300;
            const int expected = initialExpected + addition;
            var points = pointFactory.Create(addition);
            score.Add(points);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
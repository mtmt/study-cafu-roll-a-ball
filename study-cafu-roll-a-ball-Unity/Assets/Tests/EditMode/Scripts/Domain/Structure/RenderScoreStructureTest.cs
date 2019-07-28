using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.Structure
{
    [TestFixture]
    public class RenderScoreStructureTest : ZenjectUnitTestFixture
    {
        [Inject] IFactory<int, IPointEntity> pointFactory;
        [Inject] IScoreEntity score;
        [Inject] IFactory<IScoreEntity, IRenderScoreStructure> factory;

        [SetUp]
        public void 前準備()
        {
            // entity
            Container.BindIFactory<int, IPointEntity>().To<PointEntity>();
            Container.BindInterfacesTo<ScoreEntity>().AsCached();

            // structure
            Container.BindIFactory<IScoreEntity, IRenderScoreStructure>()
                .To<RenderScoreStructure>();

            Container.Inject(this);
        }

        [Test]
        public void 生成できる()
        {
            var actual = factory.Create(score);

            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void 内容が反映される()
        {
            const int p = 100;
            var points = pointFactory.Create(p);
            score.Set(points);

            var expected = p.ToString();
            var actual = factory.Create(score).ScoreText;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
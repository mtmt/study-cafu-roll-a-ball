using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using StudyCafuRollABall.Domain.Translator;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.Translator
{
    [TestFixture]
    public class RenderScoreTranslatorTest : ZenjectUnitTestFixture
    {
        [Inject] IFactory<int, IPointEntity> pointFactory = default;
        [Inject] IScoreEntity score = default;
        [Inject] IRenderScoreTranslator translator = default;

        [SetUp]
        public void 前準備()
        {
            // entity
            Container.BindIFactory<int, IPointEntity>().To<PointEntity>();
            Container.BindInterfacesTo<ScoreEntity>().AsCached();
            
            // structure
            Container.BindIFactory<IScoreEntity, IRenderScoreStructure>()
                .To<RenderScoreStructure>();

            // translator
            Container.BindInterfacesTo<RenderScoreTranslator>().AsCached();

            Container.Inject(this);
        }

        [Test]
        public void 生成できる()
        {
            Assert.That(translator, Is.Not.Null);
        }

        [Test]
        public void 変換できる()
        {
            const int p = 100;
            var points = pointFactory.Create(p);
            score.Set(points);

            var expected = p.ToString();
            var actual = translator.Translate(score).ScoreText;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
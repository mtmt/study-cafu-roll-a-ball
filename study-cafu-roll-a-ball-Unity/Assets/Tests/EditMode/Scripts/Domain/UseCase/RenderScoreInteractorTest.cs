using Moq;
using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using StudyCafuRollABall.Domain.Translator;
using StudyCafuRollABall.Domain.UseCase;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.UseCase
{
    [TestFixture]
    public class RenderScoreInteractorTest : ZenjectUnitTestFixture
    {
        [Inject] IFactory<int, IPointEntity> factory = default;
        [Inject] IScoreEntity score = default;
        [Inject] IRenderScoreUseCase useCase = default;
        [Inject] Mock<IRenderScorePresenter> mock = default;

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

            // use case
            Container.BindInterfacesTo<RenderScoreInteractor>().AsCached();

            // presenter
            var mock = new Mock<IRenderScorePresenter>();
            Container.BindInstance(mock.Object);
            Container.BindInstance(mock);

            Container.Inject(this);
        }

        [Test]
        public void 生成できる()
        {
            Assert.That(useCase, Is.Not.Null);
        }

        [Test]
        public void 得点の変更を検知して表示する()
        {
            const int p = 100;
            var points = factory.Create(p);
            score.Add(points);

            var expected = p.ToString();

            // presenterのrender()が正しい引数(structure)で
            // 呼び出されていることを確認する。
            mock.Verify(
                x => x.Render(It.Is<IRenderScoreStructure>(
                    structure => structure.ScoreText == expected)
                )
            );
        }
    }
}
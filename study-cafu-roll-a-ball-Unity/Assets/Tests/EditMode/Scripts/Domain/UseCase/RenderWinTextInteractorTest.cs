using Moq;
using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.UseCase;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.UseCase
{
    public class RenderWinTextInteractorTest : ZenjectUnitTestFixture
    {
        [Inject] IFactory<int, IPointEntity> pointFactory = default;
        [Inject] IScoreEntity score = default;
        [Inject] IRenderWinTextUseCase useCase = default;
        [Inject] Mock<IRenderWinTextPresenter> mock = default;

        [SetUp]
        public void 前準備()
        {
            // entity
            Container.BindIFactory<int, IPointEntity>().To<PointEntity>();
            Container.BindInterfacesTo<ScoreEntity>().AsCached();

            // use case
            Container.BindInterfacesTo<RenderWinTextInteractor>().AsCached();

            // presenter
            var m = new Mock<IRenderWinTextPresenter>();
            Container.BindInstance(m.Object);
            Container.BindInstance(m);

            Container.Inject(this);
        }

        [Test]
        public void 生成できる()
        {
            Assert.That(useCase, Is.Not.Null);
        }

        [Test]
        public void 初期化時に空文字を表示している()
        {
            const string expected = "";
            mock.Verify(x => x.SetText(expected), Times.Once);
        }

        [Test]
        public void 規定の得点に達したときに特定の文字列を表示できる()
        {
            const int goal = 12;
            var point = pointFactory.Create(goal);
            score.Add(point);

            const string expected = "You Win!";
            mock.Verify(x => x.SetText(expected), Times.Once);
        }
    }
}
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
        public void 初期化時に非表示にしている()
        {
            mock.Verify(x => x.Show(), Times.Never);
            mock.Verify(x => x.Hide(), Times.Once);
        }

        [Test]
        public void 規定の得点に達したときに表示できる()
        {
            const int goal = 12;
            var point = pointFactory.Create(goal);
            score.Add(point);

            mock.Verify(x => x.Show(), Times.Once);
        }
    }
}
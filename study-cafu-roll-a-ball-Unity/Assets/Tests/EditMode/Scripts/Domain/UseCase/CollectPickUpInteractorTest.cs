using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using StudyCafuRollABall.Domain.UseCase;
using UniRx;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.UseCase
{
    public class CollectPickUpInteractorTest : ZenjectUnitTestFixture
    {
        [Inject] IScoreEntity score = default;
        [Inject] ICollectPickUpUseCase useCase = default;

        [SetUp]
        public void 前準備()
        {
            // entity
            Container.BindIFactory<int, IPointEntity>().To<PointEntity>();
            Container.BindInterfacesTo<ScoreEntity>().AsCached();

            // structure
            Container.BindIFactory<string, ICollectPickUpStructure>()
                .To<CollectPickUpStructure>();

            // use case
            Container.BindInterfacesTo<CollectPickUpInteractor>().AsCached();

            Container.Inject(this);
        }

        [Test]
        public void 生成できる()
        {
            Assert.That(useCase, Is.Not.Null);
        }

        [Test]
        public void 収集できる()
        {
            const string expected = "Name of Pick Up";
            string actual = "";
            MessageBroker.Default.Receive<ICollectPickUpStructure>()
                .Subscribe(structure => actual = structure.Name);

            useCase.Collect(expected);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void 収集してスコアを1点だけ加点できる()
        {
            var actual = 0;
            score.Points.Subscribe(x => actual = x.Value);

            // 最初は0点のはず
            Assert.That(actual, Is.Zero);

            const string dummy = "Name of Pick Up";
            useCase.Collect(dummy);

            // 収集後に1点になるはず。
            const int expected = 1;
            Assert.That(actual, Is.EqualTo(expected));

        }
    }
}
using NUnit.Framework;
using StudyCafuRollABall.Domain.Structure;
using StudyCafuRollABall.Domain.UseCase;
using UniRx;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.UseCase
{
    public class CollectPickUpInteractorTest : ZenjectUnitTestFixture
    {
        [Inject] ICollectPickUpUseCase useCase;

        [SetUp]
        public void 前準備()
        {
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
    }
}
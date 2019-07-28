using Moq;
using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using StudyCafuRollABall.Domain.UseCase;
using UniRx;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.UseCase
{
    public class DespawnPickUpInteractorTest : ZenjectUnitTestFixture
    {
        const string Name = "Name of Pick Up";
        [Inject] Mock<IRenderPickUpEntity> mockEntity;
        [Inject] IFactory<string, ICollectPickUpStructure> factory;
        [Inject] IDespawnPickUpUseCase useCase;

        [SetUp]
        public void 前準備()
        {
            // entity
            var mock = new Mock<IRenderPickUpEntity>();
            Container.BindInstance(mock.Object);
            Container.BindInstance(mock);

            // structure
            Container.BindIFactory<string, ICollectPickUpStructure>()
                .To<CollectPickUpStructure>();

            // use case
            Container.BindInterfacesTo<DespawnPickUpInteractor>().AsCached()
                .WithArguments(Name);

            Container.Inject(this);
        }

        [Test]
        public void 生成できる()
        {
            Assert.That(useCase, Is.Not.Null);
        }

        [Test]
        public void メッセージを受け取ってentityのメソッドを呼ぶことができる()
        {
            // 仮のメッセージを送信
            var structure = factory.Create(Name);
            MessageBroker.Default.Publish(structure);

            // DespawnPickUpInteractorでメッセージを受け取って，
            // RenderPickUpEntityのHide()を1回だけ呼び出せているかどうか?
            mockEntity.Verify(x => x.Hide(), Times.Once);
        }
    }
}
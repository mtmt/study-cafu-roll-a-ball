using Moq;
using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using StudyCafuRollABall.Domain.Translator;
using StudyCafuRollABall.Domain.UseCase;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.UseCase
{
    public class RenderPickUpInteractorTest : ZenjectUnitTestFixture
    {
        [Inject] IRenderPickUpEntity entity;
        [Inject] IRenderPickUpTranslator translator;
        [Inject] IRenderPickUpUseCase useCase;
        [Inject] Mock<IRenderPickUpPresenter> mockPresenter;

        [SetUp]
        public void 前準備()
        {
            // entity
            Container.BindInterfacesTo<RenderPickUpEntity>().AsCached()
                .WithArguments(true);

            // structure
            Container.BindIFactory<bool, IRenderPickUpStructure>()
                .To<RenderPickUpStructure>();

            // translator
            Container.BindInterfacesTo<RenderPickUpTranslator>().AsCached();

            // use case
            Container.BindInterfacesTo<RenderPickUpInteractor>().AsCached();

            // presenter
            var mock = new Mock<IRenderPickUpPresenter>();
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
        public void 表示できる()
        {
            var expected = entity.IsVisible.Value;
            useCase.Render(entity);

            // mockのpresenterのrender()が正しい引数(structure)で
            // 呼び出されていることを確認する。
            mockPresenter.Verify(
                x => x.Render(It.Is<IRenderPickUpStructure>(
                    structure => structure.IsVisible == expected)
                )
            );
        }
    }
}
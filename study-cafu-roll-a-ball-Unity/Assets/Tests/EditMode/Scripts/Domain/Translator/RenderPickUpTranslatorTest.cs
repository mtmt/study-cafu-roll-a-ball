using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using StudyCafuRollABall.Domain.Translator;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.Translator
{
    public class RenderPickUpTranslatorTest : ZenjectUnitTestFixture
    {
        [Inject] IFactory<bool, IRenderPickUpEntity> entityFactory;
        [Inject] IFactory<bool, IRenderPickUpStructure> structureFactory;
        [Inject] IRenderPickUpTranslator translator;

        [SetUp]
        public void 前準備()
        {
            // entity
            Container.BindIFactory<bool, IRenderPickUpEntity>()
                .To<RenderPickUpEntity>();

            // structure
            Container.BindIFactory<bool, IRenderPickUpStructure>()
                .To<RenderPickUpStructure>();

            // translator
            Container.BindInterfacesTo<RenderPickUpTranslator>().AsCached();

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
            const bool expected = true;
            var entity = entityFactory.Create(expected);
            var actual = translator.Translate(entity).IsVisible;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
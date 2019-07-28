using NUnit.Framework;
using StudyCafuRollABall.Domain.Structure;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.Structure
{
    public class RenderPickUpStructureTest : ZenjectUnitTestFixture
    {
        [Inject] IFactory<bool, IRenderPickUpStructure> factory = default;

        [SetUp]
        public void 前準備()
        {
            Container.BindIFactory<bool, IRenderPickUpStructure>()
                .To<RenderPickUpStructure>();

            Container.Inject(this);
        }

        [Test]
        public void 生成できる()
        {
            var actual = factory.Create(true);
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void 値を反映できる()
        {
            const bool expected = false;
            var actual = factory.Create(false).IsVisible;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
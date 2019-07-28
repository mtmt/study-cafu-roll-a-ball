using NUnit.Framework;
using StudyCafuRollABall.Domain.Structure;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.Structure
{
    public class CollectPickUpStructureTest : ZenjectUnitTestFixture
    {
        [Inject] IFactory<string, ICollectPickUpStructure> factory = default;

        [SetUp]
        public void 前準備()
        {
            // structure
            Container.BindIFactory<string, ICollectPickUpStructure>()
                .To<CollectPickUpStructure>();

            Container.Inject(this);
        }

        [Test]
        public void 生成できる()
        {
            var actual = factory.Create("");
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void 値を反映できる()
        {
            const string expected = "Foo";
            var actual = factory.Create(expected).Name;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
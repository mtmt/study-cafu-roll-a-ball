using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using Zenject;

namespace StudyCafuRollABall.Domain.Translator
{
    public class RenderPickUpTranslator : IRenderPickUpTranslator
    {
        public RenderPickUpTranslator(IFactory<bool, IRenderPickUpStructure> factory)
        {
            this.factory = factory;
        }

        IFactory<bool, IRenderPickUpStructure> factory;

        public IRenderPickUpStructure Translate(IRenderPickUpEntity param1)
        {
            return factory.Create(param1.IsVisible.Value);
        }
    }
}
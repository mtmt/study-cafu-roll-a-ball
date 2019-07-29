using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;
using Zenject;

namespace StudyCafuRollABall.Domain.Translator
{
    public class RenderScoreTranslator : IRenderScoreTranslator
    {
        public RenderScoreTranslator(IFactory<IScoreEntity, IRenderScoreStructure> factory)
        {
            this.factory = factory;
        }

        readonly IFactory<IScoreEntity, IRenderScoreStructure> factory;

        public IRenderScoreStructure Translate(IScoreEntity param1)
        {
            return factory.Create(param1);
        }
    }
}
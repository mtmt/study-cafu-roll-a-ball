using CAFU.Core;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.Structure;

namespace StudyCafuRollABall.Domain.Translator
{
    public interface IRenderScoreTranslator : ITranslator<IScoreEntity, IRenderScoreStructure>
    {
    }
}
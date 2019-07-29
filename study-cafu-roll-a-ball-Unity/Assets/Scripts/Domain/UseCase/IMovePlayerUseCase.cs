using CAFU.Core;
using UnityEngine;

namespace StudyCafuRollABall.Domain.UseCase
{
    public interface IMovePlayerUseCase : IUseCase
    {
        float Speed { get; }
        void Move(Vector3 direction);
    }
}
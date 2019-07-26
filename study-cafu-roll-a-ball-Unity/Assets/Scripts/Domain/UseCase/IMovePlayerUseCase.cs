using CAFU.Core;
using UnityEngine;

namespace StudyCafuRollABall.Domain.UseCase
{
    public interface IMovePlayerUseCase : IUseCase
    {
        void Move(Vector3 direction);
    }
}
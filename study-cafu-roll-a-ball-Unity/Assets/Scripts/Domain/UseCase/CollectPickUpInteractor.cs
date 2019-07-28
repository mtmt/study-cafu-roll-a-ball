using UnityEngine;

namespace StudyCafuRollABall.Domain.UseCase
{
    class CollectPickUpInteractor : ICollectPickUpUseCase
    {
        public void Collent(string name)
        {
            Debug.Log($"Collect! -> {name}");
        }
    }
}
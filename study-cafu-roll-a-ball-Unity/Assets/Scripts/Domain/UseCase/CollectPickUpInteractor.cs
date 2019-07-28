using UnityEngine;

namespace StudyCafuRollABall.Domain.UseCase
{
    class CollectPickUpInteractor : ICollectPickUpUseCase
    {
        public void Collect(string name)
        {
            Debug.Log($"Collect! -> {name}");
        }
    }
}
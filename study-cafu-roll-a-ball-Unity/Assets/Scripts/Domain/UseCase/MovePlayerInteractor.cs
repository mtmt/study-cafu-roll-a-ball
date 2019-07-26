using StudyCafuRollABall.Domain.Entity;
using UnityEngine;

namespace StudyCafuRollABall.Domain.UseCase
{
    public class MovePlayerInteractor : IMovePlayerUseCase
    {
        public MovePlayerInteractor(IPlayerEntity entity, float speed)
        {
            this.entity = entity;
            Speed = speed;
        }

        readonly IPlayerEntity entity;
        public float Speed { get; }

        public void Move(Vector3 direction)
        {
            entity.AddForce(direction * Speed);
        }
    }
}
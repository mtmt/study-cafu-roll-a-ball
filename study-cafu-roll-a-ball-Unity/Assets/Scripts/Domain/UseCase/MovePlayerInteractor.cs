using StudyCafuRollABall.Domain.Entity;
using UnityEngine;

namespace StudyCafuRollABall.Domain.UseCase
{
    public class MovePlayerInteractor : IMovePlayerUseCase
    {
        public MovePlayerInteractor(IPlayerEntity entity, float speed)
        {
            this.entity = entity;
            this.speed = speed;
        }

        readonly IPlayerEntity entity;
        readonly float speed;

        public void Move(Vector3 direction)
        {
            entity.AddForce(direction * speed);
        }
    }
}
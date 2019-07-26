using Moq;
using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using StudyCafuRollABall.Domain.UseCase;
using UnityEngine;
using Zenject;

namespace StudyCafuRollABall.Tests.EditMode.Scripts.Domain.UseCase
{
    public class MovePlayerInteractorTest : ZenjectUnitTestFixture
    {
        static readonly Vector3 Direction = Vector3.forward;
        const float Speed = 3.0f;

        [Inject] IPlayerEntity entity;
        [Inject] IMovePlayerUseCase useCase;
        [Inject] Mock<IPlayerEntity> mockEntity;

        [SetUp]
        public void 前準備()
        {
            var mock = new Mock<IPlayerEntity>();
            Container.BindInstance(mock.Object);
            Container.BindInstance(mock);
            Container.BindInterfacesTo<MovePlayerInteractor>().AsCached()
                .WithArguments(Speed);

            Container.Inject(this);
        }

        [Test]
        public void 生成できる()
        {
            Assert.That(useCase, Is.Not.Null);
        }

        [Test]
        public void 速度の値が取得できる()
        {
            var actual = useCase.Speed;
            const float expected = Speed;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void 力をentityに加えることができる()
        {
            // 方向を指定すると……
            useCase.Move(Direction);

            // Speedを掛けた値の力をentityに加えることができているはず。
            mockEntity.Verify(x => x.AddForce(Direction * Speed));
        }
    }
}
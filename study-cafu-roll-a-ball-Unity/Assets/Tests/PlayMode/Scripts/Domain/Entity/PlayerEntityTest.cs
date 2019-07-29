using System.Collections;
using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace StudyCafuRollABall.Tests.PlayMode.Scripts.Domain.Entity
{
    public class PlayerEntityTest : ZenjectIntegrationTestFixture
    {
        [Inject] IPlayerEntity playerEntity = default;

        [SetUp]
        public void 前準備()
        {
            PreInstall();

            // テスト用のRigidbody
            var rigidbody = new GameObject().AddComponent<Rigidbody>();

            Container.BindInterfacesTo<PlayerEntity>().AsCached()
                .WithArguments(rigidbody);

            Container.Inject(this);

            PostInstall();
        }

        [UnityTest]
        public IEnumerator 生成できる()
        {
            Assert.That(playerEntity, Is.Not.Null);
            yield break;
        }

        [UnityTest]
        public IEnumerator 力を加えて移動することができる()
        {
            // スタート時は初期位置のはず。
            var initialActual = playerEntity.Position.z;
            var initialExpected = Vector3.zero.z;
            Assert.That(initialActual, Is.EqualTo(initialExpected));

            // 前方に適当に力を加える。
            playerEntity.AddForce(Vector3.forward * 100f);

            // n秒待機する。
            const float n = 0.5f;
            yield return new WaitForSeconds(n);

            // 前方に進んでいればOK
            var resultActual = playerEntity.Position.z;
            var resultExpected = Vector3.zero.z;
            Assert.That(resultActual, Is.GreaterThan(resultExpected));
        }
    }
}
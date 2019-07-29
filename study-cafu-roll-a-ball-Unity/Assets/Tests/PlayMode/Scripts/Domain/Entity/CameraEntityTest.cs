using System.Collections;
using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace StudyCafuRollABall.Tests.PlayMode.Scripts.Domain.Entity
{
    public class CameraEntityTest : ZenjectIntegrationTestFixture
    {
        [Inject] ICameraEntity entity = default;
        GameObject camera = default;
        GameObject target = default;

        [SetUp]
        public void 前準備()
        {
            PreInstall();

            // カメラの初期位置は(0, 0, 0)
            camera = new GameObject();

            // ターゲットの初期位置は(1, 1, 1)
            target = new GameObject();
            target.transform.position = Vector3.one;

            Container.BindInterfacesTo<CameraEntity>().AsCached()
                .WithArguments(camera.transform, target.transform);

            Container.Inject(this);

            PostInstall();
        }

        [UnityTest]
        public IEnumerator 生成できる()
        {
            Assert.That(entity, Is.Not.Null);
            yield break;
        }

        [UnityTest]
        public IEnumerator ターゲットの移動に追従できる()
        {
            var transform = camera.transform;
            var targetTransform = target.transform;

            // スタート時は初期位置のはず。
            var initialActual = transform.position;
            var initialExpected = Vector3.zero;
            Assert.That(initialActual, Is.EqualTo(initialExpected));

            // ターゲットを動かす。
            var targetPosition = targetTransform.position;
            var movement = new Vector3(3, 4, 5);
            targetTransform.position = targetPosition + movement;

            // 1フレーム待つ
            yield return null;

            // 同様に移動していればOK
            var actual = transform.position;
            var expected = initialExpected + movement;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
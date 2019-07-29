using System.Collections;
using NUnit.Framework;
using StudyCafuRollABall.Domain.Entity;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace StudyCafuRollABall.Tests.PlayMode.Scripts.Domain.Entity
{
    public class RotatePickUpEntityTest : ZenjectIntegrationTestFixture
    {
        [Inject] IRotatePickUpEntity entity = default;
        Transform transform = default;

        [SetUp]
        public void 前準備()
        {
            PreInstall();

            var go = new GameObject();
            transform = go.transform;
            transform.rotation = Quaternion.identity;

            Container.BindInterfacesTo<RotatePickUpEntity>().AsCached()
                .WithArguments(transform);

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
        public IEnumerator 回転できる()
        {
            // 自前計算と合致すればOKとする。

            // 自前計算分
            var go = new GameObject();
            go.transform.rotation = transform.rotation;

            // 数フレーム待つ
            yield return null;

            go.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

            yield return null;

            go.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

            yield return null;

            go.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

            // 合致していればOK
            var actual = transform.rotation;
            var expected = go.transform.rotation;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
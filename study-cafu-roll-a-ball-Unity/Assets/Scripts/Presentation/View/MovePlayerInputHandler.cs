using System;
using StudyCafuRollABall.Presentation.Controller;
using UniRx;
using UnityEngine;
using Zenject;

namespace StudyCafuRollABall.Presentation.View
{
    public class MovePlayerInputHandler : IDirectionTrigger, IFixedTickable
    {
        readonly Subject<Vector3> subject = new Subject<Vector3>();
        public IObservable<Vector3> Stream => subject;

        public void FixedTick()
        {
            var h = Input.GetAxis ("Horizontal");
            var v = Input.GetAxis ("Vertical");
            var direction = new Vector3 (h, 0.0f, v);

            subject.OnNext(direction);
        }
    }
}
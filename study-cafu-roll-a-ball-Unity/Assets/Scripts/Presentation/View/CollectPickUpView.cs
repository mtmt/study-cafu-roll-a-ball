using System;
using StudyCafuRollABall.Presentation.Controller;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace StudyCafuRollABall.Presentation.View
{
    public class CollectPickUpView : MonoBehaviour, ICollectPickUpView
    {
        public IObservable<Collider> OnCollectAsObservable()
        {
            return this.OnTriggerEnterAsObservable()
                .Where(x => x.gameObject.CompareTag("Pick Up"));
        }
    }
}
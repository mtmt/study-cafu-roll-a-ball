using System;
using UnityEngine;

namespace StudyCafuRollABall.Presentation.Controller
{
    public interface ICollectPickUpView
    {
        IObservable<Collider> OnCollectAsObservable();
    }
}
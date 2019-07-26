using System;
using CAFU.Core;
using UnityEngine;

namespace StudyCafuRollABall.Presentation.Controller
{
    public interface IDirectionTrigger : IView
    {
        IObservable<Vector3> Stream { get; }
    }
}
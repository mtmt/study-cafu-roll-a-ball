using System;
using UniRx;
using UnityEngine;

namespace StudyCafuRollABall.Presentation.Controller
{
    public class CollectPickUpController : IDisposable
    {
        public CollectPickUpController(ICollectPickUpView view)
        {
            view.OnCollectAsObservable().Select(x => x.gameObject.name)
                .Subscribe(name => { Debug.Log(name); })
                .AddTo(disposable);
        }

        readonly CompositeDisposable disposable = new CompositeDisposable();

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}
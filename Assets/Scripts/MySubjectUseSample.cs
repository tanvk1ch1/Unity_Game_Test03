using System;
using UnityEngine;

namespace UniRXSample
{
    public sealed class MySubjectUseSample : MonoBehaviour
    {
        private void Start()
        {
            // MySubject作成
            var mySubject = new MySubject<string>();
            
            // Observer登録
            var disposable = mySubject.Subscribe(new DisplayLogObserver());
            
            mySubject.OnNext("Hello");
            mySubject.OnNext("World!");
            
            // 購読中止
            disposable.Dispose();
            
            mySubject.OnCompleted();
            mySubject.Dispose();
        }
    }
}
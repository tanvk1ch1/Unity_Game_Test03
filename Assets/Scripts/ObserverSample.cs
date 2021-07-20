using System;
using UnityEngine;

namespace UniRXSample
{
    public sealed class ObserverSample : MonoBehaviour
    {
        private void Start()
        {
            // Observerを手動作成
            IObserver<string> observer = new DisplayLogObserver();
            
            // メッセージを発行する
            observer.OnNext("Hello");
            observer.OnNext("World!");
            observer.OnCompleted();
        }
    }
    
    public sealed class DisplayLogObserver : IObserver<string>
    {
        public void OnCompleted()
        {
            Debug.Log("ログの発行が完了しました。");
        }
        
        public void OnError(Exception error)
        {
            Debug.Log($"例外が発生しました:{error}");
        }
        
        public void OnNext(string value)
        {
            Debug.Log($"メッセージが発行されました:{value}");
        }
    }
}
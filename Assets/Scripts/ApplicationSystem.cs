using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UniRx;

namespace Shima
{
    public class ApplicationSystem : MonoBehaviour
    {
        static private ApplicationSystem instance;
        
        #region Members
        
        [SerializeField] 
        private GameObject sceneSystem;
        
        #endregion
        
        #region Method
        
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            instance = this;
            SceneManager.activeSceneChanged += ((scene1, scene2) =>
            {
                
            });
        }
        
        #endregion
    }
}
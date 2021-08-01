using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shima
{
    public class SceneSystem : MonoBehaviour
    {
        #region Members
        
        private Scenes currentScene = Scenes.Login;
        
        public bool IsModeSelect
        {
            get
            {
                return SceneManager.GetActiveScene().name == Scenes.ModeSelect.ToString();
            }
        }
        
        #endregion
        
        #region Method

        public void StartBattleMode()
        {
            ChangeSceneWithLoad(Scenes.BattleMode);
        }
        
        public void StartMap()
        {
            ChangeSceneWithLoad(Scenes.Map);
        }
        
        public void ChangeScene(Scenes sceneName, float delay = 0)
        {
            StartCoroutine(ChangeSceneCoroutine(sceneName, delay));
        }
        
        public void ChangeSceneWithLoad(Scenes scene)
        {
            StartCoroutine(WaitLoad(scene));
        }
        
        private IEnumerator WaitLoad(Scenes sceneName)
        {
            // yield return ChangeSceneCoroutine(Scenes.Loading);
            
            yield return ChangeSceneCoroutine(sceneName);
        }
        
        private IEnumerator ChangeSceneCoroutine(Scenes sceneName, float delay = 0)
        {
            currentScene = sceneName;
            yield return new WaitForSeconds(delay);
            SceneManager.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Single);
            while (!SceneManager.GetActiveScene().name.Equals(sceneName.ToString()))
            {
                yield return null;
            }
        }
        
        #endregion
        
        #region MonoBehavior
        
        private void Start()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
        
        private void OnDestroy()
        {
            Resources.UnloadUnusedAssets();
        }
        
        #endregion
    }
}
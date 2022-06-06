using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTools.Runtime.Navigation;

namespace ImportantPrototype.System
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        private SceneReference _master;
     
        private void OnEnable()
        {
            SceneManager.sceneLoaded += LoadMasterScene;
        }

        public void OnDisable()
        {
            SceneManager.sceneLoaded -= LoadMasterScene;
        }

        private void LoadMasterScene(Scene scene, LoadSceneMode loadMode)
        {
            if (_master.IsLoaded) return;
            SceneManager.LoadScene(_master.sceneName, LoadSceneMode.Additive);
        }
    }
}
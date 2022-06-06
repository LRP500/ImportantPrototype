using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTools.Runtime.Navigation;
using UnityTools.Runtime.Time;

namespace ImportantPrototype
{
    public class GameMaster : MonoBehaviour
    {
        [SerializeField]
        private TimeManagerVariable _timeManager;
        
        [SerializeField]
        private SceneReference _titleMenu;

        [SerializeField]
        private SceneReference _gameplay;
        
        [SerializeField]
        private SceneReference _loadingScreen;

        [SerializeField]
        private List<SceneReference> _persistentScenes;
        
        private NavigationManager _navigationManager;
        
        private void Awake()
        {
            _navigationManager = FindObjectOfType<NavigationManager>();
        }

        private void Start()
        {
            if (SceneManager.sceneCount > 1)
                return;
            
            NavigateTo(_titleMenu);
        }

        private void NavigateTo(SceneReference scene)
        {
            _navigationManager.LoadSceneAndSetActive(scene);
            _timeManager.Value.Resume();
        }
        
        public void QuitToTitle()
        {
            SceneManager.UnloadSceneAsync(_gameplay.sceneName);
            NavigateTo(_titleMenu);
        }
        
        public void QuitToDesktop()
        {
            NavigationUtils.Quit();
        }

        public void RestartGame()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        
        public void LoadGame()
        {
            _navigationManager.LoadSceneAndSetActive(_gameplay, null, () =>
            {
                SceneManager.UnloadSceneAsync(_titleMenu.sceneName);
            });
        }
    }
}
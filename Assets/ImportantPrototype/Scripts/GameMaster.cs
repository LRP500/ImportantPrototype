using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTools.Runtime.Navigation;

namespace ImportantPrototype
{
    public class GameMaster : MonoBehaviour
    {
        [SerializeField]
        private SceneReference _titleMenu;

        [SerializeField]
        private SceneReference _gameplay;
        
        private NavigationManager _navigationManager;
        
        private void Awake()
        {
            _navigationManager = FindObjectOfType<NavigationManager>();
        }

        private void Start()
        {
            NavigateToTitleMenu();
        }

        private void NavigateToTitleMenu()
        {
            _navigationManager.LoadSceneAndSetActive(_titleMenu);
        }

        public void Quit()
        {
            NavigationUtils.Quit();
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
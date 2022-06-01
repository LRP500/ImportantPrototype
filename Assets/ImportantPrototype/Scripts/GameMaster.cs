using UnityEngine;
using UnityTools.Runtime.Navigation;

namespace ImportantPrototype
{
    public class GameMaster : MonoBehaviour
    {
        [SerializeField]
        private SceneReference _titleMenu;

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
            _navigationManager.LoadSceneAndSetActive(_titleMenu.sceneName);
        }
    }
}
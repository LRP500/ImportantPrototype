using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ImportantPrototype
{
    public class GameMaster : MonoBehaviour
    {
        // TODO: dropdown of all scenes
        [SerializeField]
        private string _titleMenuScene;
        
        private void Awake()
        {
            NavigateToTitleMenu();
        }

        private void NavigateToTitleMenu()
        {
            Observable.NextFrame()
                .DoOnSubscribe(() =>
                {
                    SceneManager.LoadSceneAsync(_titleMenuScene, LoadSceneMode.Additive);
                })
                .Subscribe(_ =>
                {
                    var scene = SceneManager.GetSceneByName(_titleMenuScene);
                    SceneManager.SetActiveScene(scene);
                })
                .AddTo(gameObject);
        }
    }
}
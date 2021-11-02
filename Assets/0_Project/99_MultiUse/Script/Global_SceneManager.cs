using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Event;
using UnityEngine.SceneManagement;
namespace ToronPuzzle
{
    public enum SceneType
    {
        Entry,
        Title,
        World,
        Battle
    }

    public class Global_SceneManager : MonoBehaviour
    {

        public static SceneType _currentScene;
        public static bool isSceneChanging;

        public static Global_SceneManager Instance;
        public void BeginSceneManager()
        {
            Instance = this;

            Global_UIEventSystem.Register_UIEvent<SceneType>(UIEventID.Global_씬이동, ChangeScene);
        }

        private static void LoadSceneAsync(string sceneName)
        {
            Global_UIEventSystem.Clear_SceneLocalUIEvent();
            AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        }

        private Coroutine _changeSceneRoutine = null;
        private void ChangeScene(SceneType targetSceneType)
        {
            isSceneChanging = true;
            _changeSceneRoutine = StartCoroutine(ChangeSceneRoutine(targetSceneType));
        }

        private IEnumerator ChangeSceneRoutine(SceneType targetSceneType)
        {
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블록판숨기기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_암전);
            Global_CoroutineManager.InvokeDelay(() => {
                switch (targetSceneType)
                {
                    case SceneType.Title:
                        LoadSceneAsync("Title");
                        break;
                    case SceneType.World:
                        LoadSceneAsync("World");
                        break;
                    case SceneType.Battle:
                        LoadSceneAsync("BattleScene");
                        break;
                }
            }, 1f);
            yield return new WaitForSeconds(1f);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_암전해제);

        }

    }

}

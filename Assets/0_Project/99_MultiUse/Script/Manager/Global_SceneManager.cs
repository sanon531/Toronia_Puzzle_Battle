using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Event;
using UnityEngine.SceneManagement;
using ToronPuzzle.Data;
namespace ToronPuzzle
{
    public class Global_SceneManager : MonoBehaviour
    {

        public static SceneType _currentScene;
        public static bool isSceneChanging;

        public static Global_SceneManager Instance;
        public void BeginSceneManager()
        {
            Instance = this;
            Global_UIEventSystem.Register_UIEvent<SceneType>(UIEventID.Global_씬이동, ChangeScene,EventRegistOption.Permanent);
            Global_InWorldEventSystem._on모듈항상들기 += SetIsModuleAlwaysLitfable;
            CheckSceneByName();
        }
        void CheckSceneByName()
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "BattleScene":
                    _currentScene = SceneType.Battle;
                    break;
                case "WorldMapScene":
                    _currentScene = SceneType.WorldMap;
                    break;
                default:
                    Debug.LogError("No Scene name Exist");
                    break;
            }

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
            _currentScene = targetSceneType;
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블록판숨기기);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_암전);
            Global_CoroutineManager.InvokeDelay(() => {
                switch (targetSceneType)
                {
                    case SceneType.Title:
                        LoadSceneAsync("Title");
                        break;
                    case SceneType.WorldMap:
                        LoadSceneAsync("WorldMapScene");
                        break;
                    case SceneType.Battle:
                        LoadSceneAsync("BattleScene");
                        break;
                }
            }, 1f);
            yield return new WaitForSeconds(1f);
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_암전해제);

        }


        static bool _isModuleAlwaysLiftable = false;
        void SetIsModuleAlwaysLitfable(bool _isVal) { _isModuleAlwaysLiftable = _isVal; }

        public static bool ModuleLiftable()
        {
            if (_currentScene == Data.SceneType.Battle && !_isModuleAlwaysLiftable)
                return false;
            else
                return true;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ToronPuzzle.Event;
using ToronPuzzle.UI;
using ToronPuzzle.Data;

namespace ToronPuzzle
{
    public class Global_PausePanelBack : MonoBehaviour
    {
        
        SceneType _current_sceneType = SceneType.Title;

        public void BeginPausePanelBack()
        {
            GetComponent<Button>().onClick.AddListener(() => GoBackScene());

        }
        public void CallOnChangeScene(SceneType _sceneType)
        {
            _current_sceneType = _sceneType;
        }
        void GoBackScene()
        {
            switch (_current_sceneType)
            {
                //불가능
                case SceneType.Entry:
                    Debug.LogError("Pause Button Error");
                    break;
                //게임 종료
                case SceneType.Title:
                    Debug.Log("GameEnd");
                    break;
                //타이틀 로
                case SceneType.WorldMap:
                    Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_씬이동, SceneType.Title);
                    GameObject.Find("Global_UnPauseButton").GetComponent<Button>().onClick.Invoke();
                    break;
                //타이틀 로
                case SceneType.Battle:
                    Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_씬이동, SceneType.Title);
                    GameObject.Find("Global_UnPauseButton").GetComponent<Button>().onClick.Invoke();
                    break;
                //불가능
                default:
                    Debug.LogError("Pause Button Error");
                    break;
            }

        }
    }
}

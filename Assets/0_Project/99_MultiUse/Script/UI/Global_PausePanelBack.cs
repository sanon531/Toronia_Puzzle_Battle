using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToronPuzzle.Event;
using ToronPuzzle.UI;
using ToronPuzzle.Data;
using TMPro;

namespace ToronPuzzle
{
    public class Global_PausePanelBack : MonoBehaviour
    {
        
        SceneType _current_sceneType = SceneType.Title;
        Button _button;
        TextMeshProUGUI _text;
        public void BeginPausePanelBack()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => GoBackScene());
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }
        public void CallOnChangeScene(SceneType _sceneType)
        {
            _current_sceneType = _sceneType;
        }
        public void SetActiveButton(bool _isActive)
        {
            _button.interactable = _isActive;
        }

        public void SetTextOnButton(string _content)
        {
            _text.SetText(_content);
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

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
                //�Ұ���
                case SceneType.Entry:
                    Debug.LogError("Pause Button Error");
                    break;
                //���� ����
                case SceneType.Title:
                    Debug.Log("GameEnd");
                    break;
                //Ÿ��Ʋ ��
                case SceneType.WorldMap:
                    Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_���̵�, SceneType.Title);
                    GameObject.Find("Global_UnPauseButton").GetComponent<Button>().onClick.Invoke();
                    break;
                //Ÿ��Ʋ ��
                case SceneType.Battle:
                    Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_���̵�, SceneType.Title);
                    GameObject.Find("Global_UnPauseButton").GetComponent<Button>().onClick.Invoke();
                    break;
                //�Ұ���
                default:
                    Debug.LogError("Pause Button Error");
                    break;
            }

        }
    }
}

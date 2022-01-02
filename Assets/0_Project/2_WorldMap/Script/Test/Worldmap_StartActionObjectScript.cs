using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ToronPuzzle.Event;
using ToronPuzzle.Data;
using ToronPuzzle.UI;

namespace ToronPuzzle.WorldMap
{
    public class Worldmap_StartActionObjectScript : UI_Object, IGameListenerUI
    {
        RectTransform _thisRect;
        Button _thisButton;
        TextMeshProUGUI _ShowText;
        public void AssignGameListener()
        {
            _thisRect = GetComponent<RectTransform>();
            _thisButton = GetComponent<Button>();
            _ShowText = GetComponentInChildren<TextMeshProUGUI>();
            _thisButton.onClick.AddListener(() => OnClick());
            Global_UIEventSystem.Register_UIEvent<bool>(UIEventID.WorldMap_오브젝트_실행, SetIsAble, EventRegistOption.None);
            //일단 처음에는 꺼둘 것임.
            SetIsAble(false);
        }

        void SetIsAble(bool _argBool)
        {
            _thisButton.interactable = _argBool;
            _ShowText.enabled = _argBool;
        }
        void OnClick()
        {
            switch (Global_InGameData.Instance.GetStageAction())
            {
                case ActionObjectKind.시작:
                    Debug.Log("시작 이벤트 사용됨");
                    break;
                case ActionObjectKind.이벤트:
                    break;
                case ActionObjectKind.일반_배틀:
                    Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_씬이동, SceneType.Battle);
                    break;
                case ActionObjectKind.엘리트_배틀:
                    Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_씬이동, SceneType.Battle);
                    break;
                case ActionObjectKind.보스_배틀:
                    Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_씬이동, SceneType.Battle);
                    break;
                case ActionObjectKind.아이템:
                    Debug.Log("아이템 사용됨");
                    break;
                case ActionObjectKind.상점:
                    Debug.Log("상점 입장");
                    break;
                case ActionObjectKind.정보오염:
                    Debug.Log("정보 오염 지역 입니다.");
                    break;
                case ActionObjectKind.미정:
                    Debug.Log("아직 행동 설정이 안됬습니다.");
                    break;
                default:
                    Debug.Log("default : 아직 행동 설정이 안됬습니다.");
                    break;
            }
        }

    }

}

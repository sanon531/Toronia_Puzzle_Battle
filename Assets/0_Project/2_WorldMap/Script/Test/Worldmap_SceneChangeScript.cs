using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToronPuzzle.Event;
using ToronPuzzle.Data;
using ToronPuzzle.UI;

namespace ToronPuzzle.WorldMap
{
    public class Worldmap_SceneChangeScript : UI_Object, IGameListenerUI
    {
        RectTransform _thisRect;
        Button _thisButton;
        public void AssignGameListener()
        {
            _thisRect = GetComponent<RectTransform>();
            _thisButton = GetComponent<Button>();
            _thisButton.onClick.AddListener(() => OnClick());
            Global_UIEventSystem.Register_UIEvent<bool>(UIEventID.WorldMap_��Ʋ��ȯ���, SetIsAble, EventRegistOption.None);
            //�ϴ� ó������ ���� ����.
            SetIsAble(false);
        }

        void SetIsAble(bool _argBool)
        {
            _thisButton.interactable = _argBool;
        }
        void OnClick()
        {
             Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_���̵�, SceneType.Battle);
        }

    }

}

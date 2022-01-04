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
        BoxCollider2D _collider2D;
        TextMeshProUGUI _ShowText;
        public void AssignGameListener()
        {
            _thisRect = GetComponent<RectTransform>();
            _thisButton = GetComponent<Button>();
            _ShowText = GetComponentInChildren<TextMeshProUGUI>();
            _collider2D = GetComponent<BoxCollider2D>();
            _collider2D.size = _thisRect.rect.size;
            _thisButton.onClick.AddListener(() => OnClick());
            Global_UIEventSystem.Register_UIEvent<bool>(UIEventID.WorldMap_������Ʈ_����, SetIsAble, EventRegistOption.None);
            //�ϴ� ó������ ���� ����.
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
                case ActionObjectKind.����:
                    Debug.Log("���� �̺�Ʈ ����");
                    WorldMap_MapBuilder.Instance.SetActionObjectUsed();
                    break;
                case ActionObjectKind.�̺�Ʈ:
                    Debug.Log("�̺�Ʈ ����");
                    WorldMap_MapBuilder.Instance.SetActionObjectUsed();
                    break;
                case ActionObjectKind.�Ϲ�_��Ʋ:
                    Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_���̵�, SceneType.Battle);
                    WorldMap_MapBuilder.Instance.SetActionObjectUsed();
                    break;
                case ActionObjectKind.����Ʈ_��Ʋ:
                    Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_���̵�, SceneType.Battle);
                    WorldMap_MapBuilder.Instance.SetActionObjectUsed();
                    break;
                case ActionObjectKind.����_��Ʋ:
                    Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_���̵�, SceneType.Battle);
                    WorldMap_MapBuilder.Instance.SetActionObjectUsed();
                    break;
                case ActionObjectKind.������:
                    Debug.Log("������ ����");
                    WorldMap_MapBuilder.Instance.SetActionObjectUsed();
                    break;
                case ActionObjectKind.����:
                    Debug.Log("���� ����");
                    WorldMap_MapBuilder.Instance.SetActionObjectUsed();
                    break;
                case ActionObjectKind.��������:
                    Debug.Log("���� ���� ���� �Դϴ�.");
                    break;
                case ActionObjectKind.����:
                    Debug.Log("���� �ൿ ������ �ȉ���ϴ�.");
                    break;
                default:
                    Debug.Log("default : ���� �ൿ ������ �ȉ���ϴ�.");
                    break;
            }
            SetIsAble(false);
        }

    }

}

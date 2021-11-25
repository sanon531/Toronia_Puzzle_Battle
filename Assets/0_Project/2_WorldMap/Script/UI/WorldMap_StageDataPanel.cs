using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using ToronPuzzle.UI;
using ToronPuzzle.Data;
using ToronPuzzle.Event;
using System;

namespace ToronPuzzle.WorldMap
{
    public class WorldMap_StageDataPanel : UI_Object, IGameListenerUI
    {
        TextMeshProUGUI _stageName, _stageInfo;
        ObjectTweener _ShowTween, _HideTween;
        Image _obejctKind_Image;

        Transform _moveImage;
        ActionObjectKind _currentObjectKind = ActionObjectKind.미정;
        public void AssignGameListener()
        {
            RectTweenSetter();
            Global_UIEventSystem.Register_UIEvent<ActionObjectKind>(UIEventID.WorldMap_맵오브젝트정보보이기, ShowObjectDataOnPanel);
            Global_UIEventSystem.Register_UIEvent(UIEventID.WorldMap_맵오브젝트정보숨기기, HideObjectDataOnPanel);
        }

        void RectTweenSetter()
        {
            _stageName = GameObject.Find("SD_StageName").GetComponent<TextMeshProUGUI>();
            _stageInfo = GameObject.Find("SD_StageInfo").GetComponent<TextMeshProUGUI>();


            RectTransform _rect = GetComponent<RectTransform>();
            float _width = Screen.width * 0.45f;
            float _height = Screen.height * 0.25f;
            _rect.sizeDelta = new Vector2(_width, _height);
            Vector2 _showPos, _hidePos;
            _showPos = new Vector2(_width * 0.5f, -_height * 0.5f);
            _hidePos = new Vector2(-_width * 0.5f, -_height * 0.5f);
            _rect.anchoredPosition = _hidePos;
            Button _button = GameObject.Find("SD_TriggerButton").GetComponent<Button>();
            _obejctKind_Image = GameObject.Find("SD_ObjectImage").GetComponent<Image>();
            _button.onClick.AddListener(ClickOnCurrentData);
            _button.GetComponent<BoxCollider2D>().size = _button.GetComponent<RectTransform>().rect.size;
            _moveImage = GameObject.Find("SDMovImage").transform;
            _ShowTween = GameObject.Find("SD_ShowBP").GetComponent<ObjectTweener>();
            _HideTween = GameObject.Find("SD_HideBP").GetComponent<ObjectTweener>();
            _ShowTween._targetpos = _showPos;
            _HideTween._targetpos = _hidePos;

        }

        bool _isShowSD = false;
        void ClickOnCurrentData()
        {
            if (_isShowSD)
                Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_맵오브젝트정보숨기기);
            else
                Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_맵오브젝트정보보이기, _currentObjectKind);
        }

        void ShowObjectDataOnPanel(ActionObjectKind objectKind)
        {
            _currentObjectKind = objectKind;
            SetInfoOnScript();
            _ShowTween.CallTween();
            _moveImage.localEulerAngles = new Vector3(0,180,0); 
            _isShowSD = true;
        }
        void HideObjectDataOnPanel()
        {
            _moveImage.localEulerAngles = new Vector3(0, 0, 0);
            _HideTween.CallTween();
            _isShowSD = false;
        }

        void SetInfoOnScript()
        {

            _obejctKind_Image.sprite = Resources.Load<Sprite>("WorldMap/" + _currentObjectKind.ToString());
            StageInfo _info = Global_InGameData.Instance.GetStageData();
            _stageName.SetText(_currentObjectKind.ToString());

            _stageInfo.SetText("");
        }

      

    }
}
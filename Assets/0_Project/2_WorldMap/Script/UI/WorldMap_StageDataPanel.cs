using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using ToronPuzzle.UI;
using ToronPuzzle.Data;
using ToronPuzzle.Event;

namespace ToronPuzzle.WorldMap
{
    public class WorldMap_StageDataPanel : UI_Object, IGameListenerUI
    {
        [SerializeField]
        TextMeshProUGUI _stageName, _stageInfo;
        ObjectTweener _ShowTween, _HideTween;

        public void AssignGameListener()
        {
            RectTweenSetter();
            Global_UIEventSystem.Register_UIEvent(UIEventID.WorldMap_전투정보보이기, ShowBattleData);
            Global_UIEventSystem.Register_UIEvent(UIEventID.WorldMap_전투정보숨기기, HideBattleData);
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
            _button.onClick.AddListener(ClickOnCurrentData);
            _button.GetComponent<BoxCollider2D>().size = _button.GetComponent<RectTransform>().rect.size;


            _ShowTween = GameObject.Find("SD_ShowBP").GetComponent<ObjectTweener>();
            _HideTween = GameObject.Find("SD_HideBP").GetComponent<ObjectTweener>();
            _ShowTween._targetpos = _showPos;
            _HideTween._targetpos = _hidePos;

        }

        bool _isShowSD = false;
        void ClickOnCurrentData()
        {
            if (_isShowSD)
                Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_전투정보숨기기);
            else
                Global_UIEventSystem.Call_UIEvent(UIEventID.WorldMap_전투정보보이기);
        }

        void ShowBattleData()
        {
            StageInfo _info = Global_InGameData.Instance.GetStageData();

            _stageName.SetText(_info._stageName);
            _stageInfo.SetText(_info._battleCoolTime.ToString());

            _ShowTween.CallTween();
            _isShowSD = true;
        }


        void HideBattleData()
        {

            _HideTween.CallTween();
            _isShowSD = false;
        }


    }
}
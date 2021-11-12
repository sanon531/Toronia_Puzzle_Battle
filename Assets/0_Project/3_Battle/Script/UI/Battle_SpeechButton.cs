using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ToronPuzzle.Event;
using ToronPuzzle.UI;

namespace ToronPuzzle.Battle
{
    //발언 선언 버튼 + 턴넘기기 버튼.
    public class Battle_SpeechButton : UI_Object, IGameListenerUI
    {
        public void AssignGameListener()
        {
            CalculatePartsBegin();
        }


        Button _calcButton;
        Image _calcImage;
        TextMeshProUGUI _speechText;
        void CalculatePartsBegin()
        {
            _calcButton = GameObject.Find("BC_SpeechButton").GetComponent<Button>();
            _calcImage = GameObject.Find("BC_SpeechButtonSet").GetComponent<Image>();
            _speechText = GameObject.Find("BC_SpeechText").GetComponent<TextMeshProUGUI>();

            _calcButton.onClick.AddListener(CallCalcButton);
            Global_UIEventSystem.Register_UIEvent<bool>(UIEventID.Battle_계산버튼OnOff, SetCalcButtonOnOff, EventRegistOption.None);
            Global_InWorldEventSystem.on배틀시작 += EnableSpeechButton;
            Global_InWorldEventSystem.on배틀시작 += SetCalcTextToStart;
            Global_InWorldEventSystem.on토론시작 += IsBattleTrue;
            Global_InWorldEventSystem.on토론시작 += SetCalcTextToSpeech;
            Global_InWorldEventSystem.on토론휴식 += IsBattleFalse;
            Global_InWorldEventSystem.on토론휴식 += SetCalcTextToStart;

        }
        void SetCalcTextToStart() { _speechText.SetText("배틀\n시작"); }
        void SetCalcTextToSpeech() { _speechText.SetText("발언"); }

        void ChangeCalcMaxCooltime(float _changeVal)
        {
            _maxCoolTime = _changeVal;
        }
        bool isCalcButtonActive = false;

        void SetCalcButtonOnOff(bool _active)
        {
            isCalcButtonActive = _active;
            _calcButton.interactable = _active;
        }



        private void Update()
        {
            CoolTimeChecker();
        }

        bool isOnBattle = false;

        void CallCalcButton()
        {
            if (!isCalcButtonActive) return;

            if (isOnBattle)
                SendSpeech();
            else
                ChangeSequence();
        }

        void IsBattleTrue() { isOnBattle = true; }
        void IsBattleFalse() {_calcImage.fillAmount = 1; isOnBattle = false; }


        //단순한 방식의 다음턴 넘기기.
        void ChangeSequence() { Global_InWorldEventSystem.CallOn시퀀스넘기기(); }

        float _maxCoolTime = 5f;
        float _currentCoolTime = 5f;


        void DisableSpeechButton() { _calcButton.enabled = false; }
        void EnableSpeechButton() { _calcButton.enabled = true; }


        void SendSpeech()
        {
            if (_currentCoolTime >= _maxCoolTime)
            {
                _currentCoolTime = 0;
                Global_InWorldEventSystem.CallOn판계산선언();
            }
            else
            {
                //아직 충전 중이라는 알림이 뜬다.
            }
        }

        void CoolTimeChecker()
        {
            if (!isOnBattle)
                return;

            if (_currentCoolTime < _maxCoolTime)
            {
                _currentCoolTime += Time.deltaTime;
            }

            _calcImage.fillAmount = _currentCoolTime / _maxCoolTime;


        }



    }
}
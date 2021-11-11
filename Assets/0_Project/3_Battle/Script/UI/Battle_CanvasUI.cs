using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ToronPuzzle.Battle;
using ToronPuzzle.Event;

namespace ToronPuzzle.UI
{
    public class Battle_CanvasUI : UIManager
    {
        public static Battle_CanvasUI Instance;
        public override void BeginUIManager()
        {
            base.BeginUIManager();
            CalculatePartsBegin();
            Instance = this;
        }


        void Update()
        {
            CoolTimeChecker();
        }

        // 현재 알림 뜨는거
        #region

       

        #endregion



        // 발언 선언 버튼, 방어도 계산기, 누를 경우 공격이 나간다.
        #region

        Button _calcButton;
        Image _calcImage;
        TextMeshProUGUI _guardText, _speechText;
        void CalculatePartsBegin()
        {
            _calcButton = GameObject.Find("BC_SpeechButton").GetComponent<Button>();
            _calcImage = GameObject.Find("BC_SpeechButtonSet").GetComponent<Image>();
            _speechText = GameObject.Find("BC_SpeechText").GetComponent<TextMeshProUGUI>();

            _calcButton.onClick.AddListener(CallCalcButton);

            Global_InWorldEventSystem.on배틀시작 += EnableSpeechButton;
            Global_InWorldEventSystem.on배틀시작 += SetCalcTextToStart;
            Global_InWorldEventSystem.on토론시작 += IsBattleTrue;
            Global_InWorldEventSystem.on토론시작 += SetCalcTextToSpeech;
            Global_InWorldEventSystem.on토론휴식 += IsBattleFalse;
            Global_InWorldEventSystem.on토론휴식 += SetCalcTextToStart;

        }
        void SetCalcTextToStart(){ _speechText.SetText("배틀\n시작"); }
        void SetCalcTextToSpeech() { _speechText.SetText("발언"); }

        void ChangeCalcMaxCooltime(float _changeVal)
        {
            _maxCoolTime = _changeVal;
        }
        void SetCalcButtonOnOff()
        {

        }

        bool isOnBattle = false;
        void CallCalcButton()
        {
            if (isOnBattle)
                SendSpeech();
            else
                ChangeSequence();
        }

        void IsBattleTrue(){ isOnBattle = true; }
        void IsBattleFalse(){ isOnBattle = false; }


        //단순한 방식의 다음턴 넘기기.
        void ChangeSequence(){Global_InWorldEventSystem.CallOn시퀀스넘기기();}

        float _maxCoolTime = 5f;
        float _currentCoolTime = 5f;


        void DisableSpeechButton(){_calcButton.enabled = false;}
        void EnableSpeechButton(){_calcButton.enabled = true;}


        void SendSpeech()
        {
            if (_currentCoolTime >= _maxCoolTime)
            {
                _currentCoolTime = 0;
                Global_InWorldEventSystem.CallOn판계산(
                    Master_Battle.Data_OnlyInBattle._playerData, 
                    Master_Battle.Data_OnlyInBattle._enemyData,DataEntity.고유데이터(1));
            }
            else
            {
                //아직 충전 중이라는 알림이 뜬다.
            }
        }

        void CoolTimeChecker()
        {
            if (!isOnBattle){
                _calcImage.fillAmount = 1;
                return;
            }

            if (_currentCoolTime < _maxCoolTime)
            {
                _currentCoolTime += Time.deltaTime;
            }

            _calcImage.fillAmount = _currentCoolTime/_maxCoolTime ;


        }
        void RestartCoolTime()
        {

        }


        #endregion

        //시퀀스 진행 버튼
        Button _sequenceButton;

        //배틀 타이머 가동 버튼.
        #region

        #endregion


    }

}

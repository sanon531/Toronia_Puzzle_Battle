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
            BattleTurnBegin();
            CalculatePartsBegin();
            Instance = this;
        }


        void Update()
        {
            CoolTimeChecker();
        }

        // 현재 알림 뜨는거
        #region

        TextMeshProUGUI _turnPaneltext;
        ButtonFunctions[] _showTurnFunctions, _hideTurnFunctions;
        Coroutine _turnPannelCoroutine;
        void BattleTurnBegin()
        {
            _turnPaneltext = GameObject.Find("BT_ShowText").GetComponent<TextMeshProUGUI>();
            _showTurnFunctions = GameObject.Find("BT_ShowFunction").GetComponents<ButtonFunctions>();
            _hideTurnFunctions = GameObject.Find("BT_HideFunction").GetComponents<ButtonFunctions>();
            Global_UIEventSystem.Register_UIEvent<int>(UIEventID.Battle_현재턴표시, BattleTurnShow, EventRegistOption.None);

        }

        private void BattleTurnShow(int _currentTurn)
        {
            _turnPaneltext.SetText(_currentTurn.ToString() + "턴");

            if (_turnPannelCoroutine != null)
                Global_CoroutineManager.Stop(_turnPannelCoroutine);

            _turnPannelCoroutine = Global_CoroutineManager.Run(ShowTurnCoroutine());
        }

        IEnumerator ShowTurnCoroutine()
        {
            foreach (ButtonFunctions _functions in _showTurnFunctions)
                _functions.OnClick();
            yield return new WaitForSeconds(1f);

            foreach (ButtonFunctions _functions in _hideTurnFunctions)
                _functions.OnClick();


        }

        #endregion



        // 발언 선언 버튼, 방어도 계산기, 누를 경우 공격이 나간다.
        #region

        Button _calcButton;
        Image _calcImage;
        GameObject _guardImage;
        TextMeshProUGUI _guardText;
        void CalculatePartsBegin()
        {
            _calcButton = GameObject.Find("BC_CalcBlockButton").GetComponent<Button>();
            _calcImage = GameObject.Find("BC_CalcButtonBackGround").GetComponent<Image>();
            _guardImage = GameObject.Find("BC_CurrentGuard");
            _guardText = GameObject.Find("BC_CurrentGuardText").GetComponent<TextMeshProUGUI>();
            Global_UIEventSystem.Register_UIEvent<int>(UIEventID.Battle_방어도표시, SetGuardPower, EventRegistOption.None);
            _calcButton.onClick.AddListener(CallCalcButton);
            Global_InWorldEventSystem.on배틀시작 += EnableSpeechButton;

            Global_InWorldEventSystem.on토론시작 += IsBattleTrue;
            Global_InWorldEventSystem.on토론휴식 += IsBattleFalse;
        }
        void ChangeCalcMaxCooltime(float _changeVal)
        {
            _maxCoolTime = _changeVal;
        }
        void SetCalcButtonOnOff()
        {

        }
        void SetGuardPower(int _guardAmount)
        {
            if (_guardAmount <= 0)
                _guardImage.SetActive(false);
            else
            {
                _guardImage.SetActive(true);
                _guardText.SetText(_guardAmount.ToString());
            }
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
            }
            else
            {

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

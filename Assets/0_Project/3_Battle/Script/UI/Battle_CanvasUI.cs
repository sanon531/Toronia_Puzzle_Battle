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

        float _maxCoolTime = 5f;
        float _currentCoolTime = 5f;
        Button _calcButton;
        GameObject _guardImage;
        TextMeshProUGUI _guardText;
        void CalculatePartsBegin()
        {
            _calcButton = GameObject.Find("BC_CalcBlockButton").GetComponent<Button>();
            _guardImage = GameObject.Find("BC_CurrentGuard");
            _guardText = GameObject.Find("BC_CurrentGuardText").GetComponent<TextMeshProUGUI>();
            Global_UIEventSystem.Register_UIEvent<int>(UIEventID.Battle_방어도표시, SetGuardPower, EventRegistOption.None);
            _calcButton.onClick.AddListener(ChangeSequence);
        }
        void ChangeCalcMaxCooltime(float _changeVal)
        {
            _maxCoolTime = _changeVal;
        }
        void CallCalcButton()
        {

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
        void ChangeSequence()
        {
            Debug.Log("BC_ChangeSequnce");
            Global_InWorldEventSystem.CallOn시퀀스넘기기();
        }



        void CoolTimeChecker()
        {
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

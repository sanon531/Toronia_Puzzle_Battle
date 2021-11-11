using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ToronPuzzle.Event;
using ToronPuzzle.UI;

namespace ToronPuzzle.Battle
{
    public class Battle_TurnShower : UI_Object, IGameListenerUI
    {
        public void AssignGameListener()
        {
            BattleTurnBegin();
        }

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

    }
}
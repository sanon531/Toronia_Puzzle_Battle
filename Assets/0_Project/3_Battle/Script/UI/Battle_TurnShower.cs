using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ToronPuzzle.Event;
using ToronPuzzle.UI;
using DG.Tweening;

namespace ToronPuzzle.Battle
{
    public class Battle_TurnShower : UI_Object, IGameListenerUI
    {
        public void AssignGameListener()
        {
            BattleTurnBegin();
        }


        Image _turnPanelImage;
        TextMeshProUGUI _turnPaneltext;
        Coroutine _turnPannelCoroutine;
        void BattleTurnBegin()
        {
            _turnPanelImage = GameObject.Find("BC_TurnShower").GetComponent<Image>();
            _turnPaneltext = GameObject.Find("BC_TurnShowText").GetComponent<TextMeshProUGUI>();
            Global_UIEventSystem.Register_UIEvent<int>(UIEventID.Battle_현재턴표시, BattleTurnShow, EventRegistOption.None);
            Global_UIEventSystem.Register_UIEvent<string>(UIEventID.Battle_현재시퀀스표시, BattleTurnShow, EventRegistOption.None);

        }

        void BattleTurnShow(int _currentTurn)
        {
            _turnPaneltext.SetText(_currentTurn.ToString() + "턴");

            if (_turnPannelCoroutine != null)
                Global_CoroutineManager.Stop(_turnPannelCoroutine);
            _turnPannelCoroutine = Global_CoroutineManager.Run(ShowTurnCoroutine());
        }

        void BattleTurnShow(string _currentSequence)
        {
            _turnPaneltext.SetText(_currentSequence);

            if (_turnPannelCoroutine != null)
                Global_CoroutineManager.Stop(_turnPannelCoroutine);
            _turnPannelCoroutine = Global_CoroutineManager.Run(ShowTurnCoroutine());
        }
        IEnumerator ShowTurnCoroutine()
        {
            _turnPanelImage.enabled = true;
            _turnPaneltext.enabled = true;
            _turnPanelImage.color = new Color(255, 255, 255, 0);
            _turnPaneltext.color= new Color(0, 0, 0, 0);
            _turnPanelImage.DOColor(Color.white, 1f);
            _turnPaneltext.DOColor(Color.black,1f);
            yield return new WaitForSeconds(1f);
            _turnPanelImage.DOColor(new Color(255, 255, 255, 0), 1f);
            _turnPaneltext.DOColor(new Color(0, 0, 0, 0), 1f);
            yield return new WaitForSeconds(1f);
            _turnPanelImage.enabled = false;
            _turnPaneltext.enabled = false;
        }


    

    }
}
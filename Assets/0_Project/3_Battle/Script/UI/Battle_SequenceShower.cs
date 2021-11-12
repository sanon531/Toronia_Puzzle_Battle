using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ToronPuzzle.Event;
using ToronPuzzle.UI;
namespace ToronPuzzle.Battle
{
    public class Battle_SequenceShower : UI_Object,IGameListenerUI
    {
        TextMeshProUGUI _sequenceText;  
        Image _showImage;
        Coroutine _BattleSequenceCoroutine;
        public void AssignGameListener()
        {
            _sequenceText = GameObject.Find("BC_SequenceText").GetComponent<TextMeshProUGUI>();
            _showImage = GameObject.Find("BC_SequenceImage").GetComponent<Image>();
            Global_UIEventSystem.Register_UIEvent<GameSequence>(UIEventID.Battle_현재시퀀스표시, BattleSequenceShow, EventRegistOption.None);

        }
        private void BattleSequenceShow(GameSequence _sequence)
        {
            _sequenceText.SetText(_sequence.ToString());
            if (_BattleSequenceCoroutine != null)
                Global_CoroutineManager.Stop(_BattleSequenceCoroutine);
            _BattleSequenceCoroutine = Global_CoroutineManager.Run(ShowTurnCoroutine());
        }

        IEnumerator ShowTurnCoroutine()
        {

            yield return new WaitForSeconds(1f);



        }
    }
}
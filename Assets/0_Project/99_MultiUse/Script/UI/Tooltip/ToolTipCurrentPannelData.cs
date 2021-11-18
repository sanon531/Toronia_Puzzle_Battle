using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using ToronPuzzle.Event;
using ToronPuzzle.Battle;
using TMPro;

namespace ToronPuzzle.UI
{
    public class ToolTipCurrentPannelData : UI_Object, IGameListenerUI, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] Global_BlockCalculator _blockCalculator;
        [SerializeField] TextMeshProUGUI _attackText, _defendText;

        public void AssignGameListener()
        {
            Global_UIEventSystem.Register_UIEvent<float, float>(UIEventID.Global_계산표시, SetCalcData, EventRegistOption.None);

        }
        Coroutine _showCoroutine;
        public void OnPointerEnter(PointerEventData eventData)
        {
             _showCoroutine = Global_CoroutineManager.Run(DelayedShow());
        }

        IEnumerator DelayedShow()
        {
            yield return new WaitForSeconds(0.5f);
            string _titleName = "속성 효과";
            string _contentName = _blockCalculator.GetCurrentNum();
            Global_ToolTip.instance.SetToolTipData(_titleName, _contentName);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_showCoroutine != null)
                Global_CoroutineManager.Stop(_showCoroutine);

            Global_ToolTip.instance.DisableTooltip();
        }
        public void SetCalcData(float _argAttackNum, float _argDefendNum )
        {
            _attackText.SetText(_argAttackNum.ToString());
            _defendText.SetText(_argDefendNum.ToString());
        }

    }

}

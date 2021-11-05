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
        [SerializeField] Battle_BlockCalculator _blockCalculator;
        [SerializeField] TextMeshProUGUI _attackText, _defendText;

        public void AssignGameListener()
        {
            Global_UIEventSystem.Register_UIEvent<float, float>(UIEventID.Global_���ǥ��, SetCalcData, EventRegistOption.None);

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            string _titleName = "���� ��ġ �� ����";
            string _contentName = _blockCalculator.GetCurrentNum();

            Global_ToolTip.instance.SetToolTipData(_titleName, _contentName);
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            Global_ToolTip.instance.DisableTooltip();
        }
        public void SetCalcData(float _argAttackNum, float _argDefendNum )
        {
            _attackText.SetText(_argAttackNum.ToString());
            _defendText.SetText(_argDefendNum.ToString());
        }

    }

}

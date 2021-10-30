using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
namespace ToronPuzzle.Battle
{
    public class ToolTipCurrentPannelData : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] Battle_BlockCalculator _blockCalculator;
        [SerializeField] TextMeshProUGUI _attackText, _defendText;
        public void OnPointerEnter(PointerEventData eventData)
        {
            string _titleName = "현재 수치 당 비율";
            string _contentName = _blockCalculator.GetCurrentNum();

            Global_ToolTip.instance.SetToolTipData(_titleName, _contentName);
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            Global_ToolTip.instance.DisableTooltip();
        }
        public void SetNumberOnText(float _argAttackNum, float _argDefendNum )
        {
            _attackText.SetText(_argAttackNum.ToString());
            _defendText.SetText(_argDefendNum.ToString());
        }

    }

}

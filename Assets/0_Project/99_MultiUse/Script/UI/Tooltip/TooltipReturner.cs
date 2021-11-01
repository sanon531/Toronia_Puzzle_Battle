using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ToronPuzzle.UI
{
    public class TooltipReturner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            //Global_ToolTip.instance.SetToolTipData();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Global_ToolTip.instance.DisableTooltip();
        }
    }
}
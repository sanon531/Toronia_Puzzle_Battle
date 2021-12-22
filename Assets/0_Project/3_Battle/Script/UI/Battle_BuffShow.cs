using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ToronPuzzle.Data;
using ToronPuzzle.UI;
using UnityEngine.EventSystems;

namespace ToronPuzzle.Battle
{
    public class Battle_BuffShow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        Image _thisImage;
        [SerializeField]
        TextMeshProUGUI _text;
        [SerializeField]
        CharBuffData _thisData;

        public void OnPointerEnter(PointerEventData eventData)
        {
            _showCoroutine = Global_CoroutineManager.Run(DelayedShow());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_showCoroutine != null)
                Global_CoroutineManager.Stop(_showCoroutine);

            Global_ToolTip.instance.DisableTooltip();
        }

        Coroutine _showCoroutine;
        IEnumerator DelayedShow()
        {
            yield return new WaitForSeconds(0.2f);
            string _titleName = CharacterLibrary.BuffNameDic[_thisData._effect];
            string _contentName = CharacterLibrary.BuffExplainDic[_thisData._effect];
            Global_ToolTip.instance.SetToolTipData(_titleName, _contentName);
        }

        public void SetDataOnShow(CharBuffData _data)
        {
            _thisData = _data;
            _thisImage.sprite = Resources.Load<Sprite>("BuffShow/"+_data._effect.ToString());
            if(_data._amount != 0)
                _text.text = _data._amount.ToString();
            else
                _text.text = "";
        }




    }
}
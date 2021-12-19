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
        [SerializeField]
        float _textShowTime = 0.1f;
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

        // 현재 판 계산
        Coroutine _attackCoroutine, _defendCoroutine;
        public void SetCalcData(float _argAttackNum, float _argDefendNum )
        {
            if(_attackCoroutine !=null)
                Global_CoroutineManager.Stop(_attackCoroutine);
            if (_defendCoroutine != null)
                Global_CoroutineManager.Stop(_defendCoroutine);

            _attackCoroutine = Global_CoroutineManager.Run(SetAttackTextbyGradually(_argAttackNum.ToString()));
            _defendCoroutine = Global_CoroutineManager.Run(SetDefendTextbyGradually(_argDefendNum.ToString()));
        }

        IEnumerator SetAttackTextbyGradually(string _targetstring)
        {
            int _limits = 10;
            string _target = "";
            yield return null;
            //Debug.Log(_targetstring.Length);

            int i = 0;
            while (_targetstring.Length > i && _limits >0)
            {
                yield return new WaitForSeconds(_textShowTime);
                _target = _target.Insert(i,_targetstring[i].ToString());
                //Debug.Log(_target + ":" + _targetstring[i].ToString() + "+" + i);
                _attackText.SetText(_target);
                i++;
                _limits--;
            }

            yield return null;
        }

        IEnumerator SetDefendTextbyGradually(string _targetstring)
        {
            int _limits = 10;
            string _target = "";
            yield return null;
            //Debug.Log(_targetstring.Length);

            int i = 0;
            while (_targetstring.Length > i && _limits > 0)
            {
                yield return new WaitForSeconds(_textShowTime);
                _target = _target.Insert(i, _targetstring[i].ToString());
                //Debug.Log(_target + ":" + _targetstring[i].ToString() + "+" + i);
                _defendText.SetText(_target);
                i++;
                _limits--;
            }

            yield return null;
        }
    }

}

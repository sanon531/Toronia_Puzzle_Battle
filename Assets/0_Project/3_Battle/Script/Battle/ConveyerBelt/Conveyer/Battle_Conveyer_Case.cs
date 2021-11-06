using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle;

namespace ToronPuzzle.Battle
{
    public class Battle_Conveyer_Case : BlockCase
    {
        RectTransform _rectTransform;
        BoxCollider2D _caseCollider;

        private void OnEnable()
        {
            StartCoroutine(LateStart());
        }

        IEnumerator LateStart()
        {
            yield return new WaitForEndOfFrame();
            Battle_ConveyerManager.instance.SetCaseOnConveyer(this);
            _rectTransform = GetComponent<RectTransform>();
            _caseCollider = GetComponent<BoxCollider2D>();
            //_rectTransform.localPosition += new Vector3(0, _rectTransform.sizeDelta.x);
            _caseCollider.size = _rectTransform.sizeDelta;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle;

namespace ToronPuzzle.Battle
{
    public class Battle_Conveyer_Case : BlockCase_BlockPlace
    {
        RectTransform _rectTransform;
        BoxCollider2D _caseCollider;

        private void OnEnable()
        {
            StartCoroutine(LateStart());
        }

        public override void PlaceBlock(BlockInfo blockInfo)
        {
            Global_BlockGenerator.instance.GenerateOnConveyerCase(blockInfo,transform,_rectTransform.sizeDelta.x);
        }
        public override void DeleteBlock()
        {
            if (_childObjects.Count == 0)
                return;

            _childCase.Clear();
            foreach (GameObject _object in _childObjects)
                Destroy(_object);

            _childObjects.Clear();
            Debug.Log("deleted");
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

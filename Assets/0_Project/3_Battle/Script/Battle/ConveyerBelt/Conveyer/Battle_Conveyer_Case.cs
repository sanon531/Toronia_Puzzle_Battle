using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle;

namespace ToronPuzzle.Battle
{
    public class Battle_Conveyer_Case : BlockCase_BlockPlace
    {
        BlockInfo _defaultInfo;

        RectTransform _rectTransform;
        BoxCollider2D _caseCollider;

        private void OnEnable()
        {
            StartCoroutine(LateStart());
            _defaultInfo = new BlockInfo(_blockInfo);
        }

        public override BlockCase LiftBlock()
        {
            HideBlock();
            return this;
        }

        public override bool CheckPlaceable(BlockInfo blockinfo)
        {
            return IsEmpty;
        }

        public override void PlaceBlock(BlockInfo blockInfo)
        {
            IsEmpty = false;
            Global_BlockGenerator.instance.GenerateOnConveyerCase(blockInfo,transform,_rectTransform.sizeDelta.x);
        }
        public override void DeleteBlock()
        {
            if (_childObjects.Count == 0)
                return;

            _blockInfo = new BlockInfo(_defaultInfo);
            IsEmpty = true;

            _childCase.Clear();
            foreach (GameObject _object in _childObjects)
                Destroy(_object);

            _childObjects.Clear();
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

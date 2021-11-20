using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using ToronPuzzle.UI;
namespace ToronPuzzle
{
    public class BlockCaseCell_World_Module : BlockCaseCell_World
    {

       
        // Start is called before the first frame update
        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _boxCollider = GetComponent<BoxCollider2D>();
            _blockInfo = _parentCase._blockInfo;

        }


        public override bool CheckLiftable()
        {
            //Debug.Log("Module Liftable" + _parentCase.CheckLiftable());

            return _parentCase.CheckLiftable();
        }
        public override BlockCase LiftBlock()
        {
            _parentCase.LiftBlock();
            return _parentCase;
        }

        public override void SetMaterial(Material _mat)
        {
            //Debug.Log("SetMaterial on "+gameObject.name);
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.material = _mat;

        }
        public override void LiftCell()
        {
            _spriteRenderer.color = _liftColor;
            if (_boxCollider != null)
                _boxCollider.enabled = false;
        }

        public override void ResetCell()
        {
            _spriteRenderer.color = _normalColor;
            if (_boxCollider != null)
                _boxCollider.enabled = true;

        }




        private void OnMouseEnter()
        {
            _showCoroutine = Global_CoroutineManager.Run(DelayedShow());
        }
        private void OnMouseExit()
        {
            if (_showCoroutine != null)
                Global_CoroutineManager.Stop(_showCoroutine);

            Global_ToolTip.instance.DisableTooltip();
        }
        //모듈에 대한 툴팁이 작동하는 부분.
        Coroutine _showCoroutine;
        IEnumerator DelayedShow()
        {
            //Debug.Log(_blockInfo._moduleID.ToString());
            yield return new WaitForSeconds(0.25f);
            string _titleName = "모듈명 : "+_blockInfo._moduleID.ToString();
            string _contentName = Data.ModuleDic._module_skillExplain[_blockInfo._moduleID];
            string _devCommentName = Data.ModuleDic._module_devcomment[_blockInfo._moduleID];
            Global_ToolTip.instance.SetToolTipData(_titleName, _contentName);
            yield return new WaitForSeconds(1.5f);
            Global_ToolTip.instance.SetToolTipData(_titleName, _contentName, _devCommentName);
        }


    }
}
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
            Debug.Log(_blockInfo._moduleID.ToString());
            yield return new WaitForSeconds(0.75f);
            string _titleName = "모듈명 : "+_blockInfo._moduleID.ToString();
            string _contentName = Data.ModuleDic._module_skillExplain[_blockInfo._moduleID];
            _contentName += ("\n" + Data.ModuleDic._module_devcomment[_blockInfo._moduleID] ) ;
            Global_ToolTip.instance.SetToolTipData(_titleName, _contentName);
        }


    }
}
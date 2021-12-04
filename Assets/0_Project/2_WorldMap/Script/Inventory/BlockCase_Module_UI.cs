using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToronPuzzle.UI;


namespace ToronPuzzle.WorldMap
{
    public class BlockCase_Module_UI : BlockCase_BlockPlace
    {


        [SerializeField]
        SpriteRenderer _moduleImage;
        [SerializeField]
        BoxCollider2D _boxCollider;

        public void InitializeModule(BlockInfo _argInfo, float _size_x)
        {
            _blockInfo = new BlockInfo(_argInfo);
            _moduleImage = GetComponentInChildren<SpriteRenderer>();
            _moduleImage.sprite = Resources.Load<Sprite>("Module/" + _blockInfo._moduleID.ToString());
            _moduleImage.transform.localScale = new Vector3(1/_size_x, 1 / _size_x, 1 / _size_x);
            _boxCollider.size = Global_CanvasData.CanvasData._inventoryCellSize;
        }

        public override bool CheckLiftable(){ return true; }

        public override void ResetBlock(BlockInfo _info)
        {

            ShowBlock();
        }
        public void SetSpritePos(Vector3 _vector)
        {
            _moduleImage.transform.position = _vector;
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
            string _titleName = "모듈명 : " + _blockInfo._moduleID.ToString();
            string _contentName = Data.ModuleDic._module_skillExplain[_blockInfo._moduleID];
            string _devCommentName = Data.ModuleDic._module_devcomment[_blockInfo._moduleID];
            Global_ToolTip.instance.SetToolTipData(_titleName, _contentName);
            yield return new WaitForSeconds(1.5f);
            Global_ToolTip.instance.SetToolTipData(_titleName, _contentName, _devCommentName);
        }
    }
}
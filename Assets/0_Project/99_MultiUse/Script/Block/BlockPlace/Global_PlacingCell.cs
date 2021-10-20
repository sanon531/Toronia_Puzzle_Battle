using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    [Serializable]
    public class Global_PlacingCell : BlockCase
    {
        public Vector2Int _caseNum = new Vector2Int(-1, -1);
        SpriteRenderer _spriteRenderer;


        public void SetInitialData(Vector2Int _argcaseNum)
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _caseNum = _argcaseNum;
        }


        public override bool CheckLiftable()
        {
            return _blockInfo.IsLiftable;
        }

        public override bool CheckPlaceable(BlockInfo arg_blockinfo)
        {
            Global_BlockPlaceMaster.instance.SetPreviewOnBlock(_caseNum, arg_blockinfo);

            return Global_BlockPlaceMaster.instance.CheckBlockSettable(_caseNum, arg_blockinfo);
        }

        public override void PlaceBlock(BlockInfo arg_blockInfo)
        {
            arg_blockInfo._blockPlace = _caseNum;
            int _maxX = arg_blockInfo._blockShapeArr.GetLength(0);
            int _maxY = arg_blockInfo._blockShapeArr.GetLength(1);


            Global_BlockGenerator.instance.GenerateOnBlockPlace(arg_blockInfo);
        }

        public void SetColorOnCell(Color _argColor)
        {
            _spriteRenderer.color = _argColor;
        }


    }

}

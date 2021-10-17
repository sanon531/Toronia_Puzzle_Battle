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

        public override bool CheckPlaceable(BlockInfo blockinfo)
        {
            return true;
        }

        public override void PlaceBlock(BlockInfo blockInfo)
        {
            blockInfo._blockPlace = _caseNum;
            int _maxX = blockInfo._blockShapeArr.GetLength(0);
            int _maxY = blockInfo._blockShapeArr.GetLength(1);


            Global_BlockGenerator.instance.GenerateOnBlockPlace(blockInfo);
        }

    }

}

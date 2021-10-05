using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle.Battle
{
    [Serializable]
    public class Battle_PlacingCell : BlockCase
    {
        public Vector2Int _caseNum = new Vector2Int(-1, -1);
        SpriteRenderer _spriteRenderer;


        public void SetInitialData(Vector2Int _argcaseNum)
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _caseNum = _argcaseNum;
        }


        public override bool CheckPlaceable(BlockInfo blockinfo)
        {


            return true;
        }

        public override void PlaceBlock(BlockInfo blockInfo)
        {
            blockInfo._blockPlace = _caseNum;
            Global_BlockGenerator.instance.GenerateOnBlockPlace(blockInfo);
        }

    }

}

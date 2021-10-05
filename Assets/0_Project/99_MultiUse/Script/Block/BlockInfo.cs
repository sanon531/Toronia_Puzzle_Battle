using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;

namespace ToronPuzzle
{
    [Serializable]
    public class BlockInfo
    {
        public bool IsLiftable = false;
        public string ModuleName = "";
        public BlockElement _blockElement;
        public int _blockStength = 0;
        public ShapeEnum _blockShape;
        public int[,] _blockShapeArr = new int[1, 1];
        //블록의 판내부의 배치 공간.(만약 없을 경우 -1)
        public Vector2Int _blockPlace = new Vector2Int(-1,-1);




        //생성자.

        public BlockInfo()
        {
            _blockElement = BlockElement.Emptiness;
            _blockStength = 0;
            _blockShape = ShapeEnum.UnDefined;
            _blockShapeArr = new int[1, 1];
            _blockPlace = new Vector2Int(-1, -1);
        }

        public BlockInfo(BlockElement arg_element, ShapeEnum arg_Shape)
        {
            _blockElement = arg_element;
            _blockShapeArr = (int[,])BlockShapePool.shapeDic[arg_Shape].Clone();
            _blockShape = arg_Shape;
            _blockStength = 0;
            CheckBlockNum();
        }
        public BlockInfo(BlockElement arg_element, ShapeEnum arg_Shape, Vector2Int SetPos)
        {
            _blockElement = arg_element;
            _blockShapeArr = (int[,])BlockShapePool.shapeDic[arg_Shape].Clone();
            _blockShape = arg_Shape;
            _blockStength = 0;
            _blockPlace = SetPos;
            CheckBlockNum();
        }
        public BlockInfo(BlockElement arg_element, ShapeEnum arg_Shape, Vector2Int arg_SetPos, string arg_name)
        {
            _blockElement = arg_element;
            ModuleName = arg_name;
            _blockShapeArr = (int[,])BlockShapePool.shapeDic[arg_Shape].Clone();
            _blockShape = arg_Shape;
            _blockStength = 0;
            CheckBlockNum();
        }
        public BlockInfo(BlockInfo blockInfo)
        {
            IsLiftable = blockInfo.IsLiftable;
            ModuleName = blockInfo.ModuleName;
            _blockElement = blockInfo._blockElement;
            _blockStength = blockInfo._blockStength;
            _blockShape = blockInfo._blockShape;
            _blockShapeArr = (int[,])blockInfo._blockShapeArr.Clone();
            _blockPlace = blockInfo._blockPlace;
        }





        public void CheckBlockNum()
        {
            for (int i = 0; i < _blockShapeArr.GetLength(0); i++)
            {
                for (int j = 0; j < _blockShapeArr.GetLength(1); j++)
                {
                    if (_blockShapeArr[i, j] == 1)
                    {
                        _blockStength++;
                        continue;
                    }
                }
            }
        }


    }



}

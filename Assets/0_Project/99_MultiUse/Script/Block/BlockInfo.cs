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
        public bool _isLiftable = false;
        public string ModuleName = "";
        public BlockElement _blockElement;
        public int _blockStength = 0;
        public BlockShape _blockShape;
        public int[,] _blockShapeArr = new int[1, 1];
        public Vector2Int _blockPlace = new Vector2Int(-1,-1);
        public BlockType _type = BlockType.Block;
        public ModuleInfo _moduleInfo;




        public BlockInfo()
        {
            _blockElement = BlockElement.Emptiness;
            _blockStength = 0;
            _blockShape = BlockShape.UnDefined;
            _blockShapeArr = new int[1, 1];
            _blockPlace = new Vector2Int(-1, -1);
        }

        public BlockInfo(BlockElement arg_element, BlockShape arg_Shape)
        {
            _type = BlockType.Block;
            _blockElement = arg_element;
            _blockShapeArr = (int[,])BlockShapePool.shapeDic[arg_Shape].Clone();
            _blockShape = arg_Shape;
            _blockStength = 0;
            CheckBlockNum();
        }
        public BlockInfo(BlockElement arg_element, BlockShape arg_Shape, Vector2Int SetPos)
        {
            _type = BlockType.Block;
            _blockElement = arg_element;
            _blockShapeArr = (int[,])BlockShapePool.shapeDic[arg_Shape].Clone();
            _blockShape = arg_Shape;
            _blockStength = 0;
            _blockPlace = SetPos;
            CheckBlockNum();
        }
        public BlockInfo(BlockElement arg_element, BlockShape arg_Shape, Vector2Int arg_SetPos, string arg_name)
        {
            _type = BlockType.Block;
            _blockElement = arg_element;
            ModuleName = arg_name;
            _blockShapeArr = (int[,])BlockShapePool.shapeDic[arg_Shape].Clone();
            _blockShape = arg_Shape;
            _blockStength = 0;
            CheckBlockNum();
        }
        public BlockInfo(BlockElement arg_element, int[,] arg_blockShapeArr, Vector2Int arg_SetPos, string arg_name)
        {
            _type = BlockType.Block;
            _blockElement = arg_element;
            ModuleName = arg_name;
            _blockShapeArr = (int[,])arg_blockShapeArr.Clone();
            _blockShape = BlockShape.UnDefined;
            _blockStength = 0;
            CheckBlockNum();
        }
        public BlockInfo(BlockElement arg_element, BlockShape arg_Shape, int _argStrength)
        {
            _type = BlockType.Block;
            _blockElement = arg_element;
            ModuleName = "";
            _blockShapeArr = (int[,])BlockShapePool.shapeDic[arg_Shape].Clone();
            _blockShape = arg_Shape;
            _blockStength = _argStrength;
            CheckBlockNum();
        }



        public BlockInfo(BlockInfo blockInfo)
        {
            _type = BlockType.Block;
            _isLiftable = blockInfo._isLiftable;
            ModuleName = blockInfo.ModuleName;
            _blockElement = blockInfo._blockElement;
            _blockStength = blockInfo._blockStength;
            _blockShape = blockInfo._blockShape;
            _blockShapeArr = (int[,])blockInfo._blockShapeArr.Clone();
            _blockPlace = blockInfo._blockPlace;
        }

        // 모듈의 데이터를 넣는데 활용하는 생성자.
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg_element"> 블록 속성</param>
        /// <param name="arg_Shape">블록 모양</param>
        /// <param name="arg_ModuleInfo"></param>
        /// <param name="arg_name">구분용 이름</param>
        public BlockInfo(BlockElement arg_element, BlockShape arg_Shape, ModuleInfo arg_ModuleInfo, string arg_name,int arg_strength)
        {
            _type = BlockType.Module;
            _blockElement = arg_element;
            ModuleName = arg_name;
            _blockShapeArr = (int[,])BlockShapePool.shapeDic[arg_Shape].Clone();
            _blockShape = BlockShape.UnDefined;
            _blockStength = arg_strength;
            CheckBlockNum();
            _moduleInfo = arg_ModuleInfo;
        }
        public BlockInfo(BlockElement arg_element, int[,] arg_blockShapeArr, ModuleInfo arg_ModuleInfo, string arg_name)
        {
            _type = BlockType.Module;
            _blockElement = arg_element;
            ModuleName = arg_name;
            _blockShapeArr = (int[,])arg_blockShapeArr.Clone();
            _blockShape = BlockShape.UnDefined;
            _blockStength = 0;
            CheckBlockNum();
            _moduleInfo = arg_ModuleInfo;
        }
        public BlockInfo(BlockInfo blockInfo, ModuleInfo arg_ModuleInfo)
        {
            _type = BlockType.Module;

            _isLiftable = blockInfo._isLiftable;
            ModuleName = blockInfo.ModuleName;
            _blockElement = blockInfo._blockElement;
            _blockStength = blockInfo._blockStength;
            _blockShape = blockInfo._blockShape;
            _blockShapeArr = (int[,])blockInfo._blockShapeArr.Clone();
            _blockPlace = blockInfo._blockPlace;
            _moduleInfo = arg_ModuleInfo;
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

        public void SetArrByShape()
        {
            if (_blockShape == BlockShape.UnDefined)
            {
                Debug.Log("UnDefined");
                return;

            }

            _blockShapeArr = (int[,])BlockShapePool.shapeDic[_blockShape].Clone();
        }


    }



}

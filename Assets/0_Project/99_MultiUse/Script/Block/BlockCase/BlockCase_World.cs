using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    public class BlockCase_World : BlockCase
    {
        [SerializeField]
        Vector3 centerData, OriginCenter;
        [SerializeField]
        List<Vector3> BlockLocalPosList = new List<Vector3>();


        public void InitializeBasicData()
        {
            _blockInfo._blockShapeArr = new int[MaxBlockX, MaxBlockY];

            if (!CheckIsEmpty(BlockLocalPosList.Count))
                for (int i = 0; i < BlockLocalPosList.Count; i++)
                {
                    Vector3 tempt = BlockLocalPosList[i];
                    _blockInfo._blockShapeArr[(int)(tempt.x / BlockSize.x), (int)(tempt.y / BlockSize.y)] = 1;

                }
        }


        public override bool CheckLiftable()
        {
            return _blockInfo.IsLiftable;
        }


        private bool CheckIsEmpty(int num)
        {
            if (num <= 0)
            {
                IsEmpty = true;
                BlockLocalPosList.Clear();
                return true;
            }
            else
            {
                IsEmpty = false;
                return false;
            }

        }


    }
}
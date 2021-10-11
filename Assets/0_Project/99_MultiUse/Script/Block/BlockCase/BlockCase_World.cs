using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    public class BlockCase_World : BlockCase
    {
        [SerializeField]
        Vector3 centerData, OriginCenter;

        public List<BlockCaseCell> _childCase = new List<BlockCaseCell>();
        public List<GameObject> _childObjects = new List<GameObject>();
        [SerializeField]
        List<Vector2Int> localPosList = new List<Vector2Int>();

        [SerializeField]
        bool isDebug = false;

        private void Awake()
        {
            if (isDebug)
            {
                _blockInfo._blockShapeArr = Data.BlockShapePool.shapeDic[_blockInfo._blockShape];

            }
        }






        //�ʱ�ȭ

        public void SetCaseToCenter()
        {
            _blockInfo._blockShapeArr = new int[_maxBlockX, _maxBlockY];
        }
        /// <summary>
        /// �������
        /// </summary>
        #region
        public override bool CheckLiftable()
        {
            return _blockInfo.IsLiftable;
        }


        public override BlockCase LiftBlock()
        {
            foreach (BlockCaseCell _childcell in _childCase)
            {
                _childcell.LiftCell();
            }
            return this;
        }

        public override void ResetBlock()
        {

            foreach (BlockCaseCell _childcell in _childCase)
            {
                _childcell.ResetCell();
            }

        }

        #endregion


        public override void DeleteBlock()
        {
            _childCase.Clear();
            foreach (GameObject _cellobj in _childObjects)
            {
                GameObject tempt = _cellobj;
                Destroy(tempt);
            }
            _childObjects.Clear();
        }



        private bool CheckIsEmpty(int num)
        {
            if (num <= 0)
            {
                IsEmpty = true;
                localPosList.Clear();
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
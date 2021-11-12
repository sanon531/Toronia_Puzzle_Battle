using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace ToronPuzzle
{
    public class BlockCase_BlockPlace : BlockCase
    {

        [SerializeField]
        Vector3 centerData, OriginCenter;
        [SerializeField]
        float _width = 1f;
        [SerializeField]
        protected List<BlockCaseCell> _childCase = new List<BlockCaseCell>();
        [SerializeField]
        protected List<GameObject> _childObjects = new List<GameObject>();

        [SerializeField]
        List<Material> _childMatList = new List<Material>();
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
        //초기화

        public void SetCaseToCenter()
        {
            _blockInfo._blockShapeArr = new int[_maxBlockX, _maxBlockY];
        }
        public void SetChildObjOnList(GameObject _child)
        {
            _childObjects.Add(_child);
            _childMatList.Add(_child.GetComponent<SpriteRenderer>().material);
        }
        public void SetChildCaseOnList(BlockCaseCell _cell)
        {
            _childCase.Add(_cell);
        }
        /// <summary>
        /// 들었을때
        /// </summary>
        #region
        public override bool CheckLiftable()
        {
            return _blockInfo._isLiftable;
        }


        public override BlockCase LiftBlock()
        {
            HideBlock();
            Global_BlockPlaceMaster.instance.RemoveBlockDataOnArray(_blockInfo);
            return this;
        }

        public void HideBlock()
        {
            foreach (BlockCaseCell _childcell in _childCase)
            {
                _childcell.LiftCell();
            }
        }

        public override void ResetBlock()
        {
        }
        public void ShowBlock()
        {
            foreach (BlockCaseCell _childcell in _childCase)
                _childcell.ResetCell();

        }

        public override void ResetBlock(BlockInfo blockInfo)
        {
            Global_BlockPlaceMaster.instance.PlaceBlockDataOnArray(_blockInfo);
            //TestCaller.instance.DebugArrayShape("Resetted", blockInfo._blockShapeArr);

        }



        #endregion


        /// <summary>
        /// 배치 관련
        /// </summary>

        #region
        public override void PlaceBlock(BlockInfo _argInfo)
        {
            Global_BlockGenerator.instance.GenerateOnNormalCase(_argInfo, transform, _width);
        }
        public override void DeleteBlock()
        {
            _childCase.Clear();
            foreach (GameObject _cellobj in _childObjects)
            {
                GameObject tempt = _cellobj;
                Destroy(tempt);
            }
            _childObjects.Clear();
            IsEmpty = true;
            Destroy(gameObject);
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
        #endregion



        /// <summary>
        /// 블록 계산후 머테리얼 사라지는 거 한번 해보귀
        /// </summary>
        /// 
        public void SetMaterialOnList(Material _mat)
        {
            _childMatList.Add(_mat);
        }

        public void BlockDestroyWithFX()
        {

            foreach (Material _cell in _childMatList)
            {
                _cell.DOFloat(1f, "_FadeAmount", 1f);
            }
            Destroy(gameObject, 1.5f);
        }


    }
}
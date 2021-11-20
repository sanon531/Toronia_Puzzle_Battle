using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.UI;
namespace ToronPuzzle
{
    [System.Serializable]
    public class BlockCase_Module : BlockCase
    {

        [SerializeField]
        Vector3 centerData, OriginCenter;
        [SerializeField]
        float _width = 1f;
        public List<BlockCaseCell> _childCase = new List<BlockCaseCell>();
        public List<GameObject> _childObjects = new List<GameObject>();
        [SerializeField]
        List<Vector2Int> localPosList = new List<Vector2Int>();
        [SerializeField]
        bool isDebug = false;
        [SerializeField]
        SpriteRenderer _moduleSprite;

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

        public void InitializeModule(BlockInfo _argInfo,float _size_x)
        {
            _blockInfo = new BlockInfo(_argInfo);
            _moduleSprite = GetComponentInChildren<SpriteRenderer>();
            _moduleSprite.sprite = Resources.Load<Sprite>("Module/"+_blockInfo._moduleID.ToString()) ;
            _moduleSprite.transform.localScale = new Vector3(1/_size_x, 1 / _size_x, 1 / _size_x);
        }
        public void SetSpritePos(Vector3 _vector)
        {
            _moduleSprite.transform.position = _vector;
        }
        /// <summary>
        /// 들었을때
        /// </summary>
        #region
        public override bool CheckLiftable()
        {
            //Debug.Log(Global_SceneManager._currentScene);
            return Global_SceneManager.ModuleLiftable();
        }

    
        public override BlockCase LiftBlock()
        {
            HideBlock();
            Global_BlockPlaceMaster.instance.RemoveModuleDataOnArray(_blockInfo);
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
            Global_BlockPlaceMaster.instance.PlaceModuleDataOnArray(_blockInfo);
            ShowBlock();
            //TestCaller.instance.DebugArrayShape("Resetted", blockInfo._blockShapeArr);

        }



        #endregion


        /// <summary>
        /// 배치 관련
        /// </summary>

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

    }


}

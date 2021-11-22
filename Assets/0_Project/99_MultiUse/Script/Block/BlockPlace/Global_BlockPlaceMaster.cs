using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
using ToronPuzzle.Event;
using ToronPuzzle.UI;
using ToronPuzzle.Battle;

namespace ToronPuzzle
{
    public class Global_BlockPlaceMaster : MonoBehaviour
    {

        //시작 초기화 관련
        #region
        public static Global_BlockPlaceMaster instance;
        [ReadOnly] [SerializeField] int _maxX = 4;
        [ReadOnly] [SerializeField] int _maxY = 6;
        float _currentHeigth, _occupyHeigth, _widthInterval, _heightInterval = 0;
        float _cellSizeY = 0;

        GameObject _placeCellPrefab, _bonusLine, _bonusFull;
        string _placingCellAddress = "BlockPlace/";
        [ReadOnly]
        [SerializeField]
        string _placingCellSkin, _bonusSkin;

        [SerializeField] SpriteRenderer _placingSprite = default;
        Transform _cellHolder, _blockHolder, _bonusHolder;
        [ReadOnly]
        [SerializeField]
        Global_BlockCalculator _blockCalculator;
        Vector2 _screenSize;
        Global_PlacingCell[,] placingCellArray;

        [SerializeField]
        List<BlockCase_BlockPlace> _placedBlocks = new List<BlockCase_BlockPlace>();
        [SerializeField]
        List<BlockCase_Module> _placedModules = new List<BlockCase_Module>();
        ObjectTweener _showFunctions, _hideFunctions;
        //BattleInitialtor 에 의해 선언된다.
        //
        public void BeginBlockPlace(string argCellSkin, string argBnsSkin)
        {
            instance = this;
            // 순서 바꾸지 말것.
            PresetBlockPlaceData(argCellSkin, argBnsSkin);
            SetBlockPlacePos();
            SetBlockCellOnPannel();
            SetBonusOnPannel();
            SetBlockTweenEvent();
            SetHoldPanelEvent();
        }
        private void PresetBlockPlaceData(string argCellSkin, string argBnsSkin)
        {
            Vector2Int _pannel_Size =
                new Vector2Int(
                    Global_InGameData.Instance._placePannelData._maxX
                    , Global_InGameData.Instance._placePannelData._maxY);

            _blockCalculator = GetComponent<Global_BlockCalculator>();
            _blockCalculator.BeginBlockCalc();
            _placingCellSkin = _placingCellAddress;
            _placingCellSkin += argCellSkin;
            _bonusSkin = _placingCellAddress; ;
            _bonusSkin += argBnsSkin;
            _maxX = _pannel_Size.x;
            _maxY = _pannel_Size.y;
            _blockPlacedArr = new int[_maxX, _maxY];
            _modulePlacedArr = new int[_maxX, _maxY];
            _cellHolder = GameObject.Find("BP_CellHolder").transform;
            _blockHolder = GameObject.Find("BP_BlockHolder").transform;
            _bonusHolder = GameObject.Find("BP_BonusHolder").transform;
            _showFunctions = GameObject.Find("BP_ShowBP").GetComponent<ObjectTweener>();
            _hideFunctions = GameObject.Find("BP_HideBP").GetComponent<ObjectTweener>();
        }
        private void SetModuleFromData()
        {
            List<BlockInfo> tempt_BlockInfos = Global_InGameData.Instance._placePannelData._moduleBlockInfos;
            foreach (BlockInfo _Info in tempt_BlockInfos)
            {

                //데이터가 있으면일단 만들고 봄

                //GameObject _moduleObj = Global_BlockGenerator.instance.GenerateModuleOnBlockPlace(_Info);
                //_moduleBlocks.Add(_moduleObj.GetComponent<BlockCase_Module>());
            }
        }
        private void SetBlockPlacePos()
        {
            if (Global_CanvasData.CanvasData._screenWorldSize != null)
            {
                _placeCellPrefab = Resources.Load(_placingCellSkin) as GameObject;
                //배치 판의 사이즈 조절 및 위치 설정
                Vector2 LDAnchor = Global_CanvasData.CanvasData.LDAchorPos;

                _screenSize = Global_CanvasData.CanvasData._screenWorldSize;
                _currentHeigth = _screenSize.y / 2;
                _occupyHeigth = _currentHeigth * 0.9f;
                _heightInterval = _occupyHeigth / (2 * _maxY);
                _cellSizeY = 2 * _heightInterval;
                Vector2 _showPos = new Vector3(LDAnchor.x + (_maxX + 1) * _cellSizeY * 0.5f, LDAnchor.y + _currentHeigth * 0.5f);
                Vector2 _hidePos = new Vector3(LDAnchor.x - (_maxX + 1) * _cellSizeY * 0.5f, LDAnchor.y + _currentHeigth * 0.5f);

                Master_Battle.Data_OnlyInBattle._cellsize = new Vector2(_cellSizeY, _cellSizeY);

                transform.position = _showPos;
                _showFunctions._targetpos = _showPos;
                _hideFunctions._targetpos = _hidePos;
                _placingSprite.transform.localScale = new Vector2((-LDAnchor.x + _showPos.x) * 2, _screenSize.y / 2);

            }
            else
                Debug.LogError("BattleUIAnchor Didn't Setted");

        }
        public Vector3 GetCellPosByOrder(Vector2Int _pos)
        {
            //Debug.Log(placingCellArray[_pos.x, _pos.y].transform.position);
            return placingCellArray[_pos.x, _pos.y].transform.position;
        }

        /// <summary>
        /// 2
        /// 1
        /// 0 12 
        /// 과 같은 순서로 작동한다.
        /// </summary>
        void SetBlockCellOnPannel()
        {
            Vector2 LUAnchor = Global_CanvasData.CanvasData.LDAchorPos;
            Vector2 firstSpot = new Vector3(LUAnchor.x + (_cellSizeY), LUAnchor.y + (_heightInterval * 1.5f));
            placingCellArray = new Global_PlacingCell[_maxX, _maxY];
            for (int i_y = 0; i_y < _maxY; i_y++)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    Vector2 targetpos = firstSpot + new Vector2(j_x * _cellSizeY, i_y * _cellSizeY);
                    GameObject temptPlacingCell = Instantiate(_placeCellPrefab, targetpos, Quaternion.identity, _cellHolder);
                    string _name = j_x.ToString();
                    _name += i_y.ToString();
                    temptPlacingCell.name = _name;
                    temptPlacingCell.transform.localScale = new Vector2(_cellSizeY, _cellSizeY);
                    temptPlacingCell.GetComponent<Global_PlacingCell>().SetInitialData(new Vector2Int(j_x, i_y));
                    placingCellArray[j_x, i_y] = temptPlacingCell.GetComponent<Global_PlacingCell>();

                }
            }

            SetBlockPanelCalc();

        }

        void SetBonusOnPannel()
        {
            Vector2 LUAnchor = Global_CanvasData.CanvasData.LDAchorPos;
            Vector2 firstSpot = new Vector3(LUAnchor.x + (_cellSizeY), LUAnchor.y + (_heightInterval * 1.5f));
            _bonusLine = Resources.Load(_bonusSkin + "Line") as GameObject;
            _bonusFull = Resources.Load(_bonusSkin + "Full") as GameObject;


            //x축(세로보너스들)의 보너스 블럭 세팅.
            for (int i_x = 0; i_x < _maxX; i_x++)
            {
                Vector2 targetpos = new Vector3(firstSpot.x + i_x * _cellSizeY, firstSpot.y - 1.25f * _heightInterval, -1);
                GameObject bnsLine = Instantiate(_bonusLine, targetpos, Quaternion.identity, _bonusHolder);
                _blockCalculator._bonusXColumnLines.Add(bnsLine);

                Transform bns_child = bnsLine.transform.GetChild(0);
                bns_child.localPosition = new Vector2(0, (_cellSizeY * (_maxY + 0.25f)));
                bns_child.localScale = new Vector2(_cellSizeY * 1f, _cellSizeY * 0.5f);
                bns_child = bnsLine.transform.GetChild(1);
                bns_child.localScale = new Vector2(_cellSizeY * 1f, _cellSizeY * 0.5f);


            }

            for (int i_y = 0; i_y < _maxY; i_y++)
            {
                Vector2 targetpos = new Vector3(firstSpot.x - 0.75f * _cellSizeY, firstSpot.y + (_cellSizeY * i_y), -1);
                GameObject bnsLine = Instantiate(_bonusLine, targetpos, Quaternion.identity, _bonusHolder);
                _blockCalculator._bonusYRowLines.Add(bnsLine);
                bnsLine.transform.rotation = Quaternion.Euler(0, 0, -90);


                Transform bns_child = bnsLine.transform.GetChild(0);
                bns_child.localScale = new Vector2(_cellSizeY * 1f, _cellSizeY * 0.5f);
                bns_child.localPosition = new Vector2(0, (_cellSizeY * (_maxX + 0.5f)));
                bns_child = bnsLine.transform.GetChild(1);
                bns_child.localScale = new Vector2(_cellSizeY * 1f, _cellSizeY * 0.5f);

            }

            firstSpot = new Vector3(LUAnchor.x + (_cellSizeY * 0.25f), LUAnchor.y + (_heightInterval * 0.25f));
            GameObject bnsFull = Instantiate(_bonusFull, firstSpot, Quaternion.identity, _bonusHolder);
            _blockCalculator._perfectSetting = bnsFull;

            Vector2 _bnsSize = new Vector2(_cellSizeY * 0.5f, _cellSizeY * 0.5f);


            bnsFull.transform.GetChild(0).localScale = _bnsSize;
            Transform bns_LU = bnsFull.transform.GetChild(1);
            bns_LU.localPosition = new Vector2(0, (_cellSizeY * (_maxY + 0.25f)));
            bns_LU.localScale = _bnsSize;
            Transform bns_RD = bnsFull.transform.GetChild(2);
            bns_RD.localPosition = new Vector2((_cellSizeY * (_maxX + 0.5f)), 0);
            bns_RD.localScale = _bnsSize;

            Transform bns_RU = bnsFull.transform.GetChild(3);
            bns_RU.localPosition = new Vector2((_cellSizeY * (_maxX + 0.5f)), (_cellSizeY * (_maxY + 0.25f)));
            bns_RU.localScale = _bnsSize;

            _blockCalculator._fullFXpos = ((Vector3)firstSpot + bns_LU.position + bns_RD.position + bns_RU.position) / 4;
            _blockCalculator.CalcBonusLine(_blockPlacedArr);
        }

        private void SetBlockTweenEvent()
        {
            Global_UIEventSystem.Register_UIEvent(UIEventID.Global_블록판숨기기, HideBlockPannel, EventRegistOption.Permanent);
            Global_UIEventSystem.Register_UIEvent(UIEventID.Global_블록판보이기, ShowBlockPannel, EventRegistOption.Permanent);
        }
        private void HideBlockPannel()
        {
            _hideFunctions.CallTween();
        }
        private void ShowBlockPannel()
        {
            _showFunctions.CallTween();

        }


        #endregion




        //블럭 추가 전의 계산 관련
        #region
        //블록의 배치 위치를 int 형의 구조물에 올린다.
        //없음 = 0, 일반 블럭 = 1, , 모듈 = 3 , 트리거 공간 = 4,
        int[,] _blockPlacedArr;
        int[,] _modulePlacedArr;


        //블럭만 대상으로 세팅함.
        public void SetPreviewOnBlock(Vector2Int arg_tagetNum, BlockInfo arg_blockInfo)
        {
            // 
            int[,] _blockArr = (int[,])arg_blockInfo._blockShapeArr.Clone();
            List<Global_PlacingCell> _cellList = new List<Global_PlacingCell>();

            int _blockX = _blockArr.GetLength(0);
            int _blockY = _blockArr.GetLength(1);
            for (int i_y = _blockY - 1; i_y >= 0; i_y--)
            {
                int posYOnPlace = i_y + arg_tagetNum.y;
                if (posYOnPlace >= _maxY) continue;

                for (int j_x = 0; j_x < _blockX; j_x++)
                {
                    int posXOnPlace = arg_tagetNum.x - _blockX + j_x + 1;
                    if (posXOnPlace < 0) continue;

                    //블럭의 위치상
                    if (_blockArr[j_x, i_y] == 1)
                        _cellList.Add(placingCellArray[posXOnPlace, posYOnPlace]);
                }
            }


            foreach (Global_PlacingCell _PlacingCell in placingCellArray)
            {
                if (_cellList.Contains(_PlacingCell))
                    _PlacingCell.SetColorOnCell(Color.green);
                else
                    _PlacingCell.SetColorOnCell(Color.white);

            }

            //TestCaller.instance.DebugArrayShape(_blockArr);
        }

        public void ResetPreview()
        {
            foreach (Global_PlacingCell _PlacingCell in placingCellArray)
            {
                _PlacingCell.SetColorOnCell(Color.white);
            }
        }

        //블록 생성 가능 체크
        //여기서는 세팅을 할지 말지 고민 함
        public bool CheckBlockSettable(Vector2Int arg_targetNum, BlockInfo arg_blockInfo)
        {
            int[,] _blockArr = (int[,])arg_blockInfo._blockShapeArr.Clone();
            bool returnVal = true;

            int _blockX = _blockArr.GetLength(0);
            int _blockY = _blockArr.GetLength(1);

            //

            #region

            if(arg_blockInfo._type == BlockType.Block)
                for (int i_y = _blockY - 1; i_y >= 0; i_y--)
            {
                int posYOnPlace = i_y + arg_targetNum.y;
                if (posYOnPlace >= _maxY)
                    return false;

                for (int j_x = 0; j_x < _blockX; j_x++)
                {
                    int posXOnPlace = arg_targetNum.x - _blockX + j_x + 1;
                    if (posXOnPlace < 0)
                        return false;
                    //블럭의 위치상
                    if (_blockArr[j_x, i_y] == 1)
                    {
                        if (_blockPlacedArr[posXOnPlace, posYOnPlace] == 1 || _blockPlacedArr[posXOnPlace, posYOnPlace] == 3)
                        {
                            returnVal = false;
                        }

                    }
                }
            }
            else
                for (int i_y = _blockY - 1; i_y >= 0; i_y--)
                {
                    int posYOnPlace = i_y + arg_targetNum.y;
                    if (posYOnPlace >= _maxY)
                        return false;

                    for (int j_x = 0; j_x < _blockX; j_x++)
                    {
                        int posXOnPlace = arg_targetNum.x - _blockX + j_x + 1;
                        if (posXOnPlace < 0)
                            return false;
                        //블럭의 위치상
                        if (_blockArr[j_x, i_y] != 0)
                        {
                            if (_blockPlacedArr[posXOnPlace, posYOnPlace] == 1 || 
                                _blockPlacedArr[posXOnPlace, posYOnPlace] == 3 ||
                                _blockPlacedArr[posXOnPlace, posYOnPlace] == 4 ||
                                _blockPlacedArr[posXOnPlace, posYOnPlace] == 5 )
                            {
                                returnVal = false;
                            }

                        }
                    }
                }

            #endregion

            //Debug.Log("Settable : " + returnVal);
            return returnVal;
        }


        public void PlaceBlockDataOnArray(BlockInfo arg_blockInfo)
        {
            Vector2Int _targetNum = arg_blockInfo._blockPlace;

            if (!CheckBlockSettable(_targetNum, arg_blockInfo))
                return;

            int[,] _blockArr = (int[,])arg_blockInfo._blockShapeArr.Clone();

            int _blockX = _blockArr.GetLength(0);
            int _blockY = _blockArr.GetLength(1);
            for (int i_y = _blockY - 1; i_y >= 0; i_y--)
            {
                int posYOnPlace = i_y + _targetNum.y;
                if (posYOnPlace >= _maxY) return;

                for (int j_x = 0; j_x < _blockX; j_x++)
                {
                    int posXOnPlace = _targetNum.x - _blockX + j_x + 1;
                    if (posXOnPlace < 0) return;


                    //블럭의 위치상
                    if (_blockArr[j_x, i_y] != 0)
                    {
                        _blockPlacedArr[posXOnPlace, posYOnPlace] = _blockArr[j_x, i_y];
                    }

                }
            }
            //TestCaller.instance.DebugArrayShape("Added", _blockPlacedArr);

        }
        public void RemoveBlockDataOnArray(BlockInfo arg_blockInfo)
        {
            Vector2Int _targetNum = arg_blockInfo._blockPlace;
            int[,] _blockArr = (int[,])arg_blockInfo._blockShapeArr.Clone();

            int _blockX = _blockArr.GetLength(0);
            int _blockY = _blockArr.GetLength(1);
            for (int i_y = _blockY - 1; i_y >= 0; i_y--)
            {
                int posYOnPlace = i_y + _targetNum.y;
                if (posYOnPlace >= _maxY) return;

                for (int j_x = 0; j_x < _blockX; j_x++)
                {
                    int posXOnPlace = _targetNum.x - _blockX + j_x + 1;
                    //블럭의 위치상
                    if (posXOnPlace < 0) return;

                    if (_blockArr[j_x, i_y] == 1)
                    {
                        _blockPlacedArr[posXOnPlace, posYOnPlace] = 0;
                    }
                }
            }

            //TestCaller.instance.DebugArrayShape("Removed", _blockPlacedArr);

        }

        public void PlaceModuleDataOnArray(BlockInfo arg_blockInfo)
        {
            Vector2Int _targetNum = arg_blockInfo._blockPlace;

            if (!CheckBlockSettable(_targetNum, arg_blockInfo))
                return;

            int[,] _blockArr = (int[,])arg_blockInfo._blockShapeArr.Clone();

            int _blockX = _blockArr.GetLength(0);
            int _blockY = _blockArr.GetLength(1);
            for (int i_y = _blockY - 1; i_y >= 0; i_y--)
            {
                int posYOnPlace = i_y + _targetNum.y;
                if (posYOnPlace >= _maxY)
                {
                    return;
                }

                for (int j_x = 0; j_x < _blockX; j_x++)
                {
                    int posXOnPlace = _targetNum.x - _blockX + j_x + 1;
                    if (posXOnPlace < 0)
                    {
                        return;
                    }

                    //블럭의 위치상
                    if (_blockArr[j_x, i_y] != 0)
                    {
                        _blockPlacedArr[posXOnPlace, posYOnPlace] = _blockArr[j_x, i_y];
                    }
                }
            }
            //모듈의 배치는 일반 블롣이 사라짐에도 존재해야하기 때문 
            _modulePlacedArr = (int[,])_blockPlacedArr.Clone();
            //TestCaller.instance.DebugArrayShape("BlockAdded", _blockPlacedArr);

        }
        public void RemoveModuleDataOnArray(BlockInfo arg_blockInfo)
        {
            Vector2Int _targetNum = arg_blockInfo._blockPlace;
            int[,] _blockArr = (int[,])arg_blockInfo._blockShapeArr.Clone();

            int _blockX = _blockArr.GetLength(0);
            int _blockY = _blockArr.GetLength(1);
            for (int i_y = _blockY - 1; i_y >= 0; i_y--)
            {
                int posYOnPlace = i_y + _targetNum.y;
                if (posYOnPlace >= _maxY) return;

                for (int j_x = 0; j_x < _blockX; j_x++)
                {
                    int posXOnPlace = _targetNum.x - _blockX + j_x + 1;
                    //블럭의 위치상
                    if (posXOnPlace < 0) return;

                    if (_blockArr[j_x, i_y] != 0 && _blockArr[j_x, i_y] != 1)
                    {
                        _blockPlacedArr[posXOnPlace, posYOnPlace] = 0;
                    }
                }
            }
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                TestCaller.instance.DebugArrayShape("current", _modulePlacedArr);
            }
        }

        #endregion


        //블럭 추가 후 관련, 모듈과 별도
        #region
        Dictionary<BlockInfo, BlockCase_BlockPlace> _infoCaseDic = new Dictionary<BlockInfo, BlockCase_BlockPlace>();
        public void AddBlockOnPlace(BlockCase_BlockPlace _Block)
        {
            //저장 파트
            _placedBlocks.Add(_Block);
            _infoCaseDic.Add(_Block._blockInfo, _Block);


            PlaceBlockDataOnArray(_Block._blockInfo);
            Global_InWorldEventSystem.CallOn블록배치(_Block._blockInfo);
            ResetPreview();
            SendDataToCalc();
        }
        public void AddModuleOnPlace(BlockCase_Module _Block)
        {
            _placedModules.Add(_Block);
            PlaceModuleDataOnArray(_Block._blockInfo);
            _Block._blockInfo._moduleInfo = ModuleDic._IDModuleDic[_Block._blockInfo._moduleID];
            ResetPreview();
            SendDataToCalc();
            //Debug.Log(_Block._blockInfo._moduleInfo+":Acvtivate");
            _Block._blockInfo._moduleInfo.ActivateModuleEffect();
        }
        public void RemoveBlockOnPlace(BlockCase_BlockPlace _Block)
        {
            _placedBlocks.Remove(_Block);
            _infoCaseDic.Remove(_Block._blockInfo);
            ResetPreview();
            SendDataToCalc();
            TestCaller.instance.DebugArrayShape("removed", _blockPlacedArr);
        }
        public void RemoveModuleOnPlace(BlockCase_Module _Block)
        {
            _placedModules.Remove(_Block);
            _infoCaseDic.Remove(_Block._blockInfo);
            ResetPreview();
            SendDataToCalc();
            //Debug.Log(_Block._blockInfo._moduleInfo + ":Deacvtivate");
            _Block._blockInfo._moduleInfo.DeactivateModuleEffect();

        }



        public void SetBlockCallByPos(Vector2Int _pos, BlockInfo _argInfo)
        {
            placingCellArray[_pos.x, _pos.y].PlaceBlock(_argInfo);
        }

        void SendDataToCalc()
        {
            List<BlockInfo> _totalblockInfos = new List<BlockInfo>();
            foreach (BlockCase_BlockPlace _block in _placedBlocks)
                _totalblockInfos.Add(new BlockInfo(_block._blockInfo));

            foreach (BlockCase_Module _block in _placedModules)
                _totalblockInfos.Add(new BlockInfo(_block._blockInfo));


            _blockCalculator.CalcPannelData(_totalblockInfos);
            _blockCalculator.CalcBonusLine(_blockPlacedArr);

        }

        //UI 이벤트 콜함
        void SetHoldPanelEvent()
        {
            Global_UIEventSystem.Register_UIEvent(UIEventID.Global_블럭집은후UI, DeActivateHoldingPanel, EventRegistOption.Permanent);
            Global_UIEventSystem.Register_UIEvent(UIEventID.Global_블럭놓은후UI, ActivateHoldingPanel, EventRegistOption.Permanent);
        }
        void DeActivateHoldingPanel()
        {
            foreach (BlockCase_BlockPlace _Block in _placedBlocks)
                _Block.HideBlock();
            foreach (BlockCase_Module _Module in _placedModules)
                _Module.HideBlock();


        }
        void ActivateHoldingPanel()
        {
            foreach (BlockCase_BlockPlace _Block in _placedBlocks)
                _Block.ShowBlock();
            foreach (BlockCase_Module _Module in _placedModules)
                _Module.ShowBlock();

        }

        #endregion


        //모듈 리턴 관련
        #region
        public BlockInfo GetModuleFromIt(ModuleID _argID)
        {
            BlockInfo _return = new BlockInfo();
            Debug.Log(_argID);
            foreach (BlockCase_Module _Module in _placedModules)
            {
                if (_Module._blockInfo._moduleID == _argID)
                    _return = _Module._blockInfo;
            }

            if (_return._moduleID == ModuleID.없음)
                Debug.LogError("No Data on Place");

            return _return;
        }

        #endregion


        //판 계산 관련.
        #region
        void SetBlockPanelCalc()
        {
            Global_InWorldEventSystem._on판계산선언 += ResetBlockFromPannel;
            Global_InWorldEventSystem._on판계산선언 += CallCalculatorToCalc;
            //Global_InWorldEventSystem.on판계산 += SetDamageOnEnemy;
            //Global_InWorldEventSystem.on판계산 += SetGuardOnPlayer;
        }

        void ResetBlockFromPannel()
        {
            RefreshBlock();
            //현재 블록들을 제거하고 해당 데이터를 플레이어, 적에게 부여한다.
            foreach (BlockCase_BlockPlace _block in _placedBlocks)
            {
                _block.BlockDestroyWithFX();
            }
            _placedBlocks.Clear();
        }
        //오직 1만 제거한다 1, 3은 무시한다.
        void RefreshBlock()
        {
            _blockPlacedArr = (int[,])_modulePlacedArr.Clone();
        }

        void CallCalculatorToCalc()
        {
            Vector2 _calcData = _blockCalculator.GetCalcData();
            Global_InWorldEventSystem.CallOnCalc데미지(Master_Battle.Data_OnlyInBattle._enemyData, DataEntity.고유데이터((int)_calcData.x));
            Global_InWorldEventSystem.CallOnCalc방어도(Master_Battle.Data_OnlyInBattle._playerData, DataEntity.고유데이터((int)_calcData.y));
        }
        #endregion



        // 내부 변수 리턴 관련
        #region
        public Transform GetBlockHolder() { return _blockHolder; }
        //블럭의 위치를 탐색할때 사용함.
        public BlockCase_BlockPlace GetBlockCaseByInfo(BlockInfo _info) { return _infoCaseDic[_info]; }

        private void Start()
        {



        }


        #endregion


    }

}

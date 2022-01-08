using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Battle;
using ToronPuzzle.Event;
using ToronPuzzle.Data;
using ToronPuzzle.WorldMap;

namespace ToronPuzzle
{
    public class Global_BlockGenerator : MonoBehaviour
    {
        public static Global_BlockGenerator instance;

        [SerializeField]
        BlockInfo _lastBlockInfo;
        #region
        GameObject _spawned;//매개로 사용되는 변수


        GameObject
            _blockCase_PlaceCase, _blockCase_World, _blockCase_Module,_moduleActivate,
            _blockCase_Module_UI, 
            _worldBlockCell, _worldModuleCell, _module_Occupy,_outLinerWorld, _outLinerUI
            ;



        Material _mat_Agr, _mat_Agr_Module, _mat_Cyn, _mat_Cyn_Module,
            _mat_Frn, _mat_Frn_Module,
            _mat_Emp, _mat_Emp_Module,
            _mat_Bonus, _mat_Bonus_Module;

        public Vector2 BlockSize;
        public Vector3 OutlinePercent = new Vector3(1.2f, 1.2f, 1.2f);
        Dictionary<BlockElement, FXKind> ElementToBlockFX = new Dictionary<BlockElement, FXKind>()
        {
            {BlockElement.Aggressive , FXKind.BlockSetted_Agr},
            { BlockElement.Cynical, FXKind.BlockSetted_Cyn},
            { BlockElement.Friendly, FXKind.BlockSetted_Frn},
            { BlockElement.Emptiness, FXKind.BlockSetted_Emp},
            { BlockElement.Bonus, FXKind.BlockSetted_Bns}
        };

        #endregion


        public BlockElement this_BlockElement;


        public void BeginBlockGenerator()
        {
            instance = this;
            _worldBlockCell = Resources.Load("BlockCase/BlockCaseCell_World") as GameObject;
            _worldModuleCell = Resources.Load("BlockCase/BlockCaseCell_Module") as GameObject;
            _module_Occupy = Resources.Load("BlockCase/BlockCaseCell_Module_Occupy") as GameObject;

            _outLinerWorld = Resources.Load("BlockCase/BlockCaseOutLiner_World") as GameObject;
            _outLinerUI = Resources.Load("BlockCase/BlockCaseOutLiner_UI") as GameObject;
            _blockCase_PlaceCase = Resources.Load("BlockCase/BlockCase_PlaceCase") as GameObject;
            _blockCase_World = Resources.Load("BlockCase/BlockCase_World") as GameObject;
            _blockCase_Module = Resources.Load("BlockCase/BlockCase_Module") as GameObject;
            _blockCase_Module_UI = Resources.Load("BlockCase/BlockCase_Module_UI") as GameObject;
            _moduleActivate = Resources.Load("BlockCase/Module_Activate") as GameObject;


            _mat_Agr = Resources.Load("Material/Block_Aggresive") as Material;
            _mat_Agr_Module = Resources.Load("Material/Module_Aggresive") as Material;
            _mat_Cyn = Resources.Load("Material/Block_Cynical") as Material;
            _mat_Cyn_Module = Resources.Load("Material/Module_Cynical") as Material;
            _mat_Frn = Resources.Load("Material/Block_Friendly") as Material;
            _mat_Frn_Module = Resources.Load("Material/Module_Friendly") as Material;
            _mat_Emp = Resources.Load("Material/Block_Emptiness") as Material;
            _mat_Emp_Module = Resources.Load("Material/Module_Emptiness") as Material;
            _mat_Bonus = Resources.Load("Material/Block_Bonus") as Material;
            _mat_Bonus_Module = Resources.Load("Material/Module_Block_Bonus") as Material;

        }

        //블록 플레이서에 뭐가 되었든 일단 놓는다.
        public GameObject GenerateOnBlockPlace(BlockInfo _inputInfo)
        {
            _lastBlockInfo = _inputInfo;
            GameObject CaseObject = null;
            if (_inputInfo._type == BlockType.Module)
                CaseObject = GenerateModuleOnBlockPlace(_inputInfo);
            else
                CaseObject = GenerateBlockOnBlockPlace(_inputInfo);

            return CaseObject;
        }

        GameObject GenerateBlockOnBlockPlace(BlockInfo _inputInfo)
        {
            int[,] _tempt_BlockArray = (int[,])_lastBlockInfo._blockShapeArr.Clone();
            Vector2 InputSize = Master_Battle.Data_OnlyInBattle._cellsize;

            //케이스 생성
            GameObject CaseObject =
                Instantiate(_blockCase_PlaceCase, Global_BlockPlaceMaster.instance.GetCellPosByOrder(_inputInfo._blockPlace),
                Quaternion.identity, Global_BlockPlaceMaster.instance.GetBlockHolder());
            BlockCase_BlockPlace _current_Case = CaseObject.GetComponent<BlockCase_BlockPlace>();



            int _maxX = _tempt_BlockArray.GetLength(0);
            int _maxY = _tempt_BlockArray.GetLength(1);

            //케이스 오브젝트 로컬 위치 설정(포지션으로 함 오류 아님) 
            CaseObject.transform.position += new Vector3(InputSize.x * (1 - _maxX), 0, 0);


            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    if (_tempt_BlockArray[j_x, i_y] == 1)
                    {
                        _spawned = Instantiate(_outLinerWorld, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * j_x, (InputSize.y * i_y), 0);
                        _spawned.transform.localPosition = spawnedvector;
                        _spawned.transform.localPosition = spawnedvector + new Vector3(0, 0, 0.1f);
                        _spawned.transform.localScale = InputSize * OutlinePercent;
                        _current_Case.SetChildObjOnList(_spawned);

                        _spawned = Instantiate(_worldBlockCell, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        BlockCaseCell _current_Cell = _spawned.GetComponent<BlockCaseCell>();
                        _current_Cell.SetMaterial(SetElementToBlockMaterial(_inputInfo._blockElement));
                        _current_Cell.SetParentCase(_current_Case);
                        _spawned.transform.localScale = InputSize;

                        _current_Case.SetChildCaseOnList(_current_Cell);

                        _spawned.transform.localPosition = spawnedvector;
                        _current_Case.SetChildObjOnList(_spawned);

                        Global_FXPlayer.PlayFX(ElementToBlockFX[_inputInfo._blockElement], _spawned.transform.position, _spawned.transform);
                    }
                }
            }


            _current_Case.SetCaseToCenter();
            _current_Case._blockInfo = new BlockInfo(_lastBlockInfo);
            //CheckWhereToSet(_current_Case._blockInfo);
            //TestCaller.instance.DebugArrayShape(_current_Case._blockInfo._blockShapeArr);
            Global_BlockPlaceMaster.instance.AddBlockOnPlace(_current_Case);
            //블록 배치에 대한 내용은 마스터 쪽으로

            Global_SoundManager.Instance.PlaySFX(SFXName.BlockPlaced);
            return CaseObject;
        }
        //모듈을 세팅하는 곳.
        public GameObject GenerateModuleOnBlockPlace(BlockInfo _inputInfo)
        {
            _lastBlockInfo = _inputInfo;
            int[,] _tempt_BlockArray = (int[,])_lastBlockInfo._blockShapeArr.Clone();
            Vector2 InputSize = Master_Battle.Data_OnlyInBattle._cellsize;

            //케이스 생성
            GameObject CaseObject =
                Instantiate(_blockCase_Module, Global_BlockPlaceMaster.instance.GetCellPosByOrder(_inputInfo._blockPlace),
                Quaternion.identity, Global_BlockPlaceMaster.instance.GetBlockHolder());
            BlockCase_Module _current_Case = CaseObject.GetComponent<BlockCase_Module>();

            //블록의 값은 현재 게임의 설정에 따라서 달라진다.
            _current_Case.InitializeModule(_inputInfo, InputSize.x);
            _current_Case.IsOnBlockPlace = true;


            int _maxX = _tempt_BlockArray.GetLength(0);
            int _maxY = _tempt_BlockArray.GetLength(1);

            //케이스 오브젝트 로컬 위치 설정(포지션으로 함 오류 아님) 
            CaseObject.transform.position += new Vector3(InputSize.x * (1 - _maxX), 0, 0);

            int _blockNum = 0;
            Vector3 _totalPos = new Vector3();
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    if (_tempt_BlockArray[j_x, i_y] == 3)
                    {
                        _spawned = Instantiate(_outLinerWorld, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * j_x, (InputSize.y * i_y), 0);
                        _spawned.transform.localPosition = spawnedvector + new Vector3(0, 0, 0.1f);
                        _spawned.transform.localScale = InputSize * OutlinePercent;
                        _current_Case.SetChildObjOnList(_spawned);

                        _spawned = Instantiate(_worldModuleCell, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        BlockCaseCell _current_Cell = _spawned.GetComponent<BlockCaseCell>();
                        _current_Cell.SetMaterial(SetElementToBlockMaterial(_inputInfo._blockElement));
                        _current_Cell.SetParentCase(_current_Case);
                        _spawned.transform.localScale = InputSize;

                        _current_Case.SetChildCaseOnList(_current_Cell);

                        _spawned.transform.localPosition = spawnedvector - new Vector3(0, 0, 0.1f);

                        _current_Case.SetChildObjOnList(_spawned);

                        Global_FXPlayer.PlayFX(ElementToBlockFX[_inputInfo._blockElement], _spawned.transform.position, _spawned.transform);
                        _totalPos += _spawned.transform.position;
                        _blockNum++;
                    }
                    else if (_tempt_BlockArray[j_x, i_y] == 4)
                    {
                        _spawned = Instantiate(_moduleActivate, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * j_x, (InputSize.y * i_y), 0);
                        _spawned.transform.localPosition = spawnedvector;
                        _spawned.transform.localScale = InputSize;
                        _current_Case.SetChildObjOnList(_spawned);

                        _spawned.GetComponent<ModuleActivate_ParticleSetter>().SetAllParticleColor(BlockElementPool._ElementToColor[_inputInfo._blockElement]);

                        _totalPos += _spawned.transform.position;
                        _blockNum++;
                    } else if (_tempt_BlockArray[j_x, i_y] == 5)
                    {
                        _spawned = Instantiate(_module_Occupy, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * j_x, (InputSize.y * i_y), 0);
                        _spawned.transform.localPosition = spawnedvector;
                        _spawned.transform.localScale = InputSize;
                        _current_Case.SetChildObjOnList(_spawned);

                        _totalPos += _spawned.transform.position;
                        _blockNum++;
                    }
                }
            }


            _current_Case.SetSpritePos(_totalPos / _blockNum);

            //TestCaller.instance.DebugArrayShape(_current_Case._blockInfo._blockShapeArr);
            Global_BlockPlaceMaster.instance.AddModuleOnPlace(_current_Case);

            Global_InWorldEventSystem.CallOn모듈생성();
            Global_SoundManager.Instance.PlaySFX(SFXName.ModulePlaced);
            return CaseObject;
        }

        
        // 들고있을 때는 들고있는 포인터 다음의 할 일들을 체킹 한다.
        #region 

        public GameObject GenerateOnPointer(BlockInfo _inputInfo, Transform _pointerTranform)
        {
            GameObject _returnObj = gameObject; 
            if (_inputInfo._type == BlockType.Module)
                _returnObj = GenerateModuleOnPointer(_inputInfo, _pointerTranform);
            else 
                _returnObj = GenerateBlockOnPointer(_inputInfo, _pointerTranform);

            return _returnObj;
        }
        GameObject GenerateModuleOnPointer(BlockInfo _inputInfo, Transform _pointerTranform)
        {
            int[,] _tempt_BlockArray = (int[,])_inputInfo._blockShapeArr.Clone();
            Vector2 InputSize = Master_Battle.Data_OnlyInBattle._cellsize;

            //케이스 생성
            GameObject CaseObject = Instantiate(_blockCase_Module, _pointerTranform.position,
                Quaternion.identity, _pointerTranform);


            BlockCase_Module _current_Case = CaseObject.GetComponent<BlockCase_Module>();
            _current_Case._blockInfo = new BlockInfo(_inputInfo);
            int _maxX = _tempt_BlockArray.GetLength(0);
            int _maxY = _tempt_BlockArray.GetLength(1);
            //케이스의 로컬위치 설정
            CaseObject.transform.localPosition = new Vector2(InputSize.x * (1 - _maxX), 0);
            _current_Case.InitializeModule(_inputInfo, InputSize.x);

            int _blockNum = 0;
            Vector3 _totalPos = new Vector3();
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    if (_tempt_BlockArray[j_x, i_y] == 3)
                    {
                        _spawned = Instantiate(_outLinerWorld, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * j_x, (InputSize.y * i_y), 0);
                        _spawned.transform.localPosition = spawnedvector + new Vector3(0, 0, 0.1f);
                        _spawned.transform.localScale = InputSize * OutlinePercent;
                        _current_Case.SetChildObjOnList(_spawned);

                        _spawned = Instantiate(_worldModuleCell, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        BlockCaseCell _current_Cell = _spawned.GetComponent<BlockCaseCell>();
                        _current_Cell.SetMaterial(SetElementToBlockMaterial(_inputInfo._blockElement));
                        _current_Cell.SetParentCase(_current_Case);
                        _spawned.transform.localScale = InputSize;

                        _current_Case.SetChildCaseOnList(_current_Cell);

                        _spawned.transform.localPosition = spawnedvector;
                        _current_Case.SetChildObjOnList(_spawned);

                        Global_FXPlayer.PlayFX(ElementToBlockFX[_inputInfo._blockElement], _spawned.transform.position, _spawned.transform);
                        _totalPos += _spawned.transform.position;
                        _blockNum++;
                    }
                    else if (_tempt_BlockArray[j_x, i_y] == 4)
                    {
                        _spawned = Instantiate(_moduleActivate, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * j_x, (InputSize.y * i_y), 0);
                        _spawned.transform.localPosition = spawnedvector;
                        _spawned.transform.localScale = InputSize;
                        _current_Case.SetChildObjOnList(_spawned);

                        _spawned.GetComponent<ModuleActivate_ParticleSetter>().SetAllParticleColor(BlockElementPool._ElementToColor[_inputInfo._blockElement]);

                        _totalPos += _spawned.transform.position;
                        _blockNum++;
                    }
                    else if (_tempt_BlockArray[j_x, i_y] == 5)
                    {
                        _spawned = Instantiate(_module_Occupy, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * j_x, (InputSize.y * i_y), 0);
                        _spawned.transform.localPosition = spawnedvector;
                        _spawned.transform.localScale = InputSize;
                        _current_Case.SetChildObjOnList(_spawned);


                        _totalPos += _spawned.transform.position;
                        _blockNum++;
                    }
                }
            }


            _current_Case.SetSpritePos(_totalPos / _blockNum);


            Global_InWorldEventSystem.CallOn블록생성(_lastBlockInfo);

            return CaseObject;


        }
        GameObject GenerateBlockOnPointer(BlockInfo _inputInfo, Transform _pointerTranform)
        {
            int[,] _tempt_BlockArray = (int[,])_inputInfo._blockShapeArr.Clone();
            Vector2 InputSize = Master_Battle.Data_OnlyInBattle._cellsize;

            //케이스 생성
            GameObject CaseObject = Instantiate(_blockCase_World, _pointerTranform.position,
                Quaternion.identity, _pointerTranform);


            BlockCase_World _current_Case = CaseObject.GetComponent<BlockCase_World>();
            _current_Case._blockInfo = new BlockInfo(_inputInfo);
            int _maxX = _tempt_BlockArray.GetLength(0);
            int _maxY = _tempt_BlockArray.GetLength(1);
            //케이스의 로컬위치 설정
            CaseObject.transform.localPosition = new Vector2(InputSize.x * (1 - _maxX), 0);


            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    //Debug.Log(j_x + "+" + i_y+"+"+ _tempt_BlockArray[j_x, i_y]);

                    if (_tempt_BlockArray[j_x, i_y] == 1)
                    {
                        _spawned = Instantiate(_outLinerWorld, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * j_x, (InputSize.y * i_y), 0);
                        _spawned.transform.localPosition = spawnedvector + new Vector3(0, 0, 0.1f);
                        _spawned.transform.localScale = InputSize * OutlinePercent;
                        _current_Case._childObjects.Add(_spawned);


                        _spawned = Instantiate(_worldBlockCell, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        BlockCaseCell _current_Cell = _spawned.GetComponent<BlockCaseCell>();
                        _current_Cell.SetMaterial(SetElementToBlockMaterial(_inputInfo._blockElement));
                        _current_Cell.SetParentCase(_current_Case);
                        _current_Case._childCase.Add(_current_Cell);
                        _spawned.transform.localScale = InputSize;
                        _spawned.transform.localPosition = spawnedvector;
                        _current_Case._childObjects.Add(_spawned);



                    }
                }
            }

            _current_Case.SetCaseToCenter();


            Global_InWorldEventSystem.CallOn블록생성(_lastBlockInfo);

            return CaseObject;


        }

        #endregion

        // 케이스를 생성하는 곳
        public GameObject GenerateOnNormalCase(BlockInfo _inputInfo, Transform _casePos, float _caseSize)
        {
            _lastBlockInfo = _inputInfo;
            int[,] _tempt_BlockArray = (int[,])_lastBlockInfo._blockShapeArr.Clone();

            //내부에서 사용될 블록의 사이즈
            int _maxX = _tempt_BlockArray.GetLength(0);
            int _maxY = _tempt_BlockArray.GetLength(1);
            int _longerMax = _maxX > _maxY ? _maxX : _maxY;
            float _length = _caseSize * 0.9f;
            _length = (_length / _longerMax);

            Vector2 InputSize = new Vector2(_length, _length);
            //TestCaller.instance.DebugArrayShape(_tempt_BlockArray);

            //케이스 생성
            GameObject CaseObject = _casePos.gameObject;
            BlockCase_World _current_Case = CaseObject.GetComponent<BlockCase_World>();

            //케이스 오브젝트 로컬 위치 설정
            //CaseObject.transform.localPosition += new Vector3(InputSize.x * (1 - _maxX), 0, 0);


            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    if (_tempt_BlockArray[j_x, i_y] == 1)
                    {
                        _spawned = Instantiate(_outLinerWorld, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * (j_x - (_maxX - 1) * 0.5f),
                            (InputSize.y * (i_y - (_maxY - 1) * 0.5f)), 0);
                        _spawned.transform.localPosition = spawnedvector;
                        _spawned.transform.localScale = InputSize * OutlinePercent;
                        _current_Case._childObjects.Add(_spawned);


                        _spawned = Instantiate(_worldBlockCell, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        BlockCaseCell _current_Cell = _spawned.GetComponent<BlockCaseCell>();
                        _current_Cell.SetMaterial(SetElementToBlockMaterial(_inputInfo._blockElement));
                        _current_Cell.SetParentCase(_current_Case);
                        _spawned.transform.localScale = InputSize;

                        _current_Case._childCase.Add(_current_Cell);

                        _spawned.transform.localPosition = spawnedvector;
                        _current_Case._childObjects.Add(_spawned);



                    }
                }
            }

            _current_Case.SetCaseToCenter();
            _current_Case._blockInfo = new BlockInfo(_lastBlockInfo);

            Global_InWorldEventSystem.CallOn블록생성(_lastBlockInfo);
            return CaseObject;
        }
        public GameObject GenerateOnConveyerCase(BlockInfo _inputInfo, Transform _casePos, float _caseSize)
        {
            _lastBlockInfo = _inputInfo;
            int[,] _tempt_BlockArray = (int[,])_lastBlockInfo._blockShapeArr.Clone();

            //내부에서 사용될 블록의 사이즈
            int _maxX = _tempt_BlockArray.GetLength(0);
            int _maxY = _tempt_BlockArray.GetLength(1);
            int _longerMax = _maxX > _maxY ? _maxX : _maxY;
            float _length = _caseSize * 0.9f;
            _length = (_length / _longerMax);

            Vector2 InputSize = new Vector2(_length, _length);
            //TestCaller.instance.DebugArrayShape(_tempt_BlockArray);

            //케이스 생성
            GameObject CaseObject = _casePos.gameObject;
            Battle_Conveyer_Case _current_Case = CaseObject.GetComponent<Battle_Conveyer_Case>();

            //케이스 오브젝트 로컬 위치 설정


            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    if (_tempt_BlockArray[j_x, i_y] == 1)
                    {
                        _spawned = Instantiate(_outLinerWorld, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * (j_x - (_maxX - 1) * 0.5f),
                                                   (InputSize.y * (i_y - (_maxY - 1) * 0.5f)), 0);
                        _spawned.transform.localPosition = spawnedvector;
                        _spawned.transform.localScale = InputSize * OutlinePercent;
                        _current_Case.SetChildObjOnList(_spawned);

                        _spawned = Instantiate(_worldBlockCell, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        BlockCaseCell _current_Cell = _spawned.GetComponent<BlockCaseCell>();
                        _current_Cell.SetMaterial(SetElementToBlockMaterial(_inputInfo._blockElement));
                        _current_Cell.SetParentCase(_current_Case);
                        _spawned.transform.localScale = InputSize;

                        _current_Case.SetChildCaseOnList(_current_Cell);

                        _spawned.transform.localPosition = spawnedvector;
                        _current_Case.SetChildObjOnList(_spawned);



                    }
                }
            }
            _current_Case.SetCaseToCenter();
            _current_Case._blockInfo = new BlockInfo(_lastBlockInfo);

            Global_InWorldEventSystem.CallOn블록생성(_lastBlockInfo);
            return CaseObject;
        }
        public GameObject GenerateModuleOnUI(BlockInfo _inputInfo, Transform _casePos, float _caseSize)
        {
            _lastBlockInfo = _inputInfo;
            int[,] _tempt_BlockArray = (int[,])_lastBlockInfo._blockShapeArr.Clone();

            //내부에서 사용될 블록의 사이즈
            int _maxX = _tempt_BlockArray.GetLength(0);
            int _maxY = _tempt_BlockArray.GetLength(1);
            int _longerMax = _maxX > _maxY ? _maxX : _maxY;
            float _length = _caseSize * 0.9f;
            _length = (_length / _longerMax);

            Vector2 InputSize = new Vector2(_length, _length);
            //TestCaller.instance.DebugArrayShape(_tempt_BlockArray);

            //케이스 생성
            GameObject CaseObject = Instantiate(_blockCase_Module_UI,_casePos);
            BlockCase_Module_UI _current_Case = CaseObject.GetComponent<BlockCase_Module_UI>();
            _current_Case.InitializeModule(_inputInfo, Global_CanvasData.CanvasData._worldToCanvasSize);

            //케이스 오브젝트 로컬 위치 설정
            //CaseObject.transform.localPosition += new Vector3(InputSize.x * (1 - _maxX), 0, 0);

            int _blockNum = 0;
            Vector3 _totalPos = new Vector3();
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    if (_tempt_BlockArray[j_x, i_y] == 3)
                    {
                        _spawned = Instantiate(_outLinerWorld, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * (j_x - (_maxX - 1) * 0.5f),
                                                    (InputSize.y * (i_y - (_maxY - 1) * 0.5f)), 1);
                        _spawned.transform.localPosition = spawnedvector + new Vector3(0, 0, 0.1f);
                        _spawned.transform.localScale = InputSize * OutlinePercent;
                        _spawned.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                        _current_Case.SetChildObjOnList(_spawned);

                        _spawned = Instantiate(_worldModuleCell, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        BlockCaseCell _current_Cell = _spawned.GetComponent<BlockCaseCell>();
                        _current_Cell.SetMaterial(SetElementToBlockMaterial(_inputInfo._blockElement));
                        _current_Cell.SetParentCase(_current_Case);
                        _spawned.transform.localScale = InputSize;
                        _spawned.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

                        _current_Case.SetChildCaseOnList(_current_Cell);

                        _spawned.transform.localPosition = spawnedvector;
                        _current_Case.SetChildObjOnList(_spawned);

                        Global_FXPlayer.PlayFX(ElementToBlockFX[_inputInfo._blockElement], _spawned.transform.position, _spawned.transform);
                        _totalPos += _spawned.transform.position;
                        _blockNum++;
                    }
                    else if (_tempt_BlockArray[j_x, i_y] == 4)
                    {
                        _spawned = Instantiate(_moduleActivate, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * (j_x - (_maxX - 1) * 0.5f),
                                                    (InputSize.y * (i_y - (_maxY - 1) * 0.5f)), 1);
                        _spawned.transform.localPosition = spawnedvector;
                        _spawned.transform.localScale = InputSize;
                        _current_Case.SetChildObjOnList(_spawned);

                        _spawned.GetComponent<ModuleActivate_ParticleSetter>().SetAllParticleColor(BlockElementPool._ElementToColor[_inputInfo._blockElement]);

                        _totalPos += _spawned.transform.position;
                        _blockNum++;
                    }
                    else if (_tempt_BlockArray[j_x, i_y] == 5)
                    {
                        _spawned = Instantiate(_module_Occupy, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * (j_x - (_maxX - 1) * 0.5f),
                                                   (InputSize.y * (i_y - (_maxY - 1) * 0.5f)), 1);
                        _spawned.transform.localPosition = spawnedvector;
                        _spawned.transform.localScale = InputSize;
                        _current_Case.SetChildObjOnList(_spawned);


                        _totalPos += _spawned.transform.position;
                        _blockNum++;
                    }
                }
            }

            _current_Case.SetSpritePos(_totalPos/_blockNum);
            _current_Case._blockInfo = new BlockInfo(_lastBlockInfo);

            Global_InWorldEventSystem.CallOn블록생성(_lastBlockInfo);
            return CaseObject;
        }

        void CheckWhereToSet(BlockInfo info)
        {
            TestCaller.instance.DebugArrayShape("BlockPlacedOn" + info._blockPlace, info._blockShapeArr);
        }
        



        Material SetElementToBlockMaterial(BlockElement _element)
        {
            switch (_element)
            {
                case BlockElement.Aggressive:
                    return _mat_Agr;
                case BlockElement.Cynical:
                    return _mat_Cyn;
                case BlockElement.Friendly:
                    return _mat_Frn;
                case BlockElement.Emptiness:
                    return _mat_Emp;
                case BlockElement.Bonus:
                    return _mat_Bonus;
                default:
                    Debug.LogError("ElementSetError");
                    return null;
            }
        }
        Material SetElementToModuleMaterial(BlockElement _element)
        {
            switch (_element)
            {
                case BlockElement.Aggressive:
                    return _mat_Agr_Module;
                case BlockElement.Cynical:
                    return _mat_Cyn_Module;
                case BlockElement.Friendly:
                    return _mat_Frn_Module;
                case BlockElement.Emptiness:
                    return _mat_Emp_Module;
                case BlockElement.Bonus:
                    return _mat_Bonus_Module;
                default:
                    Debug.LogError("ElementSetError");
                    return null;
            }
        }



    }

}

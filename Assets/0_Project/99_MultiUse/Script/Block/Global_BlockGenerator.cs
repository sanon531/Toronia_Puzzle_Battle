using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Battle;
using ToronPuzzle.Event;

namespace ToronPuzzle
{
    public class Global_BlockGenerator : MonoBehaviour
    {
        public static Global_BlockGenerator instance;
        [SerializeField]
        BlockInfo _lastBlockInfo;
        #region
        GameObject _spawned;//매개로 사용되는 변수
        GameObject _blockCase_world,_worldBlock, _UIBlock, _outLinerWorld, _outlinerUI;
        [SerializeField]
        Material _mat_Agr, _mat_Agr_Module, _mat_Cyn, _mat_Cyn_Module, 
            _mat_Frn, _mat_Frn_Module,
            _mat_Emp, _mat_Emp_Module,
            _mat_Bonus, _mat_Bonus_Module;

        public Vector2 BlockSize;
        public Vector3 OutlinePercent =new Vector3(1.2f, 1.2f,1.2f);
        #endregion


        public BlockElement this_BlockElement;


        public void BeginBlockGenerator()
        {
            instance = this;
            _worldBlock = Resources.Load("BlockCase/BlockCaseCell_World") as GameObject;
            _UIBlock = Resources.Load("BlockCase/BlockCaseCell_UI") as GameObject;
            _outLinerWorld = Resources.Load("BlockCase/BlockCaseOutLiner_World") as GameObject;
            _outlinerUI = Resources.Load("BlockCase/BlockCaseOutLiner_UI") as GameObject;
            _blockCase_world = Resources.Load("BlockCase/BlockCase_World") as GameObject;

            _mat_Agr = Resources.Load("Material/Block_Aggresive") as Material;
            _mat_Agr_Module = Resources.Load("Material/Module_Aggresive") as Material;
            _mat_Cyn = Resources.Load("Material/Block_Cynical") as Material;
            _mat_Cyn_Module = Resources.Load("Material/Module_Cynical") as Material;
            _mat_Frn = Resources.Load("Material/Block_Friendly") as Material;
            _mat_Frn_Module = Resources.Load("Material/Module_Friendly") as Material;
            _mat_Emp = Resources.Load("Material/Block_Emptiness") as Material;
            _mat_Emp_Module = Resources.Load("Material/Module_Emptiness") as Material;
            _mat_Bonus = Resources.Load("Material/Block_Bonus") as Material;
            _mat_Bonus_Module = Resources.Load("Material/Module_Bonus") as Material;

        }

        public GameObject GenerateOnBlockPlace(BlockInfo _inputInfo)
        {
            _lastBlockInfo = _inputInfo;
            int[,] _tempt_BlockArray = (int[,])_lastBlockInfo._blockShapeArr.Clone();
            Vector2 InputSize = Master_Battle.Data_OnlyInBattle._cellsize;

            //케이스 생성
            GameObject CaseObject = 
                Instantiate(_blockCase_world, transform.position, Quaternion.identity, Master_BlockPlace.instance._blockHolder);
            BlockCase_World _current_Case = CaseObject.GetComponent<BlockCase_World>();

            _current_Case._blockInfo = new BlockInfo(_lastBlockInfo);
            int _maxX = _tempt_BlockArray.GetLength(0);
            int _maxY = _tempt_BlockArray.GetLength(1);


            for (int i_y = _maxY-1; i_y > 0 ; i_y--)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    if (_tempt_BlockArray[j_x, i_y] == 1)
                    {
                        _spawned = Instantiate(_outLinerWorld, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * j_x, (InputSize.y * i_y), 0);
                        _spawned.transform.localPosition = spawnedvector;
                        _spawned.transform.localScale = OutlinePercent;
                        _current_Case._childObjects.Add(_spawned);


                        _spawned = Instantiate(_worldBlock, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        BlockCaseCell _current_Cell = _spawned.GetComponent<BlockCaseCell>();
                        _current_Cell.SetMaterial(SetElementToBlockMaterial(_inputInfo._blockElement));
                        _current_Cell.SetParentCase(_current_Case);
                        _current_Case._childCase.Add(_current_Cell);
                        _spawned.transform.localPosition = spawnedvector;
                        _current_Case._childObjects.Add(_spawned);



                    }
                }
            }

            _current_Case.SetCaseToCenter();


            Global_InWorldEventSystem.CallOn블록배치();

            return CaseObject;
        }


        //
        public GameObject GenerateOnPointer(BlockInfo _inputInfo,Transform _pointerTranform)
        {
            

            _lastBlockInfo = _inputInfo;


            int[,] _tempt_BlockArray = (int[,])_lastBlockInfo._blockShapeArr.Clone();
            Vector2 InputSize = Master_Battle.Data_OnlyInBattle._cellsize;

            //케이스 생성
            GameObject CaseObject =Instantiate(_blockCase_world, _pointerTranform.position, 
                Quaternion.identity, _pointerTranform);


            BlockCase_World _current_Case = CaseObject.GetComponent<BlockCase_World>();
            _current_Case._blockInfo = new BlockInfo(_lastBlockInfo);
            int _maxX = _tempt_BlockArray.GetLength(0);
            int _maxY = _tempt_BlockArray.GetLength(1);
            //케이스의 로컬위치 설정
            CaseObject.transform.localPosition = new Vector2(InputSize.x * (1-_maxX),0);


            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    //Debug.Log(j_x + "+" + i_y+"+"+ _tempt_BlockArray[j_x, i_y]);

                    if (_tempt_BlockArray[j_x, i_y] == 1)
                    {
                        _spawned = Instantiate(_outLinerWorld, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * j_x, (InputSize.y * i_y), 0);
                        _spawned.transform.localPosition = spawnedvector;
                        _spawned.transform.localScale = InputSize * OutlinePercent;
                        _current_Case._childObjects.Add(_spawned);


                        _spawned = Instantiate(_worldBlock, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
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


            Global_InWorldEventSystem.CallOn블록배치();

            return CaseObject;
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

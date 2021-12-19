using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Event;
using ToronPuzzle.Battle;

namespace ToronPuzzle.Data
{
    //블록 배치시에 만약 
    public class Module_PlaceActive : ModuleInfo
    {
        BlockInfo _moduleBlock;
        List<Vector2Int> _triggerPos = new List<Vector2Int>();
        protected override void Enable()
        {
            base.Enable();
            _moduleBlock = new BlockInfo(Global_BlockPlaceMaster.instance.GetModuleFromIt(ModuleID.쇄빙));
            SetTriggerPos();

            //CheckActivePlace(_moduleBlock);
            Global_InWorldEventSystem._on블록배치 += BreakBlock;
        }

        protected override void Disable()
        {
            base.Disable();
            RemoveTriggerPos();
        }
        void SetTriggerPos()
        {
            int _maxX = _moduleBlock._blockShapeArr.GetLength(0);
            int _maxY = _moduleBlock._blockShapeArr.GetLength(1);
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
                for (int j_x = 0; j_x < _maxX; j_x++)
                    if (_moduleBlock._blockShapeArr[j_x, i_y] == 4)
                        _triggerPos.Add(new Vector2Int(_moduleBlock._blockPlace.x - _maxX + j_x + 1, _moduleBlock._blockPlace.y + i_y));


        }
        void RemoveTriggerPos()
        {
            _triggerPos.Clear();
        }
        //판을 기준으로
        void PrintActivePlace(BlockInfo _info)
        {
            int _maxX = _info._blockShapeArr.GetLength(0);
            int _maxY = _info._blockShapeArr.GetLength(1);
            string _printStr = _info._blockPlace.ToString() + "Place Coordinate ";
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    if (_info._blockShapeArr[j_x, i_y] != 0)
                    {
                        _printStr += " (";
                        _printStr += (_info._blockPlace.x - _maxX + j_x + 1).ToString();
                        _printStr += ",";
                        _printStr += (_info._blockPlace.y + i_y).ToString();
                        _printStr += ") ";
                    }
                }
            }

            Debug.Log(_printStr);

        }
        bool CheckBlockEntered(BlockInfo _info)
        {
            int _maxX = _info._blockShapeArr.GetLength(0);
            int _maxY = _info._blockShapeArr.GetLength(1);
            bool _returnVal = false;
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
                for (int j_x = 0; j_x < _maxX; j_x++)
                    if (_info._blockShapeArr[j_x, i_y] != 0)
                    {
                        _returnVal = (_triggerPos.Contains(new Vector2Int(
                                _info._blockPlace.x - _maxX + j_x + 1, _info._blockPlace.y + i_y))) ? true : _returnVal;
                    }

            return _returnVal;

        }
        void BreakBlock(BlockInfo _arginfo)
        {
            //해당 블럭을 타겟으로 해서 제거하는것
            //제거한뒤의 것은 각자 막 다를것.
            if (CheckBlockEntered(_arginfo))
            {
                //여기서 이제 할것들 한다. 들어온 애가 같은 색깔일때만 작동함.
                BlockInfo _savedInfo = new BlockInfo(_arginfo);
                BlockCase_BlockPlace _case = Global_BlockPlaceMaster.instance.GetBlockCaseByInfo(_arginfo);
                Global_BlockPlaceMaster.instance.RemoveBlockOnPlace(_case);
                _case.DeleteBlock();
            }

            //TestCaller.instance.DebugArrayShape("BlockPlacedOn" + _arginfo._blockPlace, _arginfo._blockShapeArr);
            //Debug.Log("ModuleTargetPlace" + _arginfo._blockPlace);



        }
    }


    //냉소블록 배치시 같은 위치에 1x1블록으로 쪼개 버립니다. 
    public class Module_쇄빙 : ModuleInfo
    {
        BlockInfo _moduleBlock;
        List<Vector2Int> _triggerPos = new List<Vector2Int>();
        protected override void Enable()
        {
            base.Enable();
            float _amount = BlockElementPool._powerTofloatDic[Element_Power.약];
            Global_InWorldEventSystem.CallOn속성배율변동(
                BlockElement.Cynical, new Vector3(_amount, 0f , 0f));

            _moduleBlock = new BlockInfo(Global_BlockPlaceMaster.instance.GetModuleFromIt(ModuleID.쇄빙));
            SetTriggerPos();

            //CheckActivePlace(_moduleBlock);
            Global_InWorldEventSystem._on블록배치 += BreakBlock;
        }

        protected override void Disable()
        {
            base.Disable();
            float _amount = BlockElementPool._powerTofloatDic[Element_Power.약];
            Global_InWorldEventSystem.CallOn속성배율변동(
                BlockElement.Cynical, new Vector3(-_amount, 0f, 0f));

            RemoveTriggerPos();
            Global_InWorldEventSystem._on블록배치 -= BreakBlock;
        }
        void SetTriggerPos()
        {
            int _maxX = _moduleBlock._blockShapeArr.GetLength(0);
            int _maxY = _moduleBlock._blockShapeArr.GetLength(1);
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
                for (int j_x = 0; j_x < _maxX; j_x++)
                    if (_moduleBlock._blockShapeArr[j_x, i_y] == 4)
                        _triggerPos.Add(new Vector2Int(_moduleBlock._blockPlace.x - _maxX + j_x + 1, _moduleBlock._blockPlace.y + i_y));


        }

        void RemoveTriggerPos()
        {
            _triggerPos.Clear();
        }

        //판을 기준으로
        void PrintActivePlace(BlockInfo _info)
        {
            int _maxX = _info._blockShapeArr.GetLength(0);
            int _maxY = _info._blockShapeArr.GetLength(1);
            string _printStr = _info._blockPlace.ToString() + "Place Coordinate ";
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    if (_info._blockShapeArr[j_x, i_y] != 0)
                    {
                        _printStr += " (";
                        _printStr += (_info._blockPlace.x - _maxX + j_x + 1).ToString();
                        _printStr += ",";
                        _printStr += (_info._blockPlace.y + i_y).ToString();
                        _printStr += ") ";
                    }
                }
            }

            Debug.Log(_printStr);

        }

        bool CheckBlockEntered(BlockInfo _info)
        {
            int _maxX = _info._blockShapeArr.GetLength(0);
            int _maxY = _info._blockShapeArr.GetLength(1);
            bool _returnVal = false;
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
                for (int j_x = 0; j_x < _maxX; j_x++)
                    if (_info._blockShapeArr[j_x, i_y] != 0)
                    {
                        _returnVal = (_triggerPos.Contains(new Vector2Int(
                                _info._blockPlace.x - _maxX + j_x + 1, _info._blockPlace.y + i_y))) ? true : _returnVal;
                    }

            return _returnVal;

        }
        bool CheckBlockIsCrackable(int[,] _argArr)
        {
            bool _returnVal = true;
            int _maxX = _argArr.GetLength(0);
            int _maxY = _argArr.GetLength(1);
            _returnVal = (_maxX == 1 && _maxY == 1) ? false : true;


            return _returnVal;
        }

        void BreakBlock(BlockInfo _arginfo)
        {
            //해당 블럭을 타겟으로 해서 제거하는것
            //제거한뒤의 것은 각자 막 다를것.
            if (CheckBlockEntered(_arginfo))
            {


                //여기서 이제 할것들 한다. 들어온 애가 같은 색깔일때만 작동함.
                if (_arginfo._blockElement == BlockElement.Cynical && CheckBlockIsCrackable(_arginfo._blockShapeArr))
                {
                    BlockInfo _savedInfo = new BlockInfo(_arginfo);
                    BlockCase_BlockPlace _case = Global_BlockPlaceMaster.instance.GetBlockCaseByInfo(_arginfo);
                    Global_BlockPlaceMaster.instance.RemoveBlockOnPlace(_case);


                    int _maxX = _savedInfo._blockShapeArr.GetLength(0);
                    int _maxY = _savedInfo._blockShapeArr.GetLength(1);
                    BlockInfo _oneByOneInfo = new BlockInfo(BlockElement.Cynical, BlockShape.One_D, 1);
                    Vector2Int _targetVecInt = new Vector2Int();
                    Global_SoundManager.Instance.PlaySFX(SFXName.Frozen_Crack);
                    for (int i_y = _maxY - 1; i_y >= 0; i_y--)
                        for (int j_x = 0; j_x < _maxX; j_x++)
                            if (_savedInfo._blockShapeArr[j_x, i_y] != 0)
                            {
                                _targetVecInt = new Vector2Int(_savedInfo._blockPlace.x - _maxX + j_x + 1, _savedInfo._blockPlace.y + i_y);
                                Global_BlockPlaceMaster.instance.SetBlockCallByPos(_targetVecInt, _oneByOneInfo);
                                Global_FXPlayer.PlayFX(FXKind.Module_쇄빙, Global_BlockPlaceMaster.instance.GetCellPosByOrder(_targetVecInt));
                            }




                    _case.DeleteBlock();
                }
            }

            //TestCaller.instance.DebugArrayShape("BlockPlacedOn" + _arginfo._blockPlace, _arginfo._blockShapeArr);
            //Debug.Log("ModuleTargetPlace" + _arginfo._blockPlace);
        }

    }

    //배치시 제거되고 1.25배 뎀으로 바로 공격 적용
    public class Module_승화 : ModuleInfo
    {
        BlockInfo _moduleBlock;
        List<Vector2Int> _triggerPos = new List<Vector2Int>();
        protected override void Enable()
        {
            base.Enable();
            _moduleBlock = new BlockInfo(Global_BlockPlaceMaster.instance.GetModuleFromIt(ModuleID.승화));
            SetTriggerPos();

            //CheckActivePlace(_moduleBlock);
            Global_InWorldEventSystem._on블록배치 += BreakBlock;
        }

        protected override void Disable()
        {
            base.Disable();

            Global_InWorldEventSystem._on블록배치 -= BreakBlock;
        }
        void SetTriggerPos()
        {
            int _maxX = _moduleBlock._blockShapeArr.GetLength(0);
            int _maxY = _moduleBlock._blockShapeArr.GetLength(1);
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
                for (int j_x = 0; j_x < _maxX; j_x++)
                    if (_moduleBlock._blockShapeArr[j_x, i_y] == 4)
                        _triggerPos.Add(new Vector2Int(_moduleBlock._blockPlace.x - _maxX + j_x + 1, _moduleBlock._blockPlace.y + i_y));


        }

        //판을 기준으로
        void PrintActivePlace(BlockInfo _info)
        {
            int _maxX = _info._blockShapeArr.GetLength(0);
            int _maxY = _info._blockShapeArr.GetLength(1);
            string _printStr = _info._blockPlace.ToString() + "Place Coordinate ";
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    if (_info._blockShapeArr[j_x, i_y] != 0)
                    {
                        _printStr += " (";
                        _printStr += (_info._blockPlace.x - _maxX + j_x + 1).ToString();
                        _printStr += ",";
                        _printStr += (_info._blockPlace.y + i_y).ToString();
                        _printStr += ") ";
                    }
                }
            }

            Debug.Log(_printStr);

        }
        bool CheckBlockEntered(BlockInfo _info)
        {
            int _maxX = _info._blockShapeArr.GetLength(0);
            int _maxY = _info._blockShapeArr.GetLength(1);
            bool _returnVal = false;
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
                for (int j_x = 0; j_x < _maxX; j_x++)
                    if (_info._blockShapeArr[j_x, i_y] != 0)
                    {
                        _returnVal = (_triggerPos.Contains(new Vector2Int(
                                _info._blockPlace.x - _maxX + j_x + 1, _info._blockPlace.y + i_y))) ? true : _returnVal;
                    }

            return _returnVal;

        }
        void BreakBlock(BlockInfo _arginfo)
        {
            //해당 블럭을 타겟으로 해서 제거하는것
            //제거한뒤의 것은 각자 막 다를것.
            if (CheckBlockEntered(_arginfo))
            {

                if (_arginfo._blockElement == BlockElement.Aggressive)
                {

                    //여기서 이제 할것들 한다. 들어온 애가 같은 색깔일때만 작동함.
                    BlockInfo _savedInfo = new BlockInfo(_arginfo);
                    BlockCase_BlockPlace _case = Global_BlockPlaceMaster.instance.GetBlockCaseByInfo(_arginfo);
                    Global_SoundManager.Instance.PlaySFX(SFXName.Fire_Explosion);
                    Global_FXPlayer.PlayFX(FXKind.Module_승화, _case.transform.position);
                    Global_InWorldEventSystem.CallOnCalc데미지(Master_Battle.Data_OnlyInBattle._enemyData, 
                        DataEntity.고유데이터(_arginfo._blockStength * 10));
                    Global_BlockPlaceMaster.instance.RemoveBlockDataOnArray(_case._blockInfo);
                    Global_BlockPlaceMaster.instance.RemoveBlockOnPlace(_case);
                    _case.DeleteBlock();


                }
            }

            //TestCaller.instance.DebugArrayShape("BlockPlacedOn" + _arginfo._blockPlace, _arginfo._blockShapeArr);
            //Debug.Log("ModuleTargetPlace" + _arginfo._blockPlace);



        }


    }


    public class Module_개미지옥 : ModuleInfo
    {
        BlockInfo _moduleBlock;
        List<Vector2Int> _triggerPos = new List<Vector2Int>();
        protected override void Enable()
        {
            base.Enable();
            float _amount = BlockElementPool._powerTofloatDic[Element_Power.강];
            Global_InWorldEventSystem.CallOn속성배율변동(BlockElement.Friendly, new Vector3(_amount, _amount, 0f));
            _moduleBlock = new BlockInfo(Global_BlockPlaceMaster.instance.GetModuleFromIt(ModuleID.개미지옥));
            SetTriggerPos();

            //CheckActivePlace(_moduleBlock);
            Global_InWorldEventSystem._on블록배치 += BreakBlock;
        }

        protected override void Disable()
        {
            base.Disable();
            RemoveTriggerPos();
            float _amount = BlockElementPool._powerTofloatDic[Element_Power.강];
            Global_InWorldEventSystem.CallOn속성배율변동(BlockElement.Friendly, new Vector3(-_amount, -_amount, 0f));
            Global_InWorldEventSystem._on블록배치 -= BreakBlock;
        }
        void SetTriggerPos()
        {
            int _maxX = _moduleBlock._blockShapeArr.GetLength(0);
            int _maxY = _moduleBlock._blockShapeArr.GetLength(1);
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
                for (int j_x = 0; j_x < _maxX; j_x++)
                    if (_moduleBlock._blockShapeArr[j_x, i_y] == 4)
                        _triggerPos.Add(new Vector2Int(_moduleBlock._blockPlace.x - _maxX + j_x + 1, _moduleBlock._blockPlace.y + i_y));


        }
        void RemoveTriggerPos()
        {
            _triggerPos.Clear();
        }
        //판을 기준으로
        void PrintActivePlace(BlockInfo _info)
        {
            int _maxX = _info._blockShapeArr.GetLength(0);
            int _maxY = _info._blockShapeArr.GetLength(1);
            string _printStr = _info._blockPlace.ToString() + "Place Coordinate ";
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    if (_info._blockShapeArr[j_x, i_y] != 0)
                    {
                        _printStr += " (";
                        _printStr += (_info._blockPlace.x - _maxX + j_x + 1).ToString();
                        _printStr += ",";
                        _printStr += (_info._blockPlace.y + i_y).ToString();
                        _printStr += ") ";
                    }
                }
            }

            Debug.Log(_printStr);

        }
        bool CheckBlockEntered(BlockInfo _info)
        {
            int _maxX = _info._blockShapeArr.GetLength(0);
            int _maxY = _info._blockShapeArr.GetLength(1);
            bool _returnVal = false;
            for (int i_y = _maxY - 1; i_y >= 0; i_y--)
                for (int j_x = 0; j_x < _maxX; j_x++)
                    if (_info._blockShapeArr[j_x, i_y] != 0)
                    {
                        _returnVal = (_triggerPos.Contains(new Vector2Int(
                                _info._blockPlace.x - _maxX + j_x + 1, _info._blockPlace.y + i_y))) ? true : _returnVal;
                    }

            return _returnVal;

        }
        void BreakBlock(BlockInfo _arginfo)
        {
            //해당 블럭을 타겟으로 해서 제거하는것
            //제거한뒤의 것은 각자 막 다를것.
            if (CheckBlockEntered(_arginfo))
            {
                if (_arginfo._blockElement == BlockElement.Friendly )
                {
                    //여기서 이제 할것들 한다. 들어온 애가 같은 색깔일때만 작동함.

                    Global_InWorldEventSystem.CallOnCalc데미지(Master_Battle.Data_OnlyInBattle._playerData, DataEntity.고유데이터(_arginfo._blockStength * 10));
                    BlockInfo _savedInfo = new BlockInfo(_arginfo);
                    BlockCase_BlockPlace _case = Global_BlockPlaceMaster.instance.GetBlockCaseByInfo(_arginfo);
                    Global_SoundManager.Instance.PlaySFX(SFXName.Evil_Action);
                    Global_FXPlayer.PlayFX(FXKind.Module_개미지옥, _case.transform.position);

                    //TestCaller.instance.DebugArrayShape("removed"+ _case._blockInfo._blockPlace.ToString(), _case._blockInfo._blockShapeArr);
                    Global_BlockPlaceMaster.instance.RemoveBlockDataOnArray(_case._blockInfo);
                    Global_BlockPlaceMaster.instance.RemoveBlockOnPlace(_case);

                    _case.DeleteBlock();
                }
            }

            //TestCaller.instance.DebugArrayShape("BlockPlacedOn" + _arginfo._blockPlace, _arginfo._blockShapeArr);
            //Debug.Log("ModuleTargetPlace" + _arginfo._blockPlace);



        }
    }


}


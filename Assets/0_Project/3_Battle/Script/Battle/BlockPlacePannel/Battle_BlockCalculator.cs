using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
using ToronPuzzle.UI;
using ToronPuzzle.Event;

namespace ToronPuzzle.Battle
{
    public class Battle_BlockCalculator : BlockCalculator
    {
        //계산 관련
        [SerializeField]
        int _aggressiveNum, _cynicalNum, _friendlyNum, _emptinessNum, _bonusNum = 0;
        public string GetCurrentNum()
        {
            string temptContentStr = "<sprite=0> : ";
            temptContentStr += (_aggressiveNum.ToString() + " ");
            temptContentStr += ((Vector2)_currentElementValue[BlockElement.Aggressive]).ToString();
            temptContentStr += "\n";
            temptContentStr += "<sprite=1> : ";
            temptContentStr += (_cynicalNum.ToString() + " ");
            temptContentStr += ((Vector2)_currentElementValue[BlockElement.Cynical]).ToString();
            temptContentStr += "\n";
            temptContentStr += "<sprite=2> : ";
            temptContentStr += (_friendlyNum.ToString() + " ");
            temptContentStr += ((Vector2)_currentElementValue[BlockElement.Friendly]).ToString();
            temptContentStr += "\n";
            temptContentStr += "<sprite=3> : ";
            temptContentStr += (_emptinessNum.ToString() + " ");
            temptContentStr += ((Vector2)_currentElementValue[BlockElement.Emptiness]).ToString();
            temptContentStr += "\n";
            temptContentStr += "<sprite=4> : ";
            temptContentStr += (_bonusNum.ToString() + " ");
            temptContentStr += ((Vector2)_currentElementValue[BlockElement.Bonus]).ToString();



            return temptContentStr;
        }

        private void ResetNum()
        {
            _aggressiveNum = 0;
            _cynicalNum = 0;
            _friendlyNum = 0;
            _emptinessNum = 0;
            _bonusNum = 0;
            _attackNum = 0;
            _defendNum = 0;
        }
        private void SetElementToPower()
        {
            _attackNum = _aggressiveNum * _currentElementValue[BlockElement.Aggressive].x
                + _cynicalNum * _currentElementValue[BlockElement.Cynical].x
                + _friendlyNum * _currentElementValue[BlockElement.Friendly].x
                + _emptinessNum * _currentElementValue[BlockElement.Emptiness].x
                + _bonusNum * _currentElementValue[BlockElement.Bonus].x;

            _defendNum = _aggressiveNum * _currentElementValue[BlockElement.Aggressive].y
                + _cynicalNum * _currentElementValue[BlockElement.Cynical].y
                + _friendlyNum * _currentElementValue[BlockElement.Friendly].y
                + _emptinessNum * _currentElementValue[BlockElement.Emptiness].y
                + _bonusNum * _currentElementValue[BlockElement.Bonus].y;


        }
        public override void CalcPannelData(List<BlockInfo> _argBlockInfos)
        {
            ResetNum();
            foreach (BlockInfo _blockInfo in _argBlockInfos)
                switch (_blockInfo._blockElement)
                {
                    case BlockElement.Aggressive:
                        _aggressiveNum += _blockInfo._blockStength;
                        break;
                    case BlockElement.Cynical:
                        _cynicalNum += _blockInfo._blockStength;
                        break;
                    case BlockElement.Friendly:
                        _friendlyNum += _blockInfo._blockStength;
                        break;
                    case BlockElement.Emptiness:
                        _emptinessNum += _blockInfo._blockStength;
                        break;
                    case BlockElement.Bonus:
                        _bonusNum += _blockInfo._blockStength;
                        break;
                    default:
                        Debug.LogError("Calc: default error ");
                        break;
                }
            SetElementToPower();
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_계산표시, _attackNum, _defendNum);
        }
        public override void CalcBonusLine(int[,] _arg_Arr)
        {
            _filledLineX.Clear();
            _filledLineY.Clear();
            foreach (GameObject gameObject in _bonusXColumnLines)
                gameObject.SetActive(false);
            foreach (GameObject gameObject in _bonusYRowLines)
                gameObject.SetActive(false);

            _perfectSetting.SetActive(false);



            //x축 라인 형성 확인.
            for (int i = 0; i < _arg_Arr.GetLength(0); i++)
            {
                bool isLined = true;
                for (int j = 0; j < _arg_Arr.GetLength(1); j++)
                    if (_arg_Arr[i, j] == 0) isLined = false;

                if (isLined) _filledLineX.Add(i);
            }

            for (int i = 0; i < _arg_Arr.GetLength(1); i++)
            {
                bool isLined = true;
                for (int j = 0; j < _arg_Arr.GetLength(0); j++)
                    if (_arg_Arr[j, i] == 0) isLined = false;

                if (isLined) _filledLineY.Add(i);
            }

            int lowestX = 0;
            foreach (int i in _filledLineX)
            {
                _bonusXColumnLines[i].SetActive(true);
                _bonusNum += 2;
                Global_FXPlayer.PlayFX(FXKind.BlockBns_Line, _bonusXColumnLines[i].transform.GetChild(0).position, lowestX * 0.25f);
                Global_FXPlayer.PlayFX(FXKind.BlockBns_Line, _bonusXColumnLines[i].transform.GetChild(1).position, lowestX * 0.25f);
                lowestX++;
            }
            int lowestY = 0;
            foreach (int i in _filledLineY)
            {
                _bonusYRowLines[i].SetActive(true);
                _bonusNum += 2;
                Global_FXPlayer.PlayFX(FXKind.BlockBns_Line,_bonusYRowLines[i].transform.GetChild(0).position, lowestY * 0.25f);
                Global_FXPlayer.PlayFX(FXKind.BlockBns_Line,_bonusYRowLines[i].transform.GetChild(1).position, lowestY * 0.25f);
                lowestY++;
            }



            if (lowestX > lowestY)
                for (int i = 0; i < lowestX; i++)
                {
                    Global_SoundManager.Instance.PlaySFX(SFXName.Bonus_Small, i * 0.25f);
                }
            else
                for (int i = 0; i < lowestY; i++)
                {
                    Global_SoundManager.Instance.PlaySFX(SFXName.Bonus_Small, i * 0.25f);

                }

            if (_filledLineX.Count == _bonusXColumnLines.Count && _filledLineY.Count == _bonusYRowLines.Count)
            {
                _perfectSetting.SetActive(true);
                _bonusNum += 8;
                Global_FXPlayer.PlayFX(FXKind.BlockBns_Full , _fullFXpos, new Vector2((int)(_filledLineX.Count * 0.75f), (int)(_filledLineY.Count * 0.75f)), lowestY * 0.25f);
                Global_SoundManager.Instance.PlaySFX(SFXName.Bonus_Big, lowestY * 0.25f);
            }

        }
        

    }
}

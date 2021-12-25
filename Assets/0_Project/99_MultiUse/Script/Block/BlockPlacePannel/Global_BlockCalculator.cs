using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
using ToronPuzzle.UI;
using ToronPuzzle.Event;

namespace ToronPuzzle
{
    public class Global_BlockCalculator : MonoBehaviour
    {
        //계산 관련
        [SerializeField]
        int _aggressiveNum, _cynicalNum, _friendlyNum, _emptinessNum, _bonusNum = 0;

        public List<GameObject> _bonusXColumnLines = new List<GameObject>();
        public List<GameObject> _bonusYRowLines = new List<GameObject>();
        [SerializeField]
        protected List<int> _filledLineX = new List<int>();
        [SerializeField]
        protected List<int> _filledLineY = new List<int>();
        public GameObject _perfectSetting;
        public Vector2 _fullFXpos = new Vector2();
        public ElementVectorDictionary _currentElementValue;


        DataEntity _attackData = new DataEntity(DataEntity.Type.피해량, 0);
        DataEntity _defendData = new DataEntity(DataEntity.Type.방어도, 0);

        public void BeginBlockCalc()
        {
            _currentElementValue = BlockElementPool._initialElementPowerDic;
            Global_InWorldEventSystem._on속성배율변동 += ChangeBlockElement;
            Global_InWorldEventSystem._on공격배수추가 += ChangeAttackMultiply;
            Global_InWorldEventSystem._on방어배수추가 += ChangeDefendMultiply;

        }
        void ChangeBlockElement(BlockElement _element, Vector3 _amount)
        {
            _currentElementValue[_element] += _amount;
            SetElementToPower();
            //Debug.Log(_element+"+"+_amount);
        }
        void ChangeAttackMultiply(float _배수)
        {
            _attackData.Add증가량배수(_배수);
        }
        void ChangeDefendMultiply(float _배수)
        {
            _defendData.Add증가량배수(_배수);
        }


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
        [SerializeField]
        float _attackNum, _defendNum = 0;
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
        //계산 및 보이는거 여기서 함.
        Coroutine _callCoroutine;
        private void SetElementToPower()
        {
            _attackData.ResetAdd();
            _attackNum = _aggressiveNum * _currentElementValue[BlockElement.Aggressive].x
                + _cynicalNum * _currentElementValue[BlockElement.Cynical].x
                + _friendlyNum * _currentElementValue[BlockElement.Friendly].x
                + _emptinessNum * _currentElementValue[BlockElement.Emptiness].x
                + _bonusNum * _currentElementValue[BlockElement.Bonus].x;
            _attackData.Add증가량(_attackNum);


            _defendData.ResetAdd();
            _defendNum = _aggressiveNum * _currentElementValue[BlockElement.Aggressive].y
                + _cynicalNum * _currentElementValue[BlockElement.Cynical].y
                + _friendlyNum * _currentElementValue[BlockElement.Friendly].y
                + _emptinessNum * _currentElementValue[BlockElement.Emptiness].y
                + _bonusNum * _currentElementValue[BlockElement.Bonus].y;
            _defendData.Add증가량(_defendNum);



            if (_callCoroutine != null)
                Global_CoroutineManager.Stop(_callCoroutine);

            _callCoroutine = Global_CoroutineManager.Run(LateCalc());

            //계산 툴팁 변경 계산.
        }

        IEnumerator LateCalc()
        {
            yield return new WaitForEndOfFrame();
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_계산표시, _attackData.FinalValue, _defendData.FinalValue);
        }


        public void CalcPannelData(List<BlockInfo> _argBlockInfos)
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
        }


        public void CalcBonusLine(int[,] _arg_Arr)
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
                {
                    isLined = (_arg_Arr[i, j] == 0) ? false : isLined;
                    isLined = (_arg_Arr[i, j] == 4) ? false : isLined;
                    isLined = (_arg_Arr[i, j] == 5) ? false : isLined;
                }

                if (isLined) _filledLineX.Add(i);
            }

            for (int i = 0; i < _arg_Arr.GetLength(1); i++)
            {
                bool isLined = true;
                for (int j = 0; j < _arg_Arr.GetLength(0); j++)
                {
                    isLined = (_arg_Arr[j, i] == 0) ? false : isLined;
                    isLined = (_arg_Arr[j, i] == 4) ? false : isLined;
                    isLined = (_arg_Arr[j, i] == 5) ? false : isLined;

                }

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
            SetElementToPower();

        }



        public DataEntity GetAttackData() { return _attackData; }
        public DataEntity GetDefendData() { return _defendData; }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ToronPuzzle.Data;

namespace ToronPuzzle.Battle
{
    public class Battle_BlockCalculator : BlockCalculator
    {

        //계산 관련
        int AggressiveNum, CynicalNum, FriendlyNum, EmptinessNum = 0;
        int _bonusNum = 0;

        public void CalcBonusLine(int[,] _arg_Arr)
        {
            _filledLineX.Clear();
            _filledLineY.Clear();
            foreach (GameObject gameObject in _bonusXColumnLines)
                gameObject.SetActive(false);
            foreach (GameObject gameObject in _bonusYRowLines)
                gameObject.SetActive(false);

            PerfectSetting.SetActive(false);



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
                PerfectSetting.SetActive(true);
                _bonusNum += 8;
                Global_FXPlayer.PlayFX(FXKind.BlockBns_Full , _fullFXpos, new Vector2((int)(_filledLineX.Count * 0.75f), (int)(_filledLineY.Count * 0.75f)), lowestY * 0.25f);
                Global_SoundManager.Instance.PlaySFX(SFXName.Bonus_Big, lowestY * 0.25f);
            }

        }
    }
}

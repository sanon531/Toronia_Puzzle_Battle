using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToronPuzzle.UI;
using ToronPuzzle.Event;

namespace ToronPuzzle.Battle
{
    public class Battle_HealthSet : UI_Object, IGameListenerUI
    {
        RectTransform _playerHealthRect, _enemyHealthRect;
        Slider _playerHealthBar, _enemyHealthBar;
        float _rectHeight, _rectWidth;

        public void AssignGameListener()
        {
            _playerHealthRect = GameObject.Find("BC_Player_Health").GetComponent<RectTransform>();
            _enemyHealthRect = GameObject.Find("BC_Enemy_Health").GetComponent<RectTransform>();
            _playerHealthBar = _playerHealthRect.gameObject.GetComponent<Slider>();
            _enemyHealthBar = _enemyHealthRect.gameObject.GetComponent<Slider>();

            _rectHeight = Screen.height * 0.125f;
            _rectWidth = Screen.width * 0.33f;
            Vector2 _rectVec2 = new Vector2(_rectWidth, _rectHeight * 0.5f);

            _playerHealthRect.sizeDelta = _rectVec2;
            _enemyHealthRect.sizeDelta = _rectVec2;
            _playerHealthRect.anchoredPosition = new Vector2(_rectWidth * 0.5f, _rectHeight * 1.25f);
            _enemyHealthRect.anchoredPosition = new Vector2(-_rectWidth * 0.5f, _rectHeight * 1.25f);
            Global_InWorldEventSystem.onCalc������ += SetDamageOnHealth;

        }

        void SetDamageOnHealth(Data_Character _targetChar, DataEntity �������ü)
        {
            float _changedVal = 0.5f;
            _targetChar.�������� -= �������ü.FinalValue;
            _changedVal = (float)_targetChar.�������� / (float)_targetChar.�ִ�����;

            if (_targetChar.�Ҽ����� == CharacterSide.Ally)
            {
                DamageTextScript.Create(_playerHealthRect.transform.position, 1, 0.3f, -�������ü.FinalValue, Color.red, 0.5f);

                SetPlayerBar(_changedVal);
            }
            else if (_targetChar.�Ҽ����� == CharacterSide.Enemy)
            {
                DamageTextScript.Create(_enemyHealthRect.transform.position, 1, 0.3f, -�������ü.FinalValue, Color.red,0.5f);

                SetEnemyBar(_changedVal);
            }


        }


        void SetPlayerBar(float to){_playerHealthBar.value = to;}
        void SetEnemyBar(float to){_enemyHealthBar.value = to;}

    }
}


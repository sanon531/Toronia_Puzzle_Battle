using TMPro;
using ToronPuzzle.Event;
using ToronPuzzle.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ToronPuzzle.Battle
{
    public class Battle_HealthSet : UI_Object, IGameListenerUI
    {
        RectTransform _playerHealthRect, _enemyHealthRect, _playerGuard, _enemyGuard;
        Slider _playerHealthBar, _enemyHealthBar;
        float _rectHeight, _rectWidth;
        TextMeshProUGUI _playerGuardText, _enemyGuardText;



        public void AssignGameListener()
        {
            _playerHealthRect = GameObject.Find("BC_Player_Health").GetComponent<RectTransform>();
            _enemyHealthRect = GameObject.Find("BC_Enemy_Health").GetComponent<RectTransform>();
            _playerHealthBar = _playerHealthRect.gameObject.GetComponent<Slider>();
            _enemyHealthBar = _enemyHealthRect.gameObject.GetComponent<Slider>();

            _playerGuard = GameObject.Find("BC_PlayerGuard").GetComponent<RectTransform>();
            _playerGuardText = GameObject.Find("BC_PlayerGuardText").GetComponent<TextMeshProUGUI>();
            _enemyGuard = GameObject.Find("BC_EnemyGuard").GetComponent<RectTransform>();
            _enemyGuardText = GameObject.Find("BC_EnemyGuardText").GetComponent<TextMeshProUGUI>();

            _rectHeight = Screen.height * 0.125f;
            _rectWidth = Screen.width * 0.33f;
            Vector2 _healthRectVec2 = new Vector2(_rectWidth, _rectHeight * 0.25f);
            _playerHealthRect.sizeDelta = _healthRectVec2;
            _enemyHealthRect.sizeDelta = _healthRectVec2;

            _playerHealthRect.anchoredPosition = new Vector2(_rectWidth * 0.5f, _rectHeight * 1.2f);
            _enemyHealthRect.anchoredPosition = new Vector2(-_rectWidth * 0.5f, _rectHeight * 1.2f);


            Vector2 _guardRectVec2 = new Vector2(_rectHeight * 0.4f, _rectHeight * 0.4f);
            _playerGuard.sizeDelta = _guardRectVec2;
            _enemyGuard.sizeDelta = _guardRectVec2;
            _playerGuard.anchoredPosition = new Vector2(_rectWidth * 1f + _rectHeight*0.25f , _playerHealthRect.anchoredPosition.y);
            _enemyGuard.anchoredPosition = new Vector2(-(_rectWidth * 1f + _rectHeight*0.25f) , _playerHealthRect.anchoredPosition.y);  




            Global_InWorldEventSystem.onCalc데미지 += SetDamageOnHealth;
            Global_InWorldEventSystem.onCalc방어도 += SetGuardOnCharactor;

        }

        void SetDamageOnHealth(Data_Character _targetChar, DataEntity 계산정보체)
        {
            float _changedVal = 0.5f;
            _targetChar.현재생명력 -= 계산정보체.FinalValue;
            _changedVal = (float)_targetChar.현재생명력 / (float)_targetChar.최대생명력;

            if (_targetChar.소속진영 == CharacterSide.Ally)
            {
                DamageTextScript.Create(_playerHealthRect.transform.position, 1, 0.3f, -계산정보체.FinalValue, Color.red, 0.5f);
                SetPlayerBar(_changedVal);
            }
            else if (_targetChar.소속진영 == CharacterSide.Enemy)
            {
                DamageTextScript.Create(_enemyHealthRect.transform.position, 1, 0.3f, -계산정보체.FinalValue, Color.red,0.5f);
                SetEnemyBar(_changedVal);
            }


        }
        void SetPlayerBar(float to){_playerHealthBar.value = to;}
        void SetEnemyBar(float to){_enemyHealthBar.value = to;}

        void SetGuardOnCharactor(Data_Character _targetChar, DataEntity 계산정보체)
        {
            if (_targetChar.소속진영 == CharacterSide.Ally)
            {
                DamageTextScript.Create(_playerHealthRect.transform.position, 1, 0.3f, -계산정보체.FinalValue, Color.blue, 0.5f);
                SetPlayerGuardPower(계산정보체.FinalValue);
            }
            else if (_targetChar.소속진영 == CharacterSide.Enemy)
            {
                DamageTextScript.Create(_enemyHealthRect.transform.position, 1, 0.3f, -계산정보체.FinalValue, Color.blue, 0.5f);
                SetEnemyGuardPower(계산정보체.FinalValue);
            }

        }

        void SetPlayerGuardPower(int _guardAmount)
        {
            if (_guardAmount <= 0)
                _playerGuard.gameObject.SetActive(false);
            else
            {
                _playerGuard.gameObject.SetActive(true);
                _playerGuardText.SetText(_guardAmount.ToString());
            }
        }
        void SetEnemyGuardPower(int _guardAmount)
        {
            if (_guardAmount <= 0)
                _enemyGuard.gameObject.SetActive(false);
            else
            {
                _enemyGuard.gameObject.SetActive(true);
                _enemyGuardText.SetText(_guardAmount.ToString());
            }
        }

    }
}


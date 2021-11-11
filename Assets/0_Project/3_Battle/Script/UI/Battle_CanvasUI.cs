using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ToronPuzzle.Battle;
using ToronPuzzle.Event;

namespace ToronPuzzle.UI
{
    public class Battle_CanvasUI : UIManager
    {
        public static Battle_CanvasUI Instance;
        public override void BeginUIManager()
        {
            base.BeginUIManager();
            CalculatePartsBegin();
            Instance = this;
        }


        void Update()
        {
            CoolTimeChecker();
        }

        // ���� �˸� �ߴ°�
        #region

       

        #endregion



        // �߾� ���� ��ư, �� ����, ���� ��� ������ ������.
        #region

        Button _calcButton;
        Image _calcImage;
        TextMeshProUGUI _guardText, _speechText;
        void CalculatePartsBegin()
        {
            _calcButton = GameObject.Find("BC_SpeechButton").GetComponent<Button>();
            _calcImage = GameObject.Find("BC_SpeechButtonSet").GetComponent<Image>();
            _speechText = GameObject.Find("BC_SpeechText").GetComponent<TextMeshProUGUI>();

            _calcButton.onClick.AddListener(CallCalcButton);

            Global_InWorldEventSystem.on��Ʋ���� += EnableSpeechButton;
            Global_InWorldEventSystem.on��Ʋ���� += SetCalcTextToStart;
            Global_InWorldEventSystem.on��н��� += IsBattleTrue;
            Global_InWorldEventSystem.on��н��� += SetCalcTextToSpeech;
            Global_InWorldEventSystem.on����޽� += IsBattleFalse;
            Global_InWorldEventSystem.on����޽� += SetCalcTextToStart;

        }
        void SetCalcTextToStart(){ _speechText.SetText("��Ʋ\n����"); }
        void SetCalcTextToSpeech() { _speechText.SetText("�߾�"); }

        void ChangeCalcMaxCooltime(float _changeVal)
        {
            _maxCoolTime = _changeVal;
        }
        void SetCalcButtonOnOff()
        {

        }

        bool isOnBattle = false;
        void CallCalcButton()
        {
            if (isOnBattle)
                SendSpeech();
            else
                ChangeSequence();
        }

        void IsBattleTrue(){ isOnBattle = true; }
        void IsBattleFalse(){ isOnBattle = false; }


        //�ܼ��� ����� ������ �ѱ��.
        void ChangeSequence(){Global_InWorldEventSystem.CallOn�������ѱ��();}

        float _maxCoolTime = 5f;
        float _currentCoolTime = 5f;


        void DisableSpeechButton(){_calcButton.enabled = false;}
        void EnableSpeechButton(){_calcButton.enabled = true;}


        void SendSpeech()
        {
            if (_currentCoolTime >= _maxCoolTime)
            {
                _currentCoolTime = 0;
                Global_InWorldEventSystem.CallOn�ǰ��(
                    Master_Battle.Data_OnlyInBattle._playerData, 
                    Master_Battle.Data_OnlyInBattle._enemyData,DataEntity.����������(1));
            }
            else
            {
                //���� ���� ���̶�� �˸��� ���.
            }
        }

        void CoolTimeChecker()
        {
            if (!isOnBattle){
                _calcImage.fillAmount = 1;
                return;
            }

            if (_currentCoolTime < _maxCoolTime)
            {
                _currentCoolTime += Time.deltaTime;
            }

            _calcImage.fillAmount = _currentCoolTime/_maxCoolTime ;


        }
        void RestartCoolTime()
        {

        }


        #endregion

        //������ ���� ��ư
        Button _sequenceButton;

        //��Ʋ Ÿ�̸� ���� ��ư.
        #region

        #endregion


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ToronPuzzle.Event;
using ToronPuzzle.UI;

namespace ToronPuzzle.Battle
{
    //�߾� ���� ��ư + �ϳѱ�� ��ư.
    public class Battle_SpeechButton : UI_Object, IGameListenerUI
    {
        public void AssignGameListener()
        {
            CalculatePartsBegin();
        }


        Button _calcButton;
        Image _calcImage;
        TextMeshProUGUI _speechText;
        void CalculatePartsBegin()
        {
            _calcButton = GameObject.Find("BC_SpeechButton").GetComponent<Button>();
            _calcImage = GameObject.Find("BC_SpeechButtonSet").GetComponent<Image>();
            _speechText = GameObject.Find("BC_SpeechText").GetComponent<TextMeshProUGUI>();

            _calcButton.onClick.AddListener(CallCalcButton);
            Global_UIEventSystem.Register_UIEvent<bool>(UIEventID.Battle_����ưOnOff, SetCalcButtonOnOff, EventRegistOption.None);
            Global_InWorldEventSystem.on��Ʋ���� += EnableSpeechButton;
            Global_InWorldEventSystem.on��Ʋ���� += SetCalcTextToStart;
            Global_InWorldEventSystem.on��н��� += IsBattleTrue;
            Global_InWorldEventSystem.on��н��� += SetCalcTextToSpeech;
            Global_InWorldEventSystem.on����޽� += IsBattleFalse;
            Global_InWorldEventSystem.on����޽� += SetCalcTextToStart;

        }
        void SetCalcTextToStart() { _speechText.SetText("��Ʋ\n����"); }
        void SetCalcTextToSpeech() { _speechText.SetText("�߾�"); }

        void ChangeCalcMaxCooltime(float _changeVal)
        {
            _maxCoolTime = _changeVal;
        }
        bool isCalcButtonActive = false;

        void SetCalcButtonOnOff(bool _active)
        {
            isCalcButtonActive = _active;
            _calcButton.interactable = _active;
        }



        private void Update()
        {
            CoolTimeChecker();
        }

        bool isOnBattle = false;

        void CallCalcButton()
        {
            if (!isCalcButtonActive) return;

            if (isOnBattle)
                SendSpeech();
            else
                ChangeSequence();
        }

        void IsBattleTrue() { isOnBattle = true; }
        void IsBattleFalse() {_calcImage.fillAmount = 1; isOnBattle = false; }


        //�ܼ��� ����� ������ �ѱ��.
        void ChangeSequence() { Global_InWorldEventSystem.CallOn�������ѱ��(); }

        float _maxCoolTime = 5f;
        float _currentCoolTime = 5f;


        void DisableSpeechButton() { _calcButton.enabled = false; }
        void EnableSpeechButton() { _calcButton.enabled = true; }


        void SendSpeech()
        {
            if (_currentCoolTime >= _maxCoolTime)
            {
                _currentCoolTime = 0;
                Global_InWorldEventSystem.CallOn�ǰ�꼱��();
            }
            else
            {
                //���� ���� ���̶�� �˸��� ���.
            }
        }

        void CoolTimeChecker()
        {
            if (!isOnBattle)
                return;

            if (_currentCoolTime < _maxCoolTime)
            {
                _currentCoolTime += Time.deltaTime;
            }

            _calcImage.fillAmount = _currentCoolTime / _maxCoolTime;


        }



    }
}
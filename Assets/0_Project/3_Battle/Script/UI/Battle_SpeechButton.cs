using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ToronPuzzle.Event;
using ToronPuzzle.UI;
using DG.Tweening;

namespace ToronPuzzle.Battle
{
    //�߾� ���� ��ư + �ϳѱ�� ��ư.
    public class Battle_SpeechButton : UI_Object, IGameListenerUI
    {
        //�ʱ�ȭ
        #region

        public void AssignGameListener()
        {
            CalculatePartsBegin();
        }


        Button _calcButton;
        Image _calcImage;
        Material _calcMat;
        TextMeshProUGUI _speechText;
        ParticleSystem _startParticle;
        void CalculatePartsBegin()
        {
            _calcButton = GameObject.Find("BC_SpeechButton").GetComponent<Button>();
            _calcImage = GameObject.Find("BC_SpeechButtonSet").GetComponent<Image>();
            _calcMat = _calcImage.material;
            _speechText = GameObject.Find("BC_SpeechText").GetComponent<TextMeshProUGUI>();
            _startParticle = GameObject.Find("BC_SpeechExplosion").GetComponent<ParticleSystem>();
            Vector3 _canvasToWorld = GameObject.Find("BattleCanvas").GetComponent<RectTransform>().localScale;
            _startParticle.gameObject.transform.localScale = new Vector3(1/_canvasToWorld.x, 1 / _canvasToWorld.x, 1 / _canvasToWorld.x);
            _calcButton.onClick.AddListener(CallCalcButton);
            Global_UIEventSystem.Register_UIEvent<bool>(UIEventID.Battle_����ưOnOff, SetCalcButtonOnOff, EventRegistOption.None);


            DisableSpeechButton();
            Global_InWorldEventSystem.on��Ʋ���� += EnableSpeechButton;
            Global_InWorldEventSystem.on��Ʋ���� += SetCalcTextToStart;
            Global_InWorldEventSystem.on��Ʋ���� += SetCooltimeData;

            Global_InWorldEventSystem.on��н��� += IsBattleTrue;
            Global_InWorldEventSystem.on��н��� += SetCalcTextToSpeech;


            Global_InWorldEventSystem.on����޽� += IsBattleFalse;
            Global_InWorldEventSystem.on����޽� += SetCalcTextToStart;

        }
        void SetCalcTextToStart() { _speechText.SetText("��Ʋ\n����"); }
        void SetCalcTextToSpeech() { _speechText.SetText("�߾�"); }

        void SetCooltimeData()
        {
            _maxCoolTime = Master_Battle.Data_OnlyInBattle._battleCoolTime;
            _startCoolTime = Master_Battle.Data_OnlyInBattle._startCoolTime;

        }

        bool isCalcButtonActive = false;
        void SetCalcButtonOnOff(bool _active)
        {
            isCalcButtonActive = _active;
            _calcButton.interactable = _active;
            if (_active)
            {
                _calcMat.DOFloat(0.5f, "_FadeAmount", 1f);
                _startParticle.Play();
            }
            else
            {
                _calcMat.DOFloat(1f, "_FadeAmount", 1f);
            }

        }


        #endregion

        //������Ʈ ��Ÿ�� ����
        #region

        private void Update()
        {
            CoolTimeChecker();
        }

        bool isOnBattle = false;
        //��ƼŬ �߻� 1ȸ��. 
        bool _isPlayOnce = true;

        void CallCalcButton()
        {
            if (!isCalcButtonActive) return;

            if (isOnBattle)
                SendSpeech();
            else
                ChangeSequence();
        }

        void IsBattleTrue()
        {
            isOnBattle = true;
            _currentCoolTime = _maxCoolTime - _startCoolTime;
            _isPlayOnce = false;
        }
        void IsBattleFalse() { _calcImage.fillAmount = 1; isOnBattle = false; }


        //�ܼ��� ����� ������ �ѱ��.
        void ChangeSequence() { Global_InWorldEventSystem.CallOn�������ѱ��(); }

        float _maxCoolTime = 10f;
        float _startCoolTime = 3f;
        float _currentCoolTime = 10f;


        void DisableSpeechButton() { _calcButton.enabled = false; }
        void EnableSpeechButton() { _calcButton.enabled = true; }



        void SendSpeech()
        {
            if (_currentCoolTime >= _maxCoolTime)
            {
                _isPlayOnce = false;
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
            else if (!_isPlayOnce && _currentCoolTime >= _maxCoolTime)
            {
                _startParticle.Play();
                _isPlayOnce = true;
            }

            _calcImage.fillAmount = _currentCoolTime / _maxCoolTime;


        }
        #endregion


    }
}
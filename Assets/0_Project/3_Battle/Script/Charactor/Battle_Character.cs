using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using ToronPuzzle.Data;

namespace ToronPuzzle.Battle
{
    public class Battle_Character : Character
    {
        [Header("Blink Parts")]
        [SerializeField]
        private CharacterBlink _characterBlink = new CharacterBlink();

        [SerializeField]
        private CharacterStatusFX _characterStatusFX = new CharacterStatusFX();

        void Awake()
        {
            BeginCharactor();
        }



        public override void BeginCharactor()
        {
            _skeletonAnimation.OnRebuild += ApplyBlink;
        }


        public override void SetMaterialTweenAll()
        {
            foreach (CharStatusEffect charStatus in _status_Effects)
            {


            }
        }
        

        void ApplyBlink(SkeletonRenderer skeletonRenderer)
        {
            StartCoroutine(Blink());
        }
        IEnumerator Blink()
        {
            while (true)
            {
                yield return new WaitForSeconds(_characterBlink._blinkCooltime);
                _characterBlink.SetBlinkTimeByStatus(_status_Effects);
                _skeletonAnimation.Skeleton.SetAttachment(_characterBlink._eyesSlot, _characterBlink._blinkAttachment);
                yield return new WaitForSeconds(_characterBlink._blinkDuration);
                _skeletonAnimation.Skeleton.SetAttachment(_characterBlink._eyesSlot, _characterBlink._eyesOpenAttachment);
            }
        }
    }

    [Serializable]
    public class CharacterBlink
    {
        [SpineSlot]
        public string _eyesSlot;
        [SpineAttachment(currentSkinOnly: true, slotField: "sejin/BlinkedEyes")]
        public string _eyesOpenAttachment;

        [SpineAttachment(currentSkinOnly: true, slotField: "sejin/BlinkedEyes")]
        public string _blinkAttachment;
        [Range(0, 4f)]
        public float _blinkCooltime = 0.05f;

        [Range(0, 0.2f)]
        public float _blinkDuration = 0.05f;

        public CharacterBlink()
        {
            _eyesSlot = "sejin/BlinkedEyes";
            _eyesOpenAttachment = "sejin/BlinkedEyes";
            _eyesOpenAttachment = "sejin/OpenEyes";
        }


        public void SetBlinkTimeByStatus(List <CharStatusEffect> _statusEffects)
        {
            if (_statusEffects.Contains(CharStatusEffect.Horror))
                _blinkCooltime = UnityEngine.Random.Range(0.25f, 1f);
            else if (_statusEffects.Contains(CharStatusEffect.Brave))
                _blinkCooltime = UnityEngine.Random.Range(3f, 4f);
            else
                _blinkCooltime = UnityEngine.Random.Range(0.25f, 3f);

            if (_statusEffects.Contains(CharStatusEffect.Tired))
                _blinkDuration = 1f;
            else
                _blinkDuration = 0.05f;


        }
    }

    //기타 스파인이 아닌 개개인의 탈진 이펙트의 온오프를 여기서 담당한다.
    [Serializable]
    public class CharacterStatusFX
    {
        public StatusObjectDictionary _statusObjectDic;

        public void SetStatusToFX(List<CharStatusEffect> _charStatusEffects)
        {
            foreach (KeyValuePair<CharStatusEffect, GameObject> _statusObject in _statusObjectDic)
                _statusObject.Value.SetActive(false);

            foreach (CharStatusEffect statusEffect in _charStatusEffects)
                _statusObjectDic[statusEffect].SetActive(true);


        }
    }
}

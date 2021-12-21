using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
using System.Linq;
using ToronPuzzle.Data;
using ToronPuzzle.Event;

namespace ToronPuzzle.Battle
{
    public class Battle_Character : Character
    {
      
        [SerializeField]
        private CharacterStatusFX _characterStatusFX = new CharacterStatusFX();

        void Start()
        {
        }
        public override void BeginCharactor()
        {
            //정세진
            if (_characterData.소속진영 == CharacterSide.Ally)
            {
                _skeletonAnimation = GetComponent<SkeletonAnimation>();
                ApplyBlink();
                Global_InWorldEventSystem._on플레이어애니메이션 += CharAnimByString;
            }
            else
            {
                Global_InWorldEventSystem._on적애니메이션 += CharAnimByString;

            }

            _characterData.현재생명력 = _characterData.최대생명력;


        }
        //해당 캐릭터의 애니메이션은스트링 값으로 조절 한다.
        //지금은 스피치 뿐이지만 에임은 따로 분리해서 활용한다.

        void CharAnimByString(BlockElement _element, CharAnimType _type)
        {
            switch (_type)
            {
                case CharAnimType.Think:
                    //발언이전의 과장되지 않은 행동을 의미.
                    break;
                case CharAnimType.Speech:
                    //발언할때 사용할꺼임.
                    SetCharAnimation(_element);
                    break;
                case CharAnimType.Extra:
                    //데미지특수효과등의 
                    break;
                default:
                    Debug.LogError("NocharError");
                    break;
            }



        }
        public override void SetMaterialTweenAll()
        {
            foreach (CharBuff charStatus in _status_Effects)
            {


            }
        }




        //애니메이션 관령
        #region

        TrackEntry m_TrackEntry;
        public StringSpineAnimDictionary _strAnimdic = new StringSpineAnimDictionary {
        { "IDLE", null}, { "Ready", null },{ "Speech_Emp_1", null }, { "Speech_Arg_1", null },
        { "Speech_Arg_2", null },{ "Speech_Cyn_1", null },{ "Speech_Frn_1", null },
        };

        public void SetCharAnimation(BlockElement element)
        {
            //Debug.Log(element);
            switch (element)
            {
                case BlockElement.Aggressive:
                    if (UnityEngine.Random.Range(0, 10) > 5)
                        _AsyncElementAnimation(_strAnimdic.Single(s => s.Key == "Speech_Arg_1").Value, false, 1f);
                    else
                        _AsyncElementAnimation(_strAnimdic.Single(s => s.Key == "Speech_Arg_1").Value, false, 1f);
                    break;
                case BlockElement.Cynical:
                    if (UnityEngine.Random.Range(0, 10) > 5)
                        _AsyncElementAnimation(_strAnimdic.Single(s => s.Key == "Speech_Cyn_1").Value, false, 1f);
                    else
                        _AsyncElementAnimation(_strAnimdic.Single(s => s.Key == "Speech_Cyn_2").Value, false, 1f);
                    break;
                case BlockElement.Friendly:
                    if (UnityEngine.Random.Range(0, 10) > 5)
                        _AsyncElementAnimation(_strAnimdic.Single(s => s.Key == "Speech_Frn_1").Value, false, 1f);
                    else
                        _AsyncElementAnimation(_strAnimdic.Single(s => s.Key == "Speech_Frn_2").Value, false, 1f);
                    break;
                case BlockElement.Emptiness:
                    _AsyncElementAnimation(_strAnimdic.Single(s => s.Key == "Speech_Emp_1").Value, false, 1f);
                    break;

            }
        }


        void _AsyncElementAnimation(AnimationReferenceAsset animClip, bool loop, float timeScale)
        {
            m_TrackEntry = _skeletonAnimation.AnimationState.SetAnimation(1, animClip, loop);
            m_TrackEntry.TimeScale = timeScale;
            m_TrackEntry.Complete += AnimationEntry_Complete;

        }

        public virtual void AnimationEntry_Complete(TrackEntry tracks)
        {
            _skeletonAnimation.AnimationState.SetAnimation(1, _strAnimdic.Single(s => s.Key == "IDLE").Value, true);
        }


        #endregion
        //눈 깜빡이는 액션
        #region

        //[Header("Blink Parts")]
        //[SerializeField]
        private CharacterBlink _characterBlink = new CharacterBlink();


        void ApplyBlink()
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
        #endregion  
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


        public void SetBlinkTimeByStatus(List <CharBuff> _statusEffects)
        {

            if (_statusEffects.Contains(CharBuff.Horror))
                _blinkCooltime = UnityEngine.Random.Range(0.25f, 1f);
            else if (_statusEffects.Contains(CharBuff.Brave))
                _blinkCooltime = UnityEngine.Random.Range(3f, 4f);
            else
                _blinkCooltime = UnityEngine.Random.Range(0.25f, 3f);

            if (_statusEffects.Contains(CharBuff.Tired))
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

        public void SetStatusToFX(List<CharBuff> _charStatusEffects)
        {
            foreach (KeyValuePair<CharBuff, GameObject> _statusObject in _statusObjectDic)
                _statusObject.Value.SetActive(false);

            foreach (CharBuff statusEffect in _charStatusEffects)
                _statusObjectDic[statusEffect].SetActive(true);


        }
    }
}

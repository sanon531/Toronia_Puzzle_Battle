using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;

namespace ToronPuzzle
{

    // 음량 조절도 해야한다.
    // 그리고 시작 할때 세이브, 로드 해서 해당 값이 저장 될 수 있도록 만들기.
    public class SoundManager : MonoBehaviour
    {

        [SerializeField]
        protected SFXEnumFloatDictionary _currentStatus = new SFXEnumFloatDictionary();

        [SerializeField]
        protected AudioSFXEnumDictionary _currentSoundManager = new AudioSFXEnumDictionary() { };
        [SerializeField]
        protected SFXAudioDictionary _currentSFXManager = new SFXAudioDictionary() { };

        [SerializeField]
        protected BGMAudioDictionary _currentBGMManager = new BGMAudioDictionary() { };



       

        public virtual void PlayBGM(BGMName name)
        {
            if(!_currentBGMManager[name].isPlaying)
                _currentBGMManager[name].Play();
        }
        public virtual void PlaySFX(SFXName name)
        {
            _currentSFXManager[name].Play();
        }
        public virtual void PlaySFX(SFXName name,float _delayedTime)
        {
            _currentSFXManager[name].Play();
        }

        IEnumerator DelayedPlay(AudioSource source, float delayedtime)
        {
            yield return new WaitForSecondsRealtime(delayedtime);
            source.Play();
        }


    }

}

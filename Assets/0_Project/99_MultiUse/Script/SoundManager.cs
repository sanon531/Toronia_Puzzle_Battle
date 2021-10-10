using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ToronPuzzle
{

    public enum SFXKind
    {
        All,
        BackGround,
        FX,
        Voice
    }
    public enum BGMName
    {
        Normal_Battle,

        Boss_Eojea
    }


    // ���� ������ �ؾ��Ѵ�.
    // �׸��� ���� �Ҷ� ���̺�, �ε� �ؼ� �ش� ���� ���� �� �� �ֵ��� �����.
    public class SoundManager : MonoBehaviour
    {
        [SerializeField]
        protected SFXEnumFloatDictionary _currentStatus = new SFXEnumFloatDictionary();

        [SerializeField]
        protected AudioSFXEnumDictionary _currentSoundManager = new AudioSFXEnumDictionary() { };
        [SerializeField]
        protected BGMAudioDictionary _currentAudioManager = new BGMAudioDictionary() { };


        public void BeginSoundManager() { }

        public void SetAudioByEnum(SFXKind _sfxKind,float _amount)
        {
            _currentStatus[_sfxKind] = _amount;
            foreach (KeyValuePair<AudioSource,SFXKind> _audiotarget  in _currentSoundManager)
            {
                _audiotarget.Key.volume = _currentStatus[SFXKind.All] * _currentStatus[_audiotarget.Value];
            }
        }

        public virtual void PlayBGM(BGMName name)
        {
            if(!_currentAudioManager[name].isPlaying)
                _currentAudioManager[name].Play();
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;

namespace ToronPuzzle.Battle
{
    public class Battle_SoundManager : SoundManager
    {
        public static Battle_SoundManager Instance;


        public void BeginSoundManager()
        {
            Instance = this;
        }
        public static void SetAudioByEnum(SoundKind _sfxKind, float _amount)
        {
            Instance._currentStatus[_sfxKind] = _amount;
            foreach (KeyValuePair<AudioSource, SoundKind> _audiotarget in Instance._currentSoundManager)
            {
                _audiotarget.Key.volume = Instance._currentStatus[SoundKind.All] * Instance._currentStatus[_audiotarget.Value];
            }
        }

        public override void PlayBGM(BGMName name)
        {
            base.PlayBGM(name);
        }
        public override void PlaySFX(SFXName name)
        {
            base.PlaySFX(name);
        }

    }
}
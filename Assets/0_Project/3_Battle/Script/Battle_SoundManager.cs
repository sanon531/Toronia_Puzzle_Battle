using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle.Battle
{
    public class Battle_SoundManager : SoundManager
    {
        public static Battle_SoundManager Instance;
        public override void PlayBGM(BGMName name)
        {
            if (!_currentAudioManager[name].isPlaying)
                _currentAudioManager[name].Play();
        }


    }
}
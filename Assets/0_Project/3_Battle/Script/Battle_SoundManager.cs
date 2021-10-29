using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
using UnityEngine.Audio;

namespace ToronPuzzle.Battle
{
    public class Battle_SoundManager : SoundManager
    {
        public static Battle_SoundManager Instance;


        public void BeginSoundManager()
        {
            Instance = this;
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
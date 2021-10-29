using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
using ToronPuzzle.Battle;
using UnityEngine.Audio;

namespace ToronPuzzle
{
    public class Global_SoundManager : SoundManager
    {
        public static Global_SoundManager Instance;
        public void BeginSoundManager()
        {
            //여기서 원래 데이터랑 대조해본 뒤 배경음을 깐다.  
            Instance = this;
            _masterMixer = Resources.Load("MasterMixer") as AudioMixer;
        }

        // 오디오 믹서 쓸꺼니까 버려두면됨




    }
}
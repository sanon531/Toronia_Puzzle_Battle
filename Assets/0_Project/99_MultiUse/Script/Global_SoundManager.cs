using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
using ToronPuzzle.Battle;
namespace ToronPuzzle
{
    public class Global_SoundManager : SoundManager
    {
        public static Global_SoundManager Instance;
        public void BeginSoundManager()
        {
            //여기서 원래 데이터랑 대조해본 뒤 배경음을 깐다.  
            Instance = this;
        }

        // 씬에서 사운드 데이터의 변동시 해당 다른 곳도 일괄 적용함
        public static void SetAudioByEnum(SoundKind _sfxKind, float _amount)
        {
            Instance._currentStatus[_sfxKind] = _amount;
            foreach (KeyValuePair<AudioSource, SoundKind> _audiotarget in Instance._currentSoundManager)
            {
                _audiotarget.Key.volume = Instance._currentStatus[SoundKind.All] * Instance._currentStatus[_audiotarget.Value];
            }

            if (Battle_SoundManager.Instance != null)
            {
                Battle_SoundManager.SetAudioByEnum(_sfxKind,_amount);
            }

        }
    }
}
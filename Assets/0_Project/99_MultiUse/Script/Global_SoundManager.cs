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
            //���⼭ ���� �����Ͷ� �����غ� �� ������� ���.  
            Instance = this;
        }

        // ������ ���� �������� ������ �ش� �ٸ� ���� �ϰ� ������
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
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
            //���⼭ ���� �����Ͷ� �����غ� �� ������� ���.  
            Instance = this;
            _masterMixer = Resources.Load("MasterMixer") as AudioMixer;
        }

        // ����� �ͼ� �����ϱ� �����θ��




    }
}
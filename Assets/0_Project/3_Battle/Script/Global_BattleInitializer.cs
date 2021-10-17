using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ToronPuzzle.Event;
using ToronPuzzle.Data;

namespace ToronPuzzle.Battle
{
    public class Global_BattleInitializer : MonoBehaviour
    {
        //��Ʋ���� ������ ���⼭ �Ѵٿ�
        [SerializeField]
        BGMName currentBG = BGMName.Normal_Battle;
     

        public void BattleBegin()
        {
            Master_Battle master_Battle = GameObject.Find("Master_Battle").GetComponent<Master_Battle>();
            master_Battle.BeginMasterData();
            Battle_ConveyerManager battle_ConveyerManager = GameObject.Find("Battle_ConveyerBelt").GetComponent<Battle_ConveyerManager>();
            battle_ConveyerManager.BeginConveyer();
            Battle_CameraAimer battle_CameraAimer = GameObject.Find("Battle_CameraAimer").GetComponent<Battle_CameraAimer>();
            battle_CameraAimer.BeginCameraAimer();
            Battle_SoundManager battle_SoundManager = GameObject.Find("Battle_SoundManager").GetComponent<Battle_SoundManager>();
            battle_SoundManager.BeginSoundManager();
            battle_SoundManager.PlayBGM(currentBG);

        }


        private void Start()
        {
            Global_InWorldEventSystem.CallOn��Ʋ����();
        }

    }

}

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
        //배틀사전 설정은 여기서 한다용
        [SerializeField]
        BGMName currentBGM = BGMName.Normal_Battle;
        [SerializeField]
        BGImageKind currentBGImage = BGImageKind.CYN_1;


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
            battle_SoundManager.PlayBGM(currentBGM);

            Battle_BackgroundPlacer battle_BackgroundPlacer = GameObject.Find("Battle_BackgroundPlacer").GetComponent<Battle_BackgroundPlacer>();
            battle_BackgroundPlacer.BeginBackgound(currentBGImage);

            Global_ToolTip global_ToolTip = GameObject.Find("Global_ToolTip").GetComponent<Global_ToolTip>();
            global_ToolTip.BeginGlobalTooltip();


            Global_InGameData.Instance.BegingModuleData();
        }


        private void Start()
        {
            Global_InWorldEventSystem.CallOn배틀시작();
        }

    }

}

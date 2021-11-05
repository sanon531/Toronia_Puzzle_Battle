using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ToronPuzzle.Event;
using ToronPuzzle.Data;
using ToronPuzzle.UI;

namespace ToronPuzzle.Battle
{
    public class Battle_Initializer : MonoBehaviour
    {
        //배틀사전 설정은 여기서 한다용
        [SerializeField]
        BGMName currentBGM = BGMName.Normal_Battle;
        [SerializeField]
        BGImageKind currentBGImage = BGImageKind.CYN_1;

        Canvas _battleCanvas;

        public void BattleBegin()
        {

            Battle_ConveyerManager battle_ConveyerManager = GameObject.Find("BC_ConveyingPlace").GetComponent<Battle_ConveyerManager>();
            battle_ConveyerManager.BeginConveyer();

            _battleCanvas = GameObject.Find("BattleCanvas").GetComponent<Canvas>();
            _battleCanvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

            Battle_CanvasUI battle_CanvasUI = _battleCanvas.gameObject.GetComponent<Battle_CanvasUI>();
            battle_CanvasUI.BeginUIManager();


            Battle_CameraAimer battle_CameraAimer = GameObject.Find("Battle_CameraAimer").GetComponent<Battle_CameraAimer>();
            battle_CameraAimer.BeginCameraAimer();

            Battle_SoundManager battle_SoundManager = GameObject.Find("Battle_SoundManager").GetComponent<Battle_SoundManager>();
            battle_SoundManager.BeginSoundManager();
            battle_SoundManager.PlayBGM(currentBGM);

            Battle_BackgroundPlacer battle_BackgroundPlacer = GameObject.Find("Battle_BackgroundPlacer").GetComponent<Battle_BackgroundPlacer>();
            battle_BackgroundPlacer.BeginBackgound(currentBGImage);

          
            Master_Battle master_Battle = GameObject.Find("Master_Battle").GetComponent<Master_Battle>();
            master_Battle.BeginMasterData();


            Global_CoroutineManager.Run(ShowBeginProcess());
            //모듈은 끝나고 재 설치된다.
        }

        IEnumerator ShowBeginProcess()
        {
            yield return null;
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_블록판보이기);
        }


    }

}

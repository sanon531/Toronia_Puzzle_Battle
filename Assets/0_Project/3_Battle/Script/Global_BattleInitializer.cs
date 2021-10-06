using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ToronPuzzle.Event;

namespace ToronPuzzle.Battle
{
    public class Global_BattleInitializer : MonoBehaviour
    {
        //배틀사전 설정은 여기서 한다용
        [SerializeField]
        Vector2Int SizeOfPannel = new Vector2Int(3, 6);

        [SerializeField]
        string _caseSkin = "PlacingCell";


        private void Awake()
        {
            GlobalBegin();

            if (SceneManager.GetActiveScene().name == "BattleScene")
                BattleBegin();
        }
        private void GlobalBegin()
        {
            Global_DragDropManager battle_DragDropManager = GameObject.Find("Global_DragDropManager").GetComponent<Global_DragDropManager>();
            battle_DragDropManager.BeginDragDrap();
            Global_BlockGenerator global_BlockGenerator = GameObject.Find("Global_BlockGenerator").GetComponent<Global_BlockGenerator>();
            global_BlockGenerator.BeginBlockGenerator();

        }

        private void BattleBegin()
        {
            Master_Battle master_Battle = GameObject.Find("Master_Battle").GetComponent<Master_Battle>();
            master_Battle.BeginMasterData();
            Master_BlockPlace master_BlockPlace = GameObject.Find("Master_BlockPlace").GetComponent<Master_BlockPlace>();
            master_BlockPlace.BeginBlockPlace(SizeOfPannel.x, SizeOfPannel.y, _caseSkin);
            Battle_ConveyerManager battle_ConveyerManager = GameObject.Find("Battle_ConveyerBelt").GetComponent<Battle_ConveyerManager>();
            battle_ConveyerManager.BeginConveyer();



            Battle_CameraAimer battle_CameraAimer = GameObject.Find("Battle_CameraAimer").GetComponent<Battle_CameraAimer>();
            battle_CameraAimer.BeginCameraAimer();



        }


        private void Start()
        {
            Global_InWorldEventSystem.CallOn배틀시작();
        }

    }

}

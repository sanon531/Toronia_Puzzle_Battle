using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Battle;
using UnityEngine.SceneManagement;
using ToronPuzzle.Event;

namespace ToronPuzzle
{
    public class Global_SceneInitializer : MonoBehaviour
    {
        [SerializeField]
        Global_BattleInitializer global_BattleInitializer;

        Global_CanvasData global_CanvasData;
        Global_SoundManager global_SoundManager;
        Global_InGameData global_InGameData;
        Global_FXPlayer global_FXPlayer;
        Global_DragDropManager global_DragDropManager;
        Global_BlockGenerator global_BlockGenerator;
        Global_BlockPlaceMaster global_BlockPlaceMaster;
        [SerializeField]
        string _caseSkin = "PlacingCell";
        [SerializeField]
        string _bonusSkin = "Bonus_Basic_";



        private void Awake()
        {
            GlobalBegin();
            //CheckScene();
            //씬이 넘어갈때 어느 씬이냐에 따라서 콜하는 초기화 코드가 달라짐 ㅇㅅㅇ
            SceneManager.activeSceneChanged += CheckScene;

        }
        private void GlobalBegin()
        {
            global_CanvasData = GameObject.Find("Global_Canvas").GetComponent<Global_CanvasData>();
            global_CanvasData.BeginCanvasData();
            global_SoundManager = GameObject.Find("Global_SoundManager").GetComponent<Global_SoundManager>();
            global_SoundManager.BeginSoundManager();
            global_FXPlayer = GameObject.Find("Global_FXPlayer").GetComponent<Global_FXPlayer>();
            global_FXPlayer.BeginFXPlayer();
            global_InGameData = GameObject.Find("Global_InGameData").GetComponent<Global_InGameData>();
            global_InGameData.BeginInGameData();
            global_DragDropManager = GameObject.Find("Global_DragDropManager").GetComponent<Global_DragDropManager>();
            global_DragDropManager.BeginDragDrap();

            global_BlockGenerator = GameObject.Find("Global_BlockGenerator").GetComponent<Global_BlockGenerator>();
            global_BlockGenerator.BeginBlockGenerator();
            SetBlockPlace();
        }

        // 제거한다음 새로 만드는 것.
        public void SetBlockPlace()
        {
            global_BlockPlaceMaster = GameObject.Find("Global_BlockPlaceMaster").GetComponent<Global_BlockPlaceMaster>();
            global_BlockPlaceMaster.BeginBlockPlace( _caseSkin, _bonusSkin);


        }

        private void CheckScene(Scene current, Scene next)
        {
            if (next.name == "BattleScene")
            {
                global_BattleInitializer.BattleBegin();
                global_DragDropManager.SetCurrentSceneData(BlockType.Block);
            }
            else if (next.name == "MapScene")
            {
                global_DragDropManager.SetCurrentSceneData(BlockType.Module);
            }
        }



    }
}

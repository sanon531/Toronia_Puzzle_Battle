using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Battle;
using ToronPuzzle.WorldMap;
using UnityEngine.SceneManagement;
using ToronPuzzle.Data;
using ToronPuzzle.UI;

namespace ToronPuzzle
{
    public class Global_SceneInitializer : MonoBehaviour
    {
        //글로벌 매니져
        #region
        Global_CanvasData global_CanvasData;
        Global_SoundManager global_SoundManager;
        Global_InGameData global_InGameData;
        Global_FXPlayer global_FXPlayer;
        Global_DragDropManager global_DragDropManager;
        Global_BlockGenerator global_BlockGenerator;
        Global_BlockPlaceMaster global_BlockPlaceMaster;
        Global_CoroutineManager global_CoroutineManager;
        Global_SceneManager global_SceneManager;
        Global_CanvasUI global_CanvasUI;
        #endregion
        //각 씬별 시작 생성자
        Battle_Initializer global_BattleInitializer;
        WorldMap_Initializer global_WorldMapInitializer;

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
            global_CanvasUI = global_CanvasData.gameObject.GetComponent<Global_CanvasUI>();
            global_CanvasUI.BeginUIManager();

            global_SoundManager = GameObject.Find("Global_SoundManager").GetComponent<Global_SoundManager>();
            global_SoundManager.BeginSoundManager();
            global_FXPlayer = GameObject.Find("Global_FXPlayer").GetComponent<Global_FXPlayer>();
            global_FXPlayer.BeginFXPlayer();
            global_InGameData = GameObject.Find("Global_InGameData").GetComponent<Global_InGameData>();
            global_InGameData.BeginInGameData();
            global_DragDropManager = GameObject.Find("Global_DragDropManager").GetComponent<Global_DragDropManager>();
            global_DragDropManager.BeginDragDrap();


            global_CoroutineManager = GameObject.Find("Global_GameManager").GetComponent<Global_CoroutineManager>();
            global_CoroutineManager.BeginCoroutineManager();
            global_SceneManager = global_CoroutineManager.gameObject.GetComponent<Global_SceneManager>();
            global_SceneManager.BeginSceneManager();

            global_BlockGenerator = GameObject.Find("Global_BlockGenerator").GetComponent<Global_BlockGenerator>();
            global_BlockGenerator.BeginBlockGenerator();
            SetBlockPlace();

        }


        // 제거한다음 새로 만드는 것.
        public void SetBlockPlace()
        {
            global_BlockPlaceMaster = GameObject.Find("Global_BlockPlaceMaster").GetComponent<Global_BlockPlaceMaster>();
            global_BlockPlaceMaster.BeginBlockPlace( _caseSkin, _bonusSkin);
            Global_InGameData.Instance.BegingModuleData();
        }

        private void CheckScene(Scene current, Scene next)
        {
            global_CanvasUI.BeginUIManager();
            if (next.name == "BattleScene")
            {
                global_BattleInitializer = GameObject.Find("Battle_Initializer").GetComponent<Battle_Initializer>();
                global_BattleInitializer.BattleBegin();
            }
            else if (next.name == "WorldMapScene")
            {
                global_WorldMapInitializer = GameObject.Find("WorldMap_Initializer").GetComponent<WorldMap_Initializer>();
                global_WorldMapInitializer.WorldMapBegin();
            }
            else if (next.name == "TitleScene")
            {

            }
            global_DragDropManager.SetCurrentSceneData(Global_SceneManager._currentScene);
            //Debug.Log(Global_SceneManager._currentScene);
        }



    }
}

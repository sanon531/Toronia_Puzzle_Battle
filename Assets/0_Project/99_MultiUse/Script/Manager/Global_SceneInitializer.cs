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
        [SerializeField]
        Vector2Int SizeOfPannel = new Vector2Int(3, 6);
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
            Global_CanvasData global_CanvasData = GameObject.Find("Global_Canvas").GetComponent<Global_CanvasData>();
            global_CanvasData.BeginCanvasData();
            Global_SoundManager global_SoundManager = GameObject.Find("Global_SoundManager").GetComponent<Global_SoundManager>();
            global_SoundManager.BeginSoundManager();
            Global_FXPlayer global_FXPlayer = GameObject.Find("Global_FXPlayer").GetComponent<Global_FXPlayer>();
            global_FXPlayer.BeginFXPlayer();
            Global_DragDropManager battle_DragDropManager = GameObject.Find("Global_DragDropManager").GetComponent<Global_DragDropManager>();
            battle_DragDropManager.BeginDragDrap();
            Global_BlockGenerator global_BlockGenerator = GameObject.Find("Global_BlockGenerator").GetComponent<Global_BlockGenerator>();
            global_BlockGenerator.BeginBlockGenerator();
            Global_BlockPlaceMaster global_BlockPlaceMaster = GameObject.Find("Global_BlockPlaceMaster").GetComponent<Global_BlockPlaceMaster>();
            global_BlockPlaceMaster.BeginBlockPlace(SizeOfPannel.x, SizeOfPannel.y, _caseSkin, _bonusSkin);


        }

        private void CheckScene()
        {
            if (SceneManager.GetActiveScene().name == "BattleScene")
                global_BattleInitializer.BattleBegin();

        }

        private void CheckScene(Scene current, Scene next)
        {
            if (next.name == "BattleScene")
            {
                global_BattleInitializer.BattleBegin();


            }
        }

    }
}

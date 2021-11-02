using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Battle;
using UnityEngine.SceneManagement;
using ToronPuzzle.Event;
using ToronPuzzle.UI;

namespace ToronPuzzle
{
    public class Global_SceneInitializer : MonoBehaviour
    {
        Battle_Initializer global_BattleInitializer;

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
        [SerializeField]
        string _caseSkin = "PlacingCell";
        [SerializeField]
        string _bonusSkin = "Bonus_Basic_";



        private void Awake()
        {
            GlobalBegin();
            //CheckScene();
            //���� �Ѿ�� ��� ���̳Ŀ� ���� ���ϴ� �ʱ�ȭ �ڵ尡 �޶��� ������
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

        // �����Ѵ��� ���� ����� ��.
        public void SetBlockPlace()
        {
            global_BlockPlaceMaster = GameObject.Find("Global_BlockPlaceMaster").GetComponent<Global_BlockPlaceMaster>();
            global_BlockPlaceMaster.BeginBlockPlace( _caseSkin, _bonusSkin);
            Global_InGameData.Instance.BegingModuleData();
        }

        private void CheckScene(Scene current, Scene next)
        {
            if (next.name == "BattleScene")
            {
                global_BattleInitializer = GameObject.Find("Battle_World").GetComponent<Battle_Initializer>();
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
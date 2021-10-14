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
        private void Awake()
        {
            GlobalBegin();
            CheckScene();
            //씬이 넘어갈때 어느 씬이냐에 따라서 콜하는 초기화 코드가 달라짐 ㅇㅅㅇ
            SceneManager.activeSceneChanged += CheckScene;

        }
        private void GlobalBegin()
        {
            Global_SoundManager global_SoundManager = GameObject.Find("Global_SoundManager").GetComponent<Global_SoundManager>();
            global_SoundManager.BeginSoundManager();
            Global_DragDropManager battle_DragDropManager = GameObject.Find("Global_DragDropManager").GetComponent<Global_DragDropManager>();
            battle_DragDropManager.BeginDragDrap();
            Global_BlockGenerator global_BlockGenerator = GameObject.Find("Global_BlockGenerator").GetComponent<Global_BlockGenerator>();
            global_BlockGenerator.BeginBlockGenerator();

        }

        private void CheckScene()
        {
            if (SceneManager.GetActiveScene().name == "BattleScene")
                global_BattleInitializer.BattleBegin();

        }

        private void CheckScene(Scene current, Scene next)
        {
            if (next.name == "BattleScene")
                global_BattleInitializer.BattleBegin();
        }

    }
}

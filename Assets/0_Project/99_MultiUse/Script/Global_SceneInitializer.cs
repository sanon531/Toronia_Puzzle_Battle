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
            //���� �Ѿ�� ��� ���̳Ŀ� ���� ���ϴ� �ʱ�ȭ �ڵ尡 �޶��� ������
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ToronPuzzle.Event;

namespace ToronPuzzle.Battle
{
    public class Global_BattleInitializer : MonoBehaviour
    {
        //��Ʋ���� ������ ���⼭ �Ѵٿ�
        [SerializeField]
        Vector2Int SizeOfPannel = new Vector2Int(3, 6);

        private void Awake()
        {
            if (SceneManager.GetActiveScene().name == "BattleScene")
                BattleBegin();
        }
        private void BattleBegin()
        {
            Master_Battle master_Battle = GameObject.Find("Master_Battle").GetComponent<Master_Battle>();
            master_Battle.BeginMasterData();
            Master_BlockPlace master_BlockPlace = GameObject.Find("Master_BlockPlace").GetComponent<Master_BlockPlace>();
            master_BlockPlace.BeginBlockPlace(SizeOfPannel.x, SizeOfPannel.y);




        }


        private void Start()
        {
            Global_InWorldEventSystem.CallOn��Ʋ����();
        }

    }

}

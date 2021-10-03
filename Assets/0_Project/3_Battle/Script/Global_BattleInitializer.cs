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
            Global_InWorldEventSystem.CallOn배틀시작();
        }

    }

}

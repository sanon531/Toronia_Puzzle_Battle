using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ToronPuzzle.Battle
{
    public class Battle_TestCaller : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => TestAction());
        }

        void TestAction()
        {
            Master_Battle.Data_OnlyInBattle._currentSequenece = GameSequence.WaitForStart;
            Master_Battle.Data_OnlyInBattle._currentTurn = 3;
            Master_Battle.Instance._isequenceChanged = true;


        }

    }


}


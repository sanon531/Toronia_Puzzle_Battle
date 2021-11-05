using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToronPuzzle.Event;
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
            Global_InWorldEventSystem.CallOn게임종료();

        }

    }


}


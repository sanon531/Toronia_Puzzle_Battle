using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ToronPuzzle.Battle
{
    public class Battle_ConveyerManager : MonoBehaviour
    {

        public static Battle_ConveyerManager instance;

        bool StartPlay, isPlaying = false;
        [SerializeField]
        List<GameObject> conveyerContainList;
        [SerializeField]
        RectTransform thisRect, TargetRect;


        public void BeginConveyer()
        {
            instance = this;


        }


        // Update is called once per frame
        void Update()
        {

        }

        public static void SetQueueOnConveyer()
        {

        }

        public static void GetLatestBloakQueue()
        {


        }


    }

}

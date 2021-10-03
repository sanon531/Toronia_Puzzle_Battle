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
        RectTransform thisRect, TargetRect;

        [SerializeField]
        Collider2D _spawnCollider, _resetCollider;
        [SerializeField]
        RectTransform _caseRect;
        float Rectwidth;


        public void BeginConveyer()
        {
            instance = this;
            thisRect = GetComponent<RectTransform>();


            _spawnCollider.enabled = false;
            _resetCollider.enabled = false;
            _resetCollider.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width * 0.35f, 0);

            Rectwidth = Screen.height * 0.1f;
            thisRect.anchoredPosition += new Vector2(0, Rectwidth * 0.5f);
            thisRect.sizeDelta = new Vector2(Screen.width,Rectwidth);
            _caseRect.sizeDelta= new Vector2(Rectwidth, Rectwidth);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Event;

namespace ToronPuzzle.Battle
{
    public class Battle_ConveyerManager : MonoBehaviour
    {

        public static Battle_ConveyerManager instance;

        bool StartPlay, isPlaying = false;
        [SerializeField]
        List<GameObject> conveyerContainList;
        RectTransform _currentRect, _beltRect;

        [SerializeField]
        Collider2D _spawnCollider, _resetCollider;
        [SerializeField]
        RectTransform _caseRect;
        float _rectwidth;


        public void BeginConveyer()
        {
            instance = this;
            _currentRect = GetComponent<RectTransform>();
            _beltRect = GameObject.Find("BC_ConveyerBelt").GetComponent<RectTransform>();
            _spawnCollider.enabled = false;
            _resetCollider.enabled = false;
            _resetCollider.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width * 0.35f, 0);

            _rectwidth = Screen.height * 0.1f;
            //_currentRect.anchoredPosition += new Vector2(0, _rectwidth * 0.5f);
            _currentRect.sizeDelta = new Vector2(0,_rectwidth);

            _caseRect.sizeDelta= new Vector2(_rectwidth, _rectwidth);
            Global_InWorldEventSystem.on토론시작 += StartConveyerMove;
            Global_InWorldEventSystem.on토론휴식 += StopInstantConveyerMove;
            Global_InWorldEventSystem.on게임종료 += StopInstantConveyerMove;
        }


        // Update is called once per frame

        public static void SetQueueOnConveyer()
        {

            
        }

        public static void GetLatestBloakQueue()
        {


        }


        Coroutine _AutoScrollCoroutine;
        void StartConveyerMove()
        {
            _AutoScrollCoroutine = Global_CoroutineManager.Run(AutoScroll());
        }
        void StopInstantConveyerMove()
        {
            if(_AutoScrollCoroutine !=null)
                Global_CoroutineManager.Stop(_AutoScrollCoroutine);
        }


        float _endTime,_spawnSpeed,_endLength;


        IEnumerator AutoScroll()
        {
            Vector2 _startPos = _beltRect.localPosition;

            yield return new WaitForSeconds(0.1f);
            _endTime = Master_Battle.Data_OnlyInBattle._battleTime;
            _spawnSpeed = Master_Battle.Data_OnlyInBattle._spawnSpeed;
            _endLength = _rectwidth*_endTime*_spawnSpeed;
            float t0 = 0.0f;
            while (t0 < 1.0f)
            {
                t0 += Time.deltaTime / _endTime;
                _beltRect.localPosition = new Vector2(Mathf.Lerp(_startPos.x, _startPos.x+ _endLength, t0), _startPos.y);
                yield return null;
            }

        }

    }

}

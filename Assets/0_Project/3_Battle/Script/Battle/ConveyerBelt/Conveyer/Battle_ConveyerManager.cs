using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Event;

namespace ToronPuzzle.Battle
{
    public class Battle_ConveyerManager : MonoBehaviour
    {
        //�ʱ�ȭ ����
        #region

        public static Battle_ConveyerManager instance;

        bool StartPlay, isPlaying = false;
        List<Battle_Conveyer_Case> conveyerContainList= new List<Battle_Conveyer_Case>();
        RectTransform _currentRect, _beltRect;

        BoxCollider2D _spawnCollider, _resetCollider;
        [SerializeField]
        RectTransform _caseRect;
        float _rectwidth;


        public void BeginConveyer()
        {
            instance = this;
            _currentRect = GetComponent<RectTransform>();
            _beltRect = GameObject.Find("BC_ConveyerBelt").GetComponent<RectTransform>();
            _spawnCollider = GameObject.Find("BC_ConveyerSpawnCollider").GetComponent<BoxCollider2D>();
            _resetCollider = GameObject.Find("BC_ConveyerResetCollider").GetComponent<BoxCollider2D>();

            _spawnCollider.enabled = false;
            _resetCollider.enabled = false;

            _rectwidth = Screen.height * 0.125f;
            _currentRect.anchoredPosition += new Vector2(0, _rectwidth * 0.5f);
            _currentRect.sizeDelta = new Vector2(0,_rectwidth);

            Vector2 _rectsize = new Vector2(_rectwidth, _rectwidth);
            _caseRect.sizeDelta = _rectsize;

            _spawnCollider.gameObject.GetComponent<Battle_CollisionReturn>().BeginCollisionReturn(_rectsize);
            _resetCollider.gameObject.GetComponent<Battle_CollisionReturn>().BeginCollisionReturn(_rectsize);


            Global_InWorldEventSystem.on��н��� += StartConveyerMove;
            Global_InWorldEventSystem.on����޽� += StopInstantConveyerMove;
            Global_InWorldEventSystem.on�������� += StopInstantConveyerMove;
        }


        // Update is called once per frame

        public static void SetQueueOnConveyer()
        {
        }

        public static void GetLatestBloakQueue()
        {

        }
        public void SetCaseOnConveyer(Battle_Conveyer_Case _Conveyer_Case){ conveyerContainList.Add(_Conveyer_Case); }

        #endregion


        //�� ��ġ ����
        [SerializeField]
        List<BlockInfo> _blockPlaceQueue = new List<BlockInfo>();
        public void SetBlockOnConveyer(Battle_Conveyer_Case _Conveyer_Case)
        {
        }
        public void DeleteBlockOnConveyer(Battle_Conveyer_Case _Conveyer_Case)
        {

        }




        //�����̾� �̵� ����
        #region
        Coroutine _AutoScrollCoroutine;
        void StartConveyerMove()
        {
            _spawnCollider.enabled = true;
            _resetCollider.enabled = true;

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
        #endregion



    }

}

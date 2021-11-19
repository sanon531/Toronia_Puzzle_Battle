using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Event;
using ToronPuzzle.UI;
using ToronPuzzle.Data;

namespace ToronPuzzle.Battle
{
    public class Battle_ConveyerManager : UI_Object,IGameListenerUI
    {
        //초기화 관련
        #region

        public static Battle_ConveyerManager instance;

        bool StartPlay, isPlaying = false;
        List<Battle_Conveyer_Case> conveyerContainList= new List<Battle_Conveyer_Case>();
        RectTransform _currentRect, _beltRect;
        BoxCollider2D _spawnCollider, _resetCollider;
        [SerializeField]
        RectTransform _caseRect;
        float _rectwidth;
        public void AssignGameListener()
        {
            instance = this;
            BeginConveyer();
            Global_InWorldEventSystem._on토론시작 += StartConveyerMove;
            Global_InWorldEventSystem._on토론휴식 += StopInstantConveyerMove;
            Global_InWorldEventSystem._on토론휴식 += ResetAllConveyer;
            Global_InWorldEventSystem._on게임종료 += StopInstantConveyerMove;



        }


        public void BeginConveyer()
        {
            _currentRect = GetComponent<RectTransform>();
            _beltRect = GameObject.Find("BC_ConveyerBelt").GetComponent<RectTransform>();
            _spawnCollider = GameObject.Find("BC_ConveyerSpawnCollider").GetComponent<BoxCollider2D>();
            _resetCollider = GameObject.Find("BC_ConveyerResetCollider").GetComponent<BoxCollider2D>();

            _spawnCollider.enabled = false;
            _resetCollider.enabled = false;

            _rectwidth = Screen.height * 0.125f;
            _currentRect.anchoredPosition += new Vector2(0, _rectwidth * 0.5f);
            _currentRect.sizeDelta = new Vector2(0, _rectwidth);

            //사이즈 정하는 부분
            Vector2 _rectsize = new Vector2(_rectwidth, _rectwidth);
            _caseRect.sizeDelta = _rectsize;
            _spawnCollider.gameObject.GetComponent<Battle_CollisionReturn>().BeginCollisionReturn(_rectsize);
            _resetCollider.gameObject.GetComponent<Battle_CollisionReturn>().BeginCollisionReturn(_rectsize);
        }

        // Update is called once per frame

        public void SetQueueOnConveyer(List<BlockInfo> _arg_Info)
        {
            _blockPlaceQueue = _arg_Info;

            foreach (BlockInfo blockInfo in _blockPlaceQueue)
            {
                blockInfo.SetArrByShape();
            }

        }

        public void SetCaseOnConveyer(Battle_Conveyer_Case _Conveyer_Case){ conveyerContainList.Add(_Conveyer_Case); }

        #endregion


        //블럭 배치 관련

        [SerializeField]
        List<BlockInfo> _blockPlaceQueue = new List<BlockInfo>();
        int _placeNum = 0;
        public void SetBlockOnConveyer(Battle_Conveyer_Case _Conveyer_Case)
        {
            //여기서 다시 켠다.
            BlockInfo _info = _blockPlaceQueue[_placeNum];

            if (_info._isLiftable)
                _Conveyer_Case.PlaceBlock(_blockPlaceQueue[_placeNum]);

            RandomAnim(_info._blockElement);
            _placeNum++;
            _placeNum =(_placeNum> (_blockPlaceQueue.Count-1))? 0: _placeNum;

        }
        public void DeleteBlockOnConveyer(Battle_Conveyer_Case _Conveyer_Case)
        {
            Global_DragDropManager.instance.ConveyerIsPickedOriginCase(_Conveyer_Case);
            _Conveyer_Case.DeleteBlock();
        }
        void ResetAllConveyer()
        {
            foreach (Battle_Conveyer_Case battle_Conveyer_Case in conveyerContainList)
                DeleteBlockOnConveyer(battle_Conveyer_Case);
        }

        void RandomAnim(BlockElement _blockElement)
        {

            //지금은 스피치지만 이후에 바꾼다.
            if (Random.Range(0, 10) < 5)
            {
                Global_InWorldEventSystem.CallOn플레이어애니메이션(_blockElement, CharAnimType.Speech);
                Global_InWorldEventSystem.CallOn카메라에임(CameraAimEnum.Aim_Player);
            }
            else
            {
                Global_InWorldEventSystem.CallOn적애니메이션(_blockElement, CharAnimType.Speech);
                Global_InWorldEventSystem.CallOn카메라에임(CameraAimEnum.Aim_Enemy);
            }

        }

        //블록의 수치에 따라서 에임의 정도가 변경된다
        void AimByAmount(CameraAimEnum _cameraAim)
        {
        }



        //컨베이어 이동 관련
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
using ToronPuzzle.Event;
using TMPro;
namespace ToronPuzzle.Battle
{
    public class Master_Battle : MonoBehaviour
    {
        public static class Data_OnlyInBattle
        {
            public static int _currentTurn = 0;
            public static bool _batletIsEnd = false;
            public static bool _canGetReward = true;
            public static bool _playerIsDead;
            public static GameSequence _currentSequenece = GameSequence.VeryFirstStart;
            public static Transform[] _alliesPos = default;
            public static Transform[] _enemiesPos = default;
            public static Transform[] _alliesHUDPos = default;
            public static Transform[] _enemiesHUDPos = default;
            public static Vector2 _cellsize = default;

            public static StageInfo _currentStageData;
            public static float _battleTime = 10f;
            public static float _spawnSpeed = 10f;


            public static bool IsDead { get; private set; }
            public static void SetDead() { IsDead = true; }
            public static void SetAlive() { IsDead = false; }

            public static void SetStageDataToinfo()
            {
                _battleTime = _currentStageData._battleTime;
                _spawnSpeed = _currentStageData._spawnSpeed;
            }

            public static void OwnTurnStart(bool is행동불능)
            {
                if (is행동불능)
                {
                    _currentTurn++;
                }
            }


        }

        public static Master_Battle Instance;

        protected CharacterID _characterID;
        public CharacterID characterID { get { return _characterID; } }
        [SerializeField] Canvas _vfxCanvas = default;
        [SerializeField] Transform[] _alliesPos = default;
        [SerializeField] Transform[] _enemiesPos = default;
        [SerializeField] Transform[] _alliesHUDPos = default;
        [SerializeField] Transform[] _enemiesHUDPos = default;



        public void BeginMasterData()
        {
            Debug.Log("_currentStageData" + StageDataPool.StageinfoDic["Basic"]._battleTime.ToString());

            Instance = this;
            //플레이어의 위치와 적의 위치를 가져온다.
            Data_OnlyInBattle._alliesPos = _alliesPos;
            Data_OnlyInBattle._enemiesPos = _enemiesPos;
            Data_OnlyInBattle._alliesHUDPos = _alliesHUDPos;
            Data_OnlyInBattle._enemiesHUDPos = _enemiesHUDPos;
            _isequenceChanged = true;
            Data_OnlyInBattle._currentStageData = Global_InGameData.Instance._currentStageData;
            Data_OnlyInBattle.SetStageDataToinfo();
            Global_InWorldEventSystem.on시퀀스넘기기 += ShiftSequence;
            SetBattleTimer();
        }

        public bool _isequenceChanged = false;

        float _currentBattleTimer;
        private void Update()
        {
            //시퀀스 변경시의 행동과 비변동시의 행동을측정 
            if (_isequenceChanged)
            {
                switch (Data_OnlyInBattle._currentSequenece)
                {
                    case GameSequence.VeryFirstStart:
                        Debug.Log("VeryFirstStart");
                        _currentBattleTimer = 0;
                        Global_CoroutineManager.InvokeDelay(ShiftSequence,1f);
                        break;
                    case GameSequence.WaitForStart:
                        Global_InWorldEventSystem.CallOn배틀시작();

                        Debug.Log("WaitForStart");
                        _currentBattleTimer = 0;
                        Global_UIEventSystem.Call_UIEvent<int>(UIEventID.Battle_현재턴표시, Data_OnlyInBattle._currentTurn);
                        break;
                    case GameSequence.BattleSequence:
                        Global_InWorldEventSystem.CallOn토론시작();
                        Debug.Log("BattleSequence");
                        break;
                    case GameSequence.BackToBegin:
                        Global_InWorldEventSystem.CallOn토론휴식();
                        Debug.Log("BackToBegin");
                        break;
                    case GameSequence.EndOfGame:
                        break;
                    default:
                        break;
                }

                _isequenceChanged = false;
            }
            else
            {
                //배틀 진행 시의 행동 
                if (Data_OnlyInBattle._currentSequenece == GameSequence.BattleSequence)
                    BattleTimeCount();
            }

        }

        void ShiftSequence()
        {
            Debug.Log("sequence Changed ");
            switch (Data_OnlyInBattle._currentSequenece)
            {
                case GameSequence.VeryFirstStart:
                    Data_OnlyInBattle._currentSequenece = GameSequence.WaitForStart;
                    break;
                case GameSequence.WaitForStart:
                    Data_OnlyInBattle._currentSequenece = GameSequence.BattleSequence;
                    break;
                case GameSequence.BattleSequence:
                    Data_OnlyInBattle._currentSequenece = GameSequence.BackToBegin;
                    break;
                case GameSequence.BackToBegin:
                    Data_OnlyInBattle._currentSequenece = GameSequence.WaitForStart;
                    break;
                case GameSequence.EndOfGame:
                    //GameDone
                    break;
                default:
                    break;
            }
            _isequenceChanged = true;

        }


        #region
        TextMeshProUGUI _timerText;

        void SetBattleTimer()
        {
            _timerText = GameObject.Find("BC_BattleTimer").GetComponent<TextMeshProUGUI>();
        }
        
        void BattleTimeCount()
        {
            if (Data_OnlyInBattle._battleTime > _currentBattleTimer)
                _currentBattleTimer += Time.deltaTime;
            else
                ShiftSequence();

            _timerText.SetText("Time : "+ Mathf.Round((Data_OnlyInBattle._battleTime - _currentBattleTimer)).ToString());
        }



        void CalcDamageOnChar()
        {
        }


        #endregion 


        //씬 나갈 때
        void ExitFunction()
        {
            Global_InWorldEventSystem.on시퀀스넘기기 -= ShiftSequence;

        }
    }

}


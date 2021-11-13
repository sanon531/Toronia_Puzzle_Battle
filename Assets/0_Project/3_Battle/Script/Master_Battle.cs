using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

            public static Data_Character _playerData, _enemyData;
            public static Battle_Character _playerChar, _enemyChar;

            public static Transform[] _alliesPos = default;
            public static Transform[] _enemiesPos = default;
            public static Vector2 _cellsize = default;

            public static StageInfo _currentStageData;
            public static float _battleTime = 10f;
            public static float _spawnSpeed = 10f;

            public static float _startCoolTime = 10f;
            public static float _battleCoolTime = 10f;



            public static bool IsDead { get; private set; }
            public static void SetDead() { IsDead = true; }
            public static void SetAlive() { IsDead = false; }

            public static void SetStageDataToinfo()
            {
                _battleTime = _currentStageData._battleTime;
                _spawnSpeed = _currentStageData._spawnSpeed;
                _startCoolTime = _currentStageData._startCoolTime;
                _battleCoolTime = _currentStageData._battleCoolTime;
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


        [SerializeField] Canvas _vfxCanvas = default;
        [SerializeField] Transform[] _alliesPos = default;
        [SerializeField] Transform[] _enemiesPos = default;
        public Data_Character _playerData, _enemyData;


        public void BeginMasterData()
        {
            //Debug.Log("_currentStageData" + StageDataPool.StageinfoDic["Basic"]._battleTime.ToString());
            Instance = this;
            #region
            //플레이어의 위치와 적의 위치를 가져온다.
            Data_OnlyInBattle._alliesPos = _alliesPos;
            Data_OnlyInBattle._enemiesPos = _enemiesPos;
            _isequenceChanged = true;
            Data_OnlyInBattle._playerChar = GameObject.Find("Player_Character").GetComponent<Battle_Character>();
            Data_OnlyInBattle._playerData = Data_OnlyInBattle._playerChar._characterData;
            Data_OnlyInBattle._enemyChar = GameObject.Find("Enemy_Character").GetComponent<Battle_Character>();
            Data_OnlyInBattle._enemyData = Data_OnlyInBattle._enemyChar._characterData;
            Data_OnlyInBattle._currentStageData = Global_InGameData.Instance._currentStageData;
            Data_OnlyInBattle.SetStageDataToinfo();

            #endregion
            Battle_ConveyerManager.instance.SetQueueOnConveyer(Global_InGameData.Instance._currentStageData._blockList);
            Global_InWorldEventSystem.on시퀀스넘기기 += ShiftSequence;

            SetBattleTimer();
            SetBlockPanelCalc();
        }

        private void Update()
        {
            //시퀀스 변경시의 행동과 비변동시의 행동을측정 
            if (_isequenceChanged)
            {
                switch (Data_OnlyInBattle._currentSequenece)
                {
                    case GameSequence.VeryFirstStart:
                        //Debug.Log("VeryFirstStart");
                        _currentBattleTimer = 0;
                        Global_UIEventSystem.Call_UIEvent<bool>(UIEventID.Battle_계산버튼OnOff, false);
                        Global_CoroutineManager.InvokeDelay(ShiftSequence, 1f);
                        break;
                    case GameSequence.WaitForStart:
                        //Debug.Log("WaitForStart");
                        _currentBattleTimer = 0;
                        Global_UIEventSystem.Call_UIEvent<int>(UIEventID.Battle_현재턴표시, Data_OnlyInBattle._currentTurn);
                        Global_UIEventSystem.Call_UIEvent<bool>(UIEventID.Battle_계산버튼OnOff, true);
                        break;
                    case GameSequence.BattleSequence:
                        Global_InWorldEventSystem.CallOn토론시작();
                        Global_UIEventSystem.Call_UIEvent<string>(UIEventID.Battle_현재시퀀스표시, "발언 시작!");
                        //Debug.Log("BattleSequence");
                        break;
                    case GameSequence.EnemyDamageCalc:
                        Global_InWorldEventSystem.CallOn토론휴식();
                        Data_OnlyInBattle._currentTurn++;
                        Global_UIEventSystem.Call_UIEvent<string>(UIEventID.Battle_현재시퀀스표시, "상대 발언!");
                        Global_UIEventSystem.Call_UIEvent<bool>(UIEventID.Battle_계산버튼OnOff, false);
                        //적의 행동이 완료 되었을 떄 발동 하는 방시으로 추후에 바꿀것 지금은 임시로 해둠
                        Global_CoroutineManager.InvokeDelay(ShiftSequence,2f);
                        //Debug.Log("BackToBegin");
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

        //시퀀스 관련
        #region
        public bool _isequenceChanged = false;
        float _currentBattleTimer;
        void ShiftSequence()
        {
            //Debug.Log("sequence Changed ");
            switch (Data_OnlyInBattle._currentSequenece)
            {
                case GameSequence.VeryFirstStart:
                    Data_OnlyInBattle._currentSequenece = GameSequence.WaitForStart;
                    Global_InWorldEventSystem.CallOn배틀시작();
                    break;
                case GameSequence.WaitForStart:
                    Data_OnlyInBattle._currentSequenece = GameSequence.BattleSequence;
                    break;
                case GameSequence.BattleSequence:
                    Data_OnlyInBattle._currentSequenece = GameSequence.EnemyDamageCalc;
                    break;
                case GameSequence.EnemyDamageCalc:
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


        #endregion

        //배틀 타이머 관련
        #region
        TextMeshProUGUI _timerText;
        Image _timerImage;

        void SetBattleTimer()
        {
            _timerText = GameObject.Find("BC_BattleTimer").GetComponent<TextMeshProUGUI>();
            _timerImage = GameObject.Find("BC_TimerGauge").GetComponent<Image>();
        }
        
        void BattleTimeCount()
        {
            if (Data_OnlyInBattle._battleTime > _currentBattleTimer)
                _currentBattleTimer += Time.deltaTime;
            else
                ShiftSequence();

            _timerText.SetText("Time : "+ Mathf.Round((Data_OnlyInBattle._battleTime - _currentBattleTimer)).ToString());
            _timerImage.fillAmount = (Data_OnlyInBattle._battleTime - _currentBattleTimer) / Data_OnlyInBattle._battleTime;
        }


        #endregion 

        //판 계산 관련.

        void SetBlockPanelCalc()
        {
            Global_InWorldEventSystem.on판계산 += SetDamageOnEnemy;
            Global_InWorldEventSystem.on판계산 += SetGuardOnPlayer;
        }

        void SetDamageOnEnemy(Data_Character 정보계산주체, Data_Character 부체, DataEntity 정보체)
        {

        }
        void SetGuardOnPlayer(Data_Character 정보계산주체, Data_Character 부체, DataEntity 정보체)
        {

        }




        //씬 나갈 때
        void ExitFunction()
        {
            Global_InWorldEventSystem.on시퀀스넘기기 -= ShiftSequence;

        }
    }

}


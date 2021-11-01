using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
using ToronPuzzle.Battle;

namespace ToronPuzzle
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

            public static bool IsDead { get; private set; }
            public static void SetDead() { IsDead = true; }
            public static void SetAlive() { IsDead = false; }

            public static int TurnCount { get; private set; }
            public static void OwnTurnStart(bool is행동불능)
            {
                if (is행동불능)
                {
                    TurnCount++;
                }
            }

        }

        protected CharacterID _characterID;
        public CharacterID characterID { get { return _characterID; } }
        [SerializeField] Canvas _vfxCanvas = default;
    
        [SerializeField] Transform[] _alliesPos = default;
        [SerializeField] Transform[] _enemiesPos = default;
        [SerializeField] Transform[] _alliesHUDPos = default;
        [SerializeField] Transform[] _enemiesHUDPos = default;


        public void BeginMasterData()
        {
            //플레이어의 위치와 적의 위치를 가져온다.
            Data_OnlyInBattle._alliesPos = _alliesPos;
            Data_OnlyInBattle._enemiesPos = _enemiesPos;
            Data_OnlyInBattle._alliesHUDPos = _alliesHUDPos;
            Data_OnlyInBattle._enemiesHUDPos = _enemiesHUDPos;
        }


        bool _isequenceChanged = false;

        private void Update()
        {
            if (_isequenceChanged)
            {
                switch (Data_OnlyInBattle._currentSequenece)
                {
                    case GameSequence.VeryFirstStart:
                        
                        break;
                    case GameSequence.WaitForStart:

                        break;
                    case GameSequence.BattleSequence:

                        break;
                    case GameSequence.CalcDamage:

                        break;
                    case GameSequence.BackToBegin:

                        break;
                    case GameSequence.EndOfGame:

                        break;
                    default:
                        break;
                }



            }


        }


    }

}


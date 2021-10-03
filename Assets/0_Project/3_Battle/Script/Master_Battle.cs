using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;

namespace ToronPuzzle
{
    public class Master_Battle : MonoBehaviour
    {
        private static class Data_OnlyInBattle
        {

            public static int _currentTurn = 0;
            public static bool _batletIsEnd = false;
            public static bool _canGetReward = true;
            public static bool _playerIsDead;


            public static Transform[] _alliesPos = default;
            public static Transform[] _enemiesPos = default;

            public static Transform[] _alliesHUDPos = default;
            public static Transform[] _enemiesHUDPos = default;

            public static Data_Character _focusedCharacter;

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

        public static class CanvasData
        {
            public static Vector2 LDAchorPos=default;
            public static Vector2 RUAchorPos = default;
            public static Vector2 _screenWorldSize = default;
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
            CanvasData.LDAchorPos = GameObject.Find("LDAnchor").transform.position;
            CanvasData.RUAchorPos = GameObject.Find("RUAnchor").transform.position;
            CanvasData._screenWorldSize = CanvasData.RUAchorPos - CanvasData.LDAchorPos ;

            //플레이어의 위치와 적의 위치를 가져온다.
            Data_OnlyInBattle._alliesPos = _alliesPos;
            Data_OnlyInBattle._enemiesPos = _enemiesPos;
            Data_OnlyInBattle._alliesHUDPos = _alliesHUDPos;
            Data_OnlyInBattle._enemiesHUDPos = _enemiesHUDPos;
        }


        void Awake()
        {
        }

        void Start()
        {

        }

        void Update()
        {




        }
    }

}


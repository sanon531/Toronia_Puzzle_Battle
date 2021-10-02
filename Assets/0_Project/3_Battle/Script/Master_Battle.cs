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

        protected CharacterID _characterID;
        public CharacterID characterID { get { return _characterID; } }
        [SerializeField] Canvas _vfxCanvas = default;
    
        [SerializeField] Transform[] _alliesPos = default;
        [SerializeField] Transform[] _enemiesPos = default;

        [SerializeField] Transform[] _alliesHUDPos = default;
        [SerializeField] Transform[] _enemiesHUDPos = default;

        void Awake()
        {
            //RegisterCurrentScene(SceneType.Combat);
            //Global_VfxPool.instance.OnEnterNewScene(_vfxCanvas);
            Data_OnlyInBattle._alliesPos = _alliesPos;
            Data_OnlyInBattle._enemiesPos = _enemiesPos;
            Data_OnlyInBattle._alliesHUDPos = _alliesHUDPos;
            Data_OnlyInBattle._enemiesHUDPos = _enemiesHUDPos;

        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}


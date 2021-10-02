using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;

namespace ToronPuzzle
{
    public class Master_Battle : MonoBehaviour
    {
       
        public struct Data_OnlyInBattle
        {

            public bool IsDead { get; private set; }
            public void SetDead() { IsDead = true; }
            public void SetAlive() { IsDead = false; }

            public int TurnCount { get; private set; }
            public void OwnTurnStart(bool is행동불능)
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

        [SerializeField] Transform _backCharPos = default;

        [SerializeField] Transform _skullKeyPos = default;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}


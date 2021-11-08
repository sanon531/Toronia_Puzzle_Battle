using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
using ToronPuzzle.Event;

namespace ToronPuzzle
{
    public enum CharacterSide
    {
        Ally = 0,       // 아군 (전투 시, 왼쪽에 서있음)
        Enemy = 1,      // 적군 (전투 시, 오른쪽에 서있음)
        Nuetral = 2,    // 중립 (전투 시, 전장 바깥에 서있음)
    }

    [System.Serializable]
    public partial class Data_Character
    {
        protected struct Data_CombatProgress
        {


        }


        public bool IsDead { get; private set; }
        public void SetDead() { IsDead = true; }
        public void SetAlive() { IsDead = false; }

        public CharacterID characterID;
        public CharacterSide 소속진영 ;
        public CharacterSide 상대진영
        {
            get
            {
                if (소속진영 == CharacterSide.Ally) { return CharacterSide.Enemy; }
                if (소속진영 == CharacterSide.Enemy) { return CharacterSide.Ally; }
                return CharacterSide.Nuetral;
            }
        }

        public int 최대생명력_Default = 100;
        public int 최대생명력
        {
            get
            {
                DataEntity 최대생명력data = DataEntity.고유데이터(최대생명력_Default);
                Global_InWorldEventSystem.CallOnCalc최대생명력(this, 최대생명력data);
                return 최대생명력data.FinalValue;
            }
        }

        public int 현재생명력;
        public int 현재방어도;





    }
}

namespace ToronPuzzle.Data
{
    public enum CharSide
    {
        Ally,
        Enemy
    }
    // 턴수가 지남에따라 감소하는 상태이상과 아닌 상태이상으로 나뉨 
    // 해당하는 상태에 따라 이펙트가 달라짐 
    public enum CharStatusEffect
    {
        //합리 포인트 절반일때
        Tired = 0,
        //방어력감소
        Confused = 1,
        //공격력 감소
        Depressed = 2,
        //방어력 증가 감소랑 중첩 불가
        Concentrate = 3,
        //공격력 증가 감소랑 중첩 불가
        Boasted = 4,
        Surprised = 5,
        Rage,
        Compassion,
        Horror,
        Brave,
        //독뎀
        Painful,
        //회복
        Relaxed


    }

    public enum CharAction
    {
        Idle,
        Agr_1,
        Agr_2,
        Agr_Skill_1,
        Cyn_1,
        Cyn_2,
        Cyn_Skill_1,
        Frn_1,
        Frn_2,
        Frn_Skill_1,
        Damaged,
        Dead

    }


}

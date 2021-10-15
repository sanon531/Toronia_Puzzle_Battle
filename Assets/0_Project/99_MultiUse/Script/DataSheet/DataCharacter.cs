using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;

namespace ToronPuzzle
{

    public partial class Data_Character
    {
        protected struct Data_CombatProgress
        {


        }

        protected CharacterID _characterID;



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

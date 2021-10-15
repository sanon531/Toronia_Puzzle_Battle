using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;

namespace ToronPuzzle
{
    public enum CharSide
    {
        Ally,        
        Enemy 
    }
    // �ϼ��� ���������� �����ϴ� �����̻�� �ƴ� �����̻����� ���� 
    // �ش��ϴ� ���¿� ���� ����Ʈ�� �޶��� 
    public enum CharStatusEffects
    {
        //�ո� ����Ʈ �����϶�
        Tired = 0,
        //���°���
        Confused = 1,
        //���ݷ� ����
        Depressed = 2,
        //���� ���� ���Ҷ� ��ø �Ұ�
        Concentrate = 3,
        //���ݷ� ���� ���Ҷ� ��ø �Ұ�
        Boasted = 4,
        Surprised = 5,
        Rage,
        Compassion,
        Horror,
        //����
        Painful,
        //ȸ��
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

    public partial class Data_Character
    {
        protected struct Data_CombatProgress
        {


        }

        protected CharacterID _characterID;



    }
}

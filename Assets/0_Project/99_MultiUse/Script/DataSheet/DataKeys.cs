using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle.Data
{
    public enum CharacterID
    {
        //플레이어는 1 적은 다양한 바리에이션이 있다.
        플레이어 = 1,

        멸고단원 = 2


    }

    public enum ModuleID
    {
        //디폴트 값 
        없음=0,
        불길한_공허 = 0,

        //일반 모듈
        카리스마Lv1 = 1,
        분석력Lv1 = 2,
        따뜻함Lv1 = 3,
        정의감Lv1 = 4,//흡혈
        경멸감Lv1 = 5,//방어 공격
        책임감Lv1 = 6, //회복
        천방지축 = 7,

        //희귀 유물
        카리스마Lv2 = 21,
        분석력Lv2 = 22,
        따뜻함Lv2 = 23,
        정의감Lv2 = 24,
        경멸감Lv2 = 25,
        책임감Lv2 = 26,
        기선제압 = 28,
        궤변_파쇄기,
        진실_천명,

        //유니크
        빙점,
        경칩,
        개미지옥,


        //부정행위 - 패널티도 있지만 나름 쓸모있도록 할것.
        
        과도한_자기비하,
        양자역학적_결론,
        과도한_확대해석,
        부조리한_연막,
        억지강요,
        함정투성이전제,
        흑백논리,
        꼬리무는_순환논증,
        성급한_일반화,
        추잡한_인신공격,
        공허한_지껄임,
        주제돌리기,
        반이성적_권위



    }
    public enum EffectID
    {
        공격력 = 0,
        방어력 = 1,



    }
}
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
        불길한_공허=0,
        
        //일반 모듈
        희미한_카ㅉ리스마 =1,
        희미한_분석력 = 2,
        희미한_따뜻함 = 3,
        투박한_정의감 = 4,//흡혈
        투박한_경멸감 = 5,//방어 공격
        투박한_책임감 = 6, //회복
        엇나감 = 7,

        //희귀 유물
        적당한_카리스마 = 21,
        적당한_분석력 = 22,
        적당한_따뜻함 = 23,
        정립된_정의감 = 24,
        정립된_경멸감 = 25,
        정립된_책임감 = 26,
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
        이성이상의_권위



    }
    public enum EffectID
    {
        공격력 = 0,
        방어력 = 1,



    }
}
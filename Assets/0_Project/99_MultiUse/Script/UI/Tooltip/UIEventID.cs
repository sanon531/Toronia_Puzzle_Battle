using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ToronPuzzle.Event
{

    public enum UIEventID
    {
        Global_씬이동,




        Global_입력차단,
        Global_입력차단해제,

        Global_네트워크대기,
        Global_네트워크대기해제,
        Global_블록판숨기기,
        Global_블록판보이기,
        Global_암전,
        Global_암전해제,
        Global_암전즉시해제,
        Global_일정시간동안암전,
        Global_계산표시,
        Global_계산툴팁,
        Global_블럭집은후UI,
        Global_블럭놓은후UI,
        Global_모듈회전불가,

        
        WorldMap_오브젝트_실행,
        WorldMap_인벤토리숨기기,
        WorldMap_인벤토리보이기,
        WorldMap_맵오브젝트정보보이기,
        WorldMap_맵오브젝트정보숨기기,


        Battle_게임시작표시,
        Battle_계산버튼OnOff,
        Battle_플레이어방어도표시,
        Battle_적방어도표시,
         
        Battle_시퀀스넘기기,
        Battle_현재턴표시,
        Battle_현재시퀀스표시

    }

}

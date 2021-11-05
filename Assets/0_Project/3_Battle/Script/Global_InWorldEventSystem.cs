using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Battle;

namespace ToronPuzzle.Event
{
    public delegate void On이벤트();

    public delegate void OnCalc데이터_0형식(DataEntity 정보체);
    public delegate void OnCalc데이터_1형식(Data_Character 대상, DataEntity 정보체);
    public delegate void OnCalc데이터_2형식(Data_Character 정보계산주체, Data_Character 부체, DataEntity 정보체);
    //블록에 의한 이벤트임
    public delegate void On모듈이벤트(BlockInfo 블록정보);
    public delegate void On배틀이벤트();

    public delegate void On휴식회복(DataEntity 정보체);
    public delegate void On이벤트With정수수치값(int 수치값);
    public delegate void On이벤트WithFloat수치값(float 수치값);

    public delegate void On이벤트With대상수치값(Data_Character 대상자, int 수치값);


    public static class Global_InWorldEventSystem 
    {
        //맵
        public static event On이벤트 on맵입장;
        public static void CallOn맵입장() { on맵입장?.Invoke(); }

        public static event On이벤트 on노드선택;
        public static void CallOn노드선택() { on노드선택?.Invoke(); }
        public static event On이벤트 on노드로드완료;
        public static void CallOn노드로드완료() { on노드로드완료?.Invoke(); }


        //배틀 중 이벤트 
        public static event On이벤트 onTouchMain;
        public static void CallOnTouchMain() { onTouchMain?.Invoke(); }


        public static event On이벤트 on배틀시작;
        public static void CallOn배틀시작() { on배틀시작?.Invoke(); }

        public static event On이벤트 on판생성;
        public static void CallOn판생성() { on판생성?.Invoke(); }


        public static event On이벤트 on모듈생성;
        public static void CallOn모듈생성() { on모듈생성?.Invoke(); }

        public static event On모듈이벤트 on블록배치;
        public static void CallOn블록배치(BlockInfo module) { on블록배치?.Invoke(module); }


        public static event On이벤트WithFloat수치값 on계산쿨타임변동;
        public static void CallOn계산쿨타임변동(float _changeVal) { on계산쿨타임변동?.Invoke(_changeVal); }

        //계산(발언)을 할때 활용 할것. 계산 직전은 계산 하기 전에 발동
        public static event On이벤트 on계산직전;
        public static void CallOn계산직전() { on계산직전?.Invoke(); }
        public static event On이벤트 on판계산;
        public static void CallOn판계산() { on판계산?.Invoke(); }

        public static event On이벤트 on시퀀스넘기기;
        public static void CallOn시퀀스넘기기() { on시퀀스넘기기?.Invoke(); }



    }


}

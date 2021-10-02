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

    public delegate void On모듈이벤트(Module module);
    public delegate void On배틀이벤트();

    public delegate void On휴식회복(DataEntity 정보체);
    public delegate void On이벤트With수치값(int 수치값);
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
        public static event On이벤트 on최초시작;
        public static void CallOn최초시작() { on최초시작?.Invoke(); }

        public static event On이벤트 on판생성;
        public static void CallOn판생성() { on판생성?.Invoke(); }

        public static event On이벤트 on블록배치;
        public static void CallOn블록배치() { on블록배치?.Invoke(); }


        public static event On이벤트 on계산직전;
        public static void CallOn계산직전() { on계산직전?.Invoke(); }
        public static event On이벤트 on판계산;
        public static void CallOn판계산() { on판계산?.Invoke(); }


    }


}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    public class DataEntity
    {
        public void Add증가량(int amount) { _증가량 += amount; }
        public void Add증가량배수(float amount) { _증가량배수 *= amount; }
        public void Add배수(float amount) { _배수 *= amount; }
        public void Add추가량(int amount) { _추가량 += amount; }
        //수치 DataEntity일경우에만 사용.
        private int _기본값 = 0;
        private int _증가량 = 0;
        private float _증가량배수 = 1f;  //증가량에만 곱한다. (공격력 계수 등에 사용)
        private float _배수 = 1f;        //기본값에 증가량이 더해진 값에 곱한다.
        private int _추가량 = 0;         //나머지 계산이 다 완료 된 후, 값을 추가한다.
        public int FinalValue { get { return (int)((_기본값 + _증가량 * _증가량배수) * _배수) + _추가량; } }



    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    public class DataEntity
    {
        public void Add������(int amount) { _������ += amount; }
        public void Add���������(float amount) { _��������� *= amount; }
        public void Add���(float amount) { _��� *= amount; }
        public void Add�߰���(int amount) { _�߰��� += amount; }
        //��ġ DataEntity�ϰ�쿡�� ���.
        private int _�⺻�� = 0;
        private int _������ = 0;
        private float _��������� = 1f;  //���������� ���Ѵ�. (���ݷ� ��� � ���)
        private float _��� = 1f;        //�⺻���� �������� ������ ���� ���Ѵ�.
        private int _�߰��� = 0;         //������ ����� �� �Ϸ� �� ��, ���� �߰��Ѵ�.
        public int FinalValue { get { return (int)((_�⺻�� + _������ * _���������) * _���) + _�߰���; } }



    }
}

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


        private int _�⺻�� = 0;
        private int _������ = 0;
        private float _��������� = 1f;  //���������� ���Ѵ�. (���ݷ� ��� � ���)
        private float _��� = 1f;        //�⺻���� �������� ������ ���� ���Ѵ�.
        private int _�߰��� = 0;         //������ ����� �� �Ϸ� �� ��, ���� �߰��Ѵ�.
        public int FinalValue { get { return (int)((_�⺻�� + _������ * _���������) * _���) + _�߰���; } }


        public Property properties { get; private set; }

        public void AddProperty(Property property){ properties |= property;}

        public Type type { get; }






        public enum Type
        {
            ���� = 0,

            ���ط� = 1,
            ȸ���� = 2,
            �� = 3,
            ������������� = 4,   //���س� ȸ���� �ƴ� ������� N���� ����ϴ� ���� ȿ��.
                           //���س� ȸ�������� �̺�Ʈ�� �߻���Ű�� �ʴ´�.
            ���������� = 5,   //�� ȹ���̳� �Ҹ𰡾ƴ�.
                           //��ǥ������ �� ���۽� �� �ʱ�ȭ�ɶ� ���.

            �̵� = 6,

            SP���� = 7,
            AP���� = 8,
            ��º��� = 9,
            ����ġ = 10,

            ȿ���ο� = 11,
            ȿ��ȸ�� = 12,
            ȿ������ = 13,

            �Ҹ�ǰȹ�� = 20,

            ������ġ���� = 100,
            ��ȭ��ġ���� = 101,
        }
        public enum Property
        {
            None = 0,
            ������ = 1, //���ط��϶��� ���
            ������ġ = 2,   //�ٸ�ȿ���κ��� �����Ǵ� ������ ��������
                        //����Ƽ �����ÿ�, ���������� ��ġ�� �׻� ���� (�������� ���ܻ�Ȳ�� �������� 0���ιٲ�)
            ũ��Ƽ�� = 4,
            �ݰݹ��� = 8,

            //->�����÷���
            ���ε����� = 16,


            ȿ���鿪�� = 32, //�鿪 �ؽ�Ʈ ���� ����

            �������ü = 64, //����� ȿ�� ���� ����

            ������������ = 128, //��ũ�ι�ƽ���� ���� ���� �ʴ� ���� ���� ������ ��� ���
        }

        private DataEntity(Type type, int �⺻��)
        {
            this.type = type;
            _�⺻�� = �⺻��;
        }
        private DataEntity(Type type, int �⺻��, Property properties)
        {
            this.type = type;
            _�⺻�� = �⺻��;
            this.properties = properties;
        }


        public static DataEntity ����������(int �⺻��)
        {
            return new DataEntity(Type.����, �⺻��);
        }

    }
}

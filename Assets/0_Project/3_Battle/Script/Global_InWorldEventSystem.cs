using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Battle;

namespace ToronPuzzle.Event
{
    public delegate void On�̺�Ʈ();

    public delegate void OnCalc������_0����(DataEntity ����ü);
    public delegate void OnCalc������_1����(Data_Character ���, DataEntity ����ü);
    public delegate void OnCalc������_2����(Data_Character ���������ü, Data_Character ��ü, DataEntity ����ü);

    public delegate void On����̺�Ʈ(Module module);
    public delegate void On��Ʋ�̺�Ʈ();

    public delegate void On�޽�ȸ��(DataEntity ����ü);
    public delegate void On�̺�ƮWith��ġ��(int ��ġ��);
    public delegate void On�̺�ƮWith����ġ��(Data_Character �����, int ��ġ��);


    public static class Global_InWorldEventSystem 
    {
        //��
        public static event On�̺�Ʈ on������;
        public static void CallOn������() { on������?.Invoke(); }

        public static event On�̺�Ʈ on��弱��;
        public static void CallOn��弱��() { on��弱��?.Invoke(); }
        public static event On�̺�Ʈ on���ε�Ϸ�;
        public static void CallOn���ε�Ϸ�() { on���ε�Ϸ�?.Invoke(); }


        //��Ʋ �� �̺�Ʈ 
        public static event On�̺�Ʈ onTouchMain;
        public static void CallOnTouchMain() { onTouchMain?.Invoke(); }


        public static event On�̺�Ʈ on��Ʋ����;
        public static void CallOn��Ʋ����() { on��Ʋ����?.Invoke(); }

        public static event On�̺�Ʈ on�ǻ���;
        public static void CallOn�ǻ���() { on�ǻ���?.Invoke(); }

        public static event On�̺�Ʈ on��Ϲ�ġ;
        public static void CallOn��Ϲ�ġ() { on��Ϲ�ġ?.Invoke(); }


        public static event On�̺�Ʈ on�������;
        public static void CallOn�������() { on�������?.Invoke(); }
        public static event On�̺�Ʈ on�ǰ��;
        public static void CallOn�ǰ��() { on�ǰ��?.Invoke(); }


    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle.Data
{

    static class ModuleDic
    {
        public static Dictionary<ModuleID, Module_DataTable> ModuleTableDic
        = new Dictionary<ModuleID, Module_DataTable>()
        {
            {ModuleID.�⼱����,new Module_DataTable()}

        };

        //�̷� ������ ����� �����͸� ����� �����Ѵ�. ��⿡ ���� ��ġ�� ���⼭ ��.
        public static Dictionary<ModuleID, BlockInfo> _IDModuleBlockDic =
            new Dictionary<ModuleID, BlockInfo>()
            {
                { ModuleID.�⼱����,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.One_D_���,new Module_ActBegin(), ModuleID.�⼱����,1)},
                { ModuleID.ī������Lv1,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.Three_G_���,new Module_�������_����_��(), ModuleID.ī������Lv1,4)},
                { ModuleID.�м���Lv1,
                    new BlockInfo(BlockElement.Cynical,BlockShape.Three_G_���,new Module_�üҾ���_���_��(), ModuleID.�м���Lv1,4)},
                { ModuleID.å�Ӱ�Lv1,
                    new BlockInfo(BlockElement.Friendly,BlockShape.Three_G_���,new Module_��ȣ����_����_��(),ModuleID.å�Ӱ�Lv1,4)},
                { ModuleID.���,
                    new BlockInfo(BlockElement.Cynical,BlockShape.Three_G_���,new Module_���(), ModuleID.���,3)},
                { ModuleID.������_�ӱ�����,
                    new BlockInfo(BlockElement.Friendly,BlockShape.Two_VL_���,new Module_�������ӱ�����(), ModuleID.������_�ӱ�����,6)},
                { ModuleID.�������� ,
                    new BlockInfo(BlockElement.Friendly,BlockShape.Four_AG_��������,new Module_��������(), ModuleID.��������,6)},

                { ModuleID.��ȭ,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.Three_G_���,new Module_��ȭ(), ModuleID.��ȭ,6)},
                { ModuleID.�浿 ,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.One_D_���,new Module_ActBegin(), ModuleID.�浿,1)},
                { ModuleID.���� ,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.One_D_���,new Module_ActBegin(), ModuleID.����,1)},


            };

        public static Dictionary<ModuleID,ModuleInfo > _IDModuleDic =
          new Dictionary<ModuleID, ModuleInfo>()
          {
                { ModuleID.�⼱����,
                    new Module_ActBegin()},
                { ModuleID.ī������Lv1,
                    new Module_�������_����_��()},
                { ModuleID.�м���Lv1,
                    new Module_�üҾ���_���_��()},
                { ModuleID.å�Ӱ�Lv1,
                    new Module_��ȣ����_����_��()},
                { ModuleID.���,
                    new Module_���()},
                { ModuleID.������_�ӱ�����,
                    new Module_�������ӱ�����()},
                { ModuleID.�������� ,
                  new Module_��������() },
                { ModuleID.��ȭ ,
                  new Module_��ȭ() },
                { ModuleID.�浿 ,
                  new Module_ActBegin() },
                { ModuleID.���� ,
                  new Module_ActBegin() },


          };


        public static Dictionary<ModuleID, string> _module_devcomment = new Dictionary<ModuleID, string>()
            {

                //�⼱����
                {ModuleID.�⼱����,
                    "������ ���̶� ���� �����̴�. �����ؾ� 1% ����? \n" +
                    "�׷��� ������ ó�� �Ҿ�� �������� �����̶�� ���� 90%�� \n" +
                    "�ѱ��� �ʰڴ°�? \n" +
                    " - �ѵ��� �̴��� ���Ͽ�" },


                //ī������
                {ModuleID.ī������Lv1,
                    "������� ���� ���������, \n" +
                    "������ �̿��� <red>�������</red> ������ ���� \n" +
                    " - �ѵ��� �̴��� ���Ͽ�" },
                { ModuleID.ī������Lv2,
                    "���� ���̴� ���� �����ϰ� ������ �θ��� �������� \n" +
                    "��°�� �� ��� ���ú��ٵ� ���� ������ ��� ���°ɱ�." },

                //�м���
                {ModuleID.�м���Lv1,
                    "�̼��� ����� �⺻�� �� �̾߱⸦ ������� \n" +
                    "������ ���س��� ���� ���� �����ϴ� �Ϳ� �ִ�. \n" +
                    " - ������ ���� 1�� ����" },
                //å�Ӱ�
                {ModuleID.å�Ӱ�Lv1,
                    "å�Ӱ��� �Ǹ��� ������ ���踦 �������� ���� ���� ���̷δ� .\n" +
                    " - �������� 3�� 14��" },
                //���
                {ModuleID.���,
                    "���� ���̵� ������ ����ϸ� \n" +
                    "�¾絵 �ͷ��� ���� ���ڷ� �̷�� ����. \n"+
                    "ũ�⿡ �е��Ǿ��� ���� �װ��� <blue>��ü</blue>�϶�. \n" +
                    "<blue>��</blue>�� ���� ������ �޽������� \n" +
                    " - <blue>���� �Ƹ���,�ı� ������ p.42</blue>"},

                //���ں�
                {ModuleID.���ں�,
                    "�������� ������ �մ´ٶ� \n" +
                    "������ ������ �ٲ�ٸ� ������ ������ �ʰڳ�?\n" +
                    " - <blue> ���� ������ ���Ͽ� - �ı��� ĭ</blue>"},

                //������ �ӱ�����
                { ModuleID.������_�ӱ�����,
                    "��ī�ο� Į�� ���� �� �߶󳻰� �ٴ����� ��õ�� ���ž�������\n" +
                    "��ġ �Ź��� �װ�ó�� ���� �ϳ� ���� ���ϱ���. \n" +
                    " - õ�ϸ�����, �츣 ���Ƿ罺�� ���� ��" },
                //��������
                { ModuleID.��������,
                    "�̰��� ������ �ߴٸ� �̹� ���̰� �� ���̰� \n" +
                    "���̰Ե� ���� �̹� �߹��� ĥ ���� ���� ���̴�\n" +
                    " - ���ݵ� ��ä���� ���ÿ��� " },
                //��ȭ
                { ModuleID.��ȭ,
                    "�ƹ��� ��õ�� ������ <blue>ö</blue>������ �ܴ��� ���̾��� <yellow>��</yellow>������ \n" +
                    "<red>�¾� ��</red>�� �׳ฦ �콽�̰� �׸� ���������.\n" +
                    " - â���� �Ӵ� " },
                //�浿
                { ModuleID.�浿,
                    "<blue>�ı�</blue>�� ����� �� <blue>�浹</blue>�� ����̶�! \n" +
                    "��� �͵��� ������ õü ���� �̸����� �����̸鼭 <blue>�ε���</blue> �� �ۿ� ���ԵǸ� \n" +
                    "������ �׵��� ����� ũ��� �̷���� ���ͷν� �¾ ������ �ϼ����Ѿ��Ѵ�. \n" +
                    "�̴� �η��̿� �ɷ����� �����̴�.  \n"+
                    " - �浿�� ���.p1 - �ı��� ĭ �Ҷ� ���̼� " },
                //�浿
                { ModuleID.����,
                    "���밡 ���ΰ�? ���� ������ ���� ��� �츮�� �踦 �ҷȴٰ� ���ϴ� ���ΰ�?  \n" +
                    "������ ���� �ϳ� �����س��� ���ϴ� ��������� ��� ������ �̷ﳻ�����ϴ� Ȳ����̸� \n" +
                    "��Ÿ� ������ ���������� �����ϰ� ����ġ �ϴ�. �츮�� �׵�κ��� '������'���� �д�޴�  \n" +
                    "�� �η��� ���ظ� �������� ������ ����μ� ������ '����'�� ������ ���� ���̴�.\n"+
                    " - �̽������� ���� - �ڰŻ� " },


                //������ ������
                {ModuleID.������_������,
                    "�ְ��� �������� ���ʰ��� �ܾ ���� ���Ƽ� ���� ���� \n " +
                    "���� �� ���� ������ ���� ��ȭ���̾��� �� \n " +
                    " - ��ȸ ��� �� ������ �ǿ��� ������ ��"
                },
                //�������� ��ȯ ����
                {ModuleID.��������_��ȯ����,
                    "�׷��� ������Ģ���κ��� �����ο� �� �ִ� �� �����..  \n "
                },
                {ModuleID.����,
                    "���� �߰��� ���� ȸ���� ���� ���� ���̴ٰ� \n "+
                    "�ش��̾߸��� �ְ��� ������ �ణ�̶� Ÿ���ϴ� ���� �� ���������� ���°ž� �˰ھ�? \n " +
                    " - ������"
                },

                {ModuleID.���ڿ�����_���,
                    "���󿡴� '�׷��� �ƹ��ſ�' ��� �Ҹ��� �ǳ��鼭 ����� ����� �����ܴ� \n "+
                    "���� �ϱ��� ���� ����� �ȳ��� ���� �����̴� ������ �������� �����Ѵ� \n " +
                    "���� �߸����̾��ٸ� �̹� �ҹ�⸦ ���������ٵ� ���� - ���� ��� ���� "
                },
                {ModuleID.������_�Ϲ�ȭ,
                    "�׷��ϱ� ����⸸ �ϸ� ���� ���̶� ������?  \n "+
                    "���� ���� ������ ���۷��� �۵������ ����� ���ú��� ��纣���Դϴ�. \n " +
                    " - �뺯�� ���� "
                }


                // ��û : ���̼� ����ü �� ���� �׾�� �ϴ°���? ž�� �װ� ���ڶ���? - ���� �Ƹ��� 
                // ������ ���� : ���ⱺ ������ ���� ������ ���� �����ϴ� �ڵ��� ���� ���� ���ݴ븦 ���� ���� ������ ��ġ�� �ִٴ� ����
                //  : �츮�� �������Ǹ� �����ϴ� ������ ��ŵ��� �����ϴ� ��ó�� �����Ѱ� �ƴմϴ�. 
                //  �ΰ��� ���ϸ� ���� �ӿ��� ����� ��� �ൿ�� �������� �ڽ��� �ո�ȭ�ϳ�
                //  ���� �Ͽ� ���ؼ��� �����ϸ���ŭ ���������� ����� ���Ǹ� �����ϱ� �����Դϴ�.
                //  �� ���� ��� �ּ����� �������� ���� �ù� ��ȸ�� ���� �� �ִٸ� ��ȸ�� ���Ǵ� ������ ���� �� �� �ֽ��ϴ�.
                //  �ΰ����Ǵ� �� ���Ǹ� �װ��� ���� �ùٸ��� ���� ������ �ٰ��� �� �ִ°��Դϴ�.
                               
            };

        public static Dictionary<ModuleID, string> _module_skillExplain =
            new Dictionary<ModuleID, string>()
            {
                {ModuleID.ī������Lv1,
                    "<sprite=0> <red>���</red>�� <red>���ݷ�</red>�� �ణ �ø��ϴ�." },
                {ModuleID.�м���Lv1,
                    "<sprite=1> <blue>���</blue>�� <blue>����</blue>�� �ణ �ø��ϴ�." },
                {ModuleID.å�Ӱ�Lv1,
                    "<sprite=2> ����� ���ݷ� ������ �ణ �ø��ϴ�." },
                { ModuleID.���,
                    "<sprite=1> <blue>���</blue>�� <red>���ݷ�</red>�� �ణ �ø��ϴ�.\n"+
                    "����� �ߵ� ������ ��ġ�� 1�� �̻��� <sprite=1> <blue>���</blue>����\n" +
                    " 1x1 <sprite=1> <blue>��ϵ�</blue>�� ������մϴ�." },
                { ModuleID.������_�ӱ�����,
                    "����� ��ġ�� ��Ʋ �߿��� ������ �� �ְ� �˴ϴ�."
                },
                { ModuleID.��������,
                    "������ <sprite=2> ��� �߰� ���ʽ��� ��� �˴ϴ�. \n" +
                    "��� Ư�� ������ ���� ���� ��� �ش� ��ϰ��ݷ� * 10 �������� �ް� �˴ϴ�." },
                { ModuleID.���ں�,
                    "��� ����� ä���� ��� �������� 1.5�谡 �˴ϴ�. \n" +
                    "��� ������� �ִ� ä�� ���� �� ��� �������� �ݰ� �˴ϴ�." },
                { ModuleID.��ȭ,
                    "<sprite=0>  ���� ��ġ�ɰ�� ��� �ı��ϰ� ������ \n" +
                    "�ش� �� ����ŭ�� �������� ȯ���մϴ�. "},

                { ModuleID.�浿,
                    "�ı� ��ϰ� ���õ� ��� ���� ����" },
                { ModuleID.����,
                    "���� ��ϰ� ���õ� ��� ���� ����" },
                { ModuleID.������_������,
                    "�̹� �ϵ��� ��� �������� �����մϴ�." },


            };





    }
}
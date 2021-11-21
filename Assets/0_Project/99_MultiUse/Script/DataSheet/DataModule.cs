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
                    new BlockInfo(BlockElement.Aggressive,BlockShape.Three_G_���,new Module_��ȭ(), ModuleID.��ȭ,6)}

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


          };


        public static Dictionary<ModuleID, string> _module_devcomment = new Dictionary<ModuleID, string>()
            {
                {ModuleID.ī������Lv1,
                    "������� ���� ���������, \n" +
                    "������ �̿��� ������� ������ ���� \n" +
                    " - �ѵ��� �̴��� ���Ͽ�" },
                {ModuleID.�м���Lv1,
                    "�̼��� ����� �⺻�� �� �̾߱⸦ ������� \n" +
                    "������ ���س��� ���� ���� �����ϴ� �Ϳ� �ִ�. \n" +
                    " - ������ ���� 1�� ����" },
                {ModuleID.å�Ӱ�Lv1,
                    "å�Ӱ��� �Ǹ��� ������ ���踦 �������� ���� ���� ���̷δ� .\n" +
                    " - �������� 3�� 14��" },
                {ModuleID.���,
                    "���� ���̵� ������ ����ϸ� \n" +
                    "�¾絵 �ͷ��� ���� ���ڷ� �̷�� ����. \n"+
                    "ũ�⿡ �е��Ǿ��� ���� �װ��� ��ü�϶�. \n" +
                    "���� ���� ������ �޽������� \n" +
                    " - ���� �Ƹ���,�ı� ������ p.42"},
                { ModuleID.ī������Lv2,
                    "���� ���̴� ���� �����ϰ� ������ �θ��� �������� \n" +
                    "��°�� �� ��� ���ú��ٵ� ���� ������ ��� ���°ɱ�." },

                { ModuleID.������_�ӱ�����,
                    "��ī�ο� Į�� ���� �� �߶󳻰� �ٴ����� ��õ�� ���ž�������\n" +
                    "��ġ �Ź��� �װ�ó�� ���� �ϳ� ���� ���ϱ���. \n" +
                    " - õ�ϸ�����, �츣 ���Ƿ罺�� ���� ��" },
                { ModuleID.��������,
                    "�̰��� ������ �ߴٸ� �̹� ���̰� �� ���̰� \n" +
                    "���̰Ե� ���� �̹� �߹��� ĥ ���� ���� ���̴�\n" +
                    " - ���ݵ� ��ä���� ���ÿ��� " },
                { ModuleID.��ȭ,
                    "�ƹ��� �������� �ϴ��� ��ġ �ؿ��� ��õ�� �������ش�� \n" +
                    "�г�� �״���� ����� ��Ʋ��� ������ ���� ���¿����� ���̿� \n" +
                    " - �ı��� ĭ�� 8���� ���� " }


            };

        public static Dictionary<ModuleID, string> _module_skillExplain =
            new Dictionary<ModuleID, string>()
            {
                {ModuleID.ī������Lv1,
                    "<sprite=0> ����� ���ݷ��� �ణ �ø��ϴ�." },
                {ModuleID.�м���Lv1,
                    "<sprite=1> ����� ������ �ణ �ø��ϴ�." },
                {ModuleID.å�Ӱ�Lv1,
                    "<sprite=2> ����� ���ݷ� ������ �ణ �ø��ϴ�." },
                { ModuleID.���,
                    "<sprite=1> ����� ���ݷ��� �ణ �ø��ϴ�.\n"+
                    "����� �ߵ� ������ ��ġ�� 1�� �̻��� <sprite=1> ��ϵ���\n" +
                    " 1x1 <sprite=1> ��ϵ�� ������մϴ�." },
                { ModuleID.������_�ӱ�����,
                    "����� ��ġ�� ��Ʋ �߿��� ������ �� �ְ� �˴ϴ�."
                },
                { ModuleID.��������,
                    "������ <sprite=2> ��� �߰� ���ʽ��� ��� �˴ϴ�. \n" +
                    "��� Ư�� ������ ���� ���� ��� �ش� ��ϰ��ݷ� * 10 �������� �ް� �˴ϴ�." },
                { ModuleID.��ȭ,
                    "<sprite=0>  ���� ��ġ�ɰ�� ��� �ı��ϰ� ������ \n" +
                    "�ش� �� ����ŭ�� �������� ȯ���մϴ�. "}

            };





    }
}
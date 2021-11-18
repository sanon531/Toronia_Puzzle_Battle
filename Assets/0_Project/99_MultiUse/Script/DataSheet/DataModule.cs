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



            };


        public static Dictionary<ModuleID, string> _module_devcomment = new Dictionary<ModuleID, string>()
            {
                {ModuleID.ī������Lv1,
                    "�̴� ���������, ���濡�� ������� ������ �����̿� " },
                {ModuleID.�м���Lv1,
                    "�̼��� ���� ������ ������ �� ���� ��ü�� ������ �м��ϴ� ��. " },
                {ModuleID.å�Ӱ�Lv1,
                    "å�Ӱ��� �Ǹ��� ������ ������ ü�谡 ������ ����� ������." },
                {ModuleID.���,
                    "���� ���̵� ������ ����ϸ� �¾絵 �ͷ��� ���� ���ڷ� �̷�� ����. \n"+
                    "������ �� ����� �μ��� ������ �߱��϶�. �� ġ���� ��ġȭ �϶�"},
                { ModuleID.ī������Lv2,
                    "���� ���̴� ���� �����ϰ� ������ �θ��� �������� \n" +
                    "��°�� �� ��� ���ú��ٵ� ���� ������ ��� ���°ɱ�." },


            };

        public static Dictionary<ModuleID, string> _module_skillExplain =
            new Dictionary<ModuleID, string>()
            {
                {ModuleID.ī������Lv1,
                    "���� ����� ���ݷ��� �ణ �ø��ϴ�." },
                {ModuleID.�м���Lv1,
                    "�ü� ����� ������ �ణ �ø��ϴ�." },
                {ModuleID.å�Ӱ�Lv1,
                    "��ȣ ����� ���ݷ� ������ �ణ �ø��ϴ�." },
                { ModuleID.���,
                    "����� �ߵ� ������ ��ġ�� 1�� �̻��� �ü� ��ϵ��� 1x1 �ü� ��ϵ�� ������մϴ�." },


            };





    }
}
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
                    new BlockInfo(BlockElement.Aggressive,BlockShape.One_D_���,new Module_ActBegin(), "�⼱����",1)},
                { ModuleID.ī������Lv1,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.Three_G_���,new Module_�������_����_��(), "ī������ Lv.1",4)},
                { ModuleID.�м���Lv1,
                    new BlockInfo(BlockElement.Cynical,BlockShape.Three_G_���,new Module_�üҾ���_���_��(), "ī������ Lv.1",4)},
                { ModuleID.å�Ӱ�Lv1,
                    new BlockInfo(BlockElement.Friendly,BlockShape.Three_G_���,new Module_��ȣ����_����_��(), "å�Ӱ� Lv.1",4)},
                { ModuleID.���,
                    new BlockInfo(BlockElement.Cynical,BlockShape.Three_G_���,new Module_ActBegin(), "�⼱����",3)},



            };


    }
}
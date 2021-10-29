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
        //�̷� ������ ����� �����͸� ����� �����Ѵ�.
        public static Dictionary<ModuleID, BlockInfo> _IDModuleBlockDic =
            new Dictionary<ModuleID, BlockInfo>()
            {
                { ModuleID.�⼱����,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.One_D_���,new Module_ActBegin(), "�⼱����")},
                { ModuleID.ī������Lv1,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.Four_D_���,new Module_�������(), "ī������ Lv.1")},
                { ModuleID.�м���Lv1,
                    new BlockInfo(BlockElement.Cynical,BlockShape.Four_D_���,new Module_�üҾ���(), "ī������ Lv.1")},
                { ModuleID.å�Ӱ�Lv1,
                    new BlockInfo(BlockElement.Friendly,BlockShape.Four_D_���,new Module_��ȣ����(), "å�Ӱ� Lv.1")},
                { ModuleID.���,
                    new BlockInfo(BlockElement.Cynical,BlockShape.Three_G_���,new Module_ActBegin(), "�⼱����")},



            };


        public static Dictionary<ModuleID, ModuleInfo> ModuleEffectDic =
            new Dictionary<ModuleID, ModuleInfo>()
            {
                { ModuleID.ī������Lv1,new Module_�������()},
                { ModuleID.�м���Lv1,new Module_�üҾ���()},
                { ModuleID.������Lv1,new Module_��ȣ����()},
                { ModuleID.�⼱����,new Module_ActBegin()}


            };


    }
}
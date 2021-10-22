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
        public static Dictionary<ModuleID, BlockCase_Module> _IDModuleDic =
            new Dictionary<ModuleID, BlockCase_Module>()
            {
                { ModuleID.�⼱����,
                    new BlockCase_Module()}
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
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
                    new BlockCase_Module(
                        new BlockInfo(BlockElement.Aggressive,BlockShape.Two_H),
                        ModuleEffectDic[ModuleID.�⼱����])}
            };
        public static Dictionary<ModuleID, ModuleInfo> ModuleEffectDic =
            new Dictionary<ModuleID, ModuleInfo>()
            {


            };


    }
}
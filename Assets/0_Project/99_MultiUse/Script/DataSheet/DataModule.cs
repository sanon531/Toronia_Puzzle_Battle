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
            {ModuleID.기선제압,new Module_DataTable()}

        };
        //이런 식으로 블록의 데이터를 만들고 저장한다.
        public static Dictionary<ModuleID, BlockCase_Module> _IDModuleDic =
            new Dictionary<ModuleID, BlockCase_Module>()
            {
                { ModuleID.기선제압,
                    new BlockCase_Module(
                        new BlockInfo(BlockElement.Aggressive,BlockShape.Two_H),
                        ModuleEffectDic[ModuleID.기선제압])}
            };
        public static Dictionary<ModuleID, ModuleInfo> ModuleEffectDic =
            new Dictionary<ModuleID, ModuleInfo>()
            {


            };


    }
}
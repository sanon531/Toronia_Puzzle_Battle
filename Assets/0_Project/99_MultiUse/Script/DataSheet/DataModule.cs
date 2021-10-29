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
        public static Dictionary<ModuleID, BlockInfo> _IDModuleBlockDic =
            new Dictionary<ModuleID, BlockInfo>()
            {
                { ModuleID.기선제압,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.One_D_모듈,new Module_ActBegin(), "기선제압")},
                { ModuleID.카리스마Lv1,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.Four_D_모듈,new Module_강경업글(), "카리스마 Lv.1")},
                { ModuleID.분석력Lv1,
                    new BlockInfo(BlockElement.Cynical,BlockShape.Four_D_모듈,new Module_냉소업글(), "카리스마 Lv.1")},
                { ModuleID.책임감Lv1,
                    new BlockInfo(BlockElement.Friendly,BlockShape.Four_D_모듈,new Module_우호업글(), "책임감 Lv.1")},
                { ModuleID.쇄빙,
                    new BlockInfo(BlockElement.Cynical,BlockShape.Three_G_쇄빙,new Module_ActBegin(), "기선제압")},



            };


        public static Dictionary<ModuleID, ModuleInfo> ModuleEffectDic =
            new Dictionary<ModuleID, ModuleInfo>()
            {
                { ModuleID.카리스마Lv1,new Module_강경업글()},
                { ModuleID.분석력Lv1,new Module_냉소업글()},
                { ModuleID.따뜻함Lv1,new Module_우호업글()},
                { ModuleID.기선제압,new Module_ActBegin()}


            };


    }
}
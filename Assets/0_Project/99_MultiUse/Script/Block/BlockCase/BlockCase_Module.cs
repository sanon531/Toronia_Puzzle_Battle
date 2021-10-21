using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    [System.Serializable]
    public class BlockCase_Module : BlockCase
    {
        public ModuleInfo _moduleInfo;

        public BlockCase_Module(BlockInfo argBlockinfo, ModuleInfo argModuleinfo)
        {
            _blockInfo = new BlockInfo(argBlockinfo);
            _moduleInfo = argModuleinfo;
        }
    }


}

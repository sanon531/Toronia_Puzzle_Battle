using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    [System.Serializable]
    public class BlockCase_Module : BlockCase
    {
        
        public BlockCase_Module()
        {
            _blockInfo._type = BlockType.Module;
            _blockInfo._isLiftable = false;
        }
    }


}

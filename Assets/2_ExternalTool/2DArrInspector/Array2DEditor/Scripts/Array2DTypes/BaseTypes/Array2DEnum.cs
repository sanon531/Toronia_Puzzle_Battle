using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;

namespace Array2DEditor
{


    [System.Serializable]
    public class Array2DModuleID : Array2D<ModuleID>
    {
        [SerializeField]
        CellRowModuleID[] cells = new CellRowModuleID[Consts.defaultGridSize];

        protected override CellRow<ModuleID> GetCellRow(int idx)
        {
            return cells[idx];
        }

        public Array2DModuleID(int _x,int _y)
        {
            cells = new CellRowModuleID[_y];

        }
    }

    [System.Serializable]
    public class CellRowModuleID : CellRow<ModuleID>
    {
    }
}

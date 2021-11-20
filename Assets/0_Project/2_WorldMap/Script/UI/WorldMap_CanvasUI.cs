using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.UI;
using ToronPuzzle.Event;

namespace ToronPuzzle.WorldMap
{
    public class WorldMap_CanvasUI : UIManager
    {
        public static WorldMap_CanvasUI Instance;

        public override void BeginUIManager()
        {
            base.BeginUIManager();
            Instance = this;
        }



    }

}

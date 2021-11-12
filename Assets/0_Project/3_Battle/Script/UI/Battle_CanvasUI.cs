using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ToronPuzzle.Battle;
using ToronPuzzle.Event;

namespace ToronPuzzle.UI
{
    public class Battle_CanvasUI : UIManager
    {
        public static Battle_CanvasUI Instance;
        public override void BeginUIManager()
        {
            base.BeginUIManager();
            Instance = this;
        }

    }

}

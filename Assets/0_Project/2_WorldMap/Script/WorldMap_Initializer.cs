using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ToronPuzzle.WorldMap
{
    public class WorldMap_Initializer : MonoBehaviour
    {
        // Start is called before the first frame update
        Canvas _worldMapCanvas;
        public void WorldMapBegin()
        {
            _worldMapCanvas = GameObject.Find("WorldMapCanvas").GetComponent<Canvas>();
            _worldMapCanvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            WorldMap_CanvasUI battle_CanvasUI = _worldMapCanvas.gameObject.GetComponent<WorldMap_CanvasUI>();
            battle_CanvasUI.BeginUIManager();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
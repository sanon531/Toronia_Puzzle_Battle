using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    public class Global_CanvasData : MonoBehaviour
    {
        public static class CanvasData
        {
            public static Vector2 LDAchorPos = default;
            public static Vector2 RUAchorPos = default;
            public static Vector2 _screenWorldSize = default;
            public static float _worldToCanvasSize = default;
            public static Vector2 _inventoryCellSize = default;
        }
        public GameObject LDAchor;
        public GameObject RUAchor;

        public void BeginCanvasData()
        {
            CanvasData.LDAchorPos = LDAchor.transform.position;
            CanvasData.RUAchorPos = RUAchor.transform.position;
            CanvasData._screenWorldSize = CanvasData.RUAchorPos - CanvasData.LDAchorPos;
            CanvasData._worldToCanvasSize = GetComponent<RectTransform>().localScale.x;
        }
    }

}

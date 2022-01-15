using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ToronPuzzle.Title
{
    public class Title_Initializer : MonoBehaviour
    {
        Title_CanvasManager _title_CanvasManager;
        public void TitleBegin()
        {
            _title_CanvasManager = GameObject.Find("Title_Canvas").GetComponent<Title_CanvasManager>();
            _title_CanvasManager.BeginCanvas();
        }

    }
}
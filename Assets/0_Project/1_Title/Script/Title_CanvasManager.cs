using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ToronPuzzle.Title
{
    public class Title_CanvasManager : MonoBehaviour
    {
        Title_MainPanelManager _title_MainPanelManager;
        public void BeginCanvas()
        {
            _title_MainPanelManager = GameObject.Find("Title_MainPanel").GetComponent<Title_MainPanelManager>();
            _title_MainPanelManager.BeginMainPannel();
        }
    }
}
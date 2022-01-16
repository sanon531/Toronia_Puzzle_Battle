using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ToronPuzzle.Event;

namespace ToronPuzzle.Title
{
    public class Title_CanvasManager : MonoBehaviour
    {
        Title_MainPanelManager _title_MainPanelManager;
        GameObject _title_Alert_Panel;
        Button _title_Alert_Button;
        TextMeshProUGUI _text_onButton;
        public void BeginCanvas()
        {
            _title_MainPanelManager = GameObject.Find("Title_MainPanel").GetComponent<Title_MainPanelManager>();
            _title_MainPanelManager.BeginMainPannel();
            _title_Alert_Panel = GameObject.Find("Title_AlertPanel");
            _title_Alert_Button = GameObject.Find("Title_AlertPanelButton").GetComponent<Button>();
            Global_UIEventSystem.Register_UIEvent(UIEventID.Title_새게임_시작_알림, ShowNewGamePannel);
            _title_Alert_Button.onClick.AddListener(() => StartNewGame());
            _title_Alert_Panel.SetActive(false);
        }

        void ShowNewGamePannel()
        {
            _title_Alert_Panel.SetActive(true);
        }

        void StartNewGame()
        {
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_씬이동, Data.SceneType.WorldMap);
        }
    }
}
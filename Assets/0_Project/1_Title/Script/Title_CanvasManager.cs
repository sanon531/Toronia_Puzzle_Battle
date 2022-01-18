using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ToronPuzzle.Event;
using ToronPuzzle.UI;

namespace ToronPuzzle.Title
{
    public class Title_CanvasManager : MonoBehaviour
    {
        Title_MainPanelManager _title_MainPanelManager;
        GameObject _title_Alert_Panel;
        Button _title_Alert_Button;
        TextMeshProUGUI _text_onButton;
        [SerializeField]
        RectTransform _title_credit;
        ButtonFunctions _creditButton, _creditBackButton;
        
        public void BeginCanvas()
        {
            _title_MainPanelManager = GameObject.Find("Title_MainPanel").GetComponent<Title_MainPanelManager>();
            _title_MainPanelManager.BeginMainPannel();
            _title_Alert_Panel = GameObject.Find("Title_FullAlertPanel");
            _title_Alert_Button = GameObject.Find("Title_AlertPanelButton").GetComponent<Button>();
            Global_UIEventSystem.Register_UIEvent(UIEventID.Title_새게임_시작_알림, ShowNewGamePannel);
            _title_Alert_Button.onClick.AddListener(() => StartNewGame());
            _title_Alert_Panel.SetActive(false);

            _title_credit = GameObject.Find("Title_Credit").GetComponent<RectTransform>();
            _title_credit.sizeDelta = new Vector2(Camera.main.pixelWidth * 0.8f, Camera.main.pixelHeight*0.8f);
            _title_credit.anchoredPosition = new Vector3(Camera.main.pixelWidth, 0);
            //크레딧 사이즈 정하기.
            _creditButton = GameObject.Find("Title_CreditButton").GetComponent<ButtonFunctions>();
            _creditButton._targetPos = new Vector3(-Camera.main.pixelWidth, 0, 0);
            _creditBackButton = GameObject.Find("Title_CreditBackButton").GetComponent<ButtonFunctions>();
            _creditBackButton._targetPos = new Vector3(0, 0, 0);

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToronPuzzle.Data;
using ToronPuzzle.Event;


namespace ToronPuzzle.Title
{
    public class Title_MainPanelManager : MonoBehaviour
    {
        Button _newGameButton, _continueButton, _creditButton;

        public void BeginMainPannel()
        {
            _newGameButton = GameObject.Find("Title_NewGameButton").GetComponent<Button>();
            _continueButton = GameObject.Find("Title_ContinueGameButton").GetComponent<Button>();
            _creditButton = GameObject.Find("Title_CreditButton").GetComponent<Button>();

            _newGameButton.onClick.AddListener(() => ClickNewGameButton());
            _continueButton.onClick.AddListener(() => ClickContinueGameButton());
            _creditButton.onClick.AddListener(() => ClickCreditButton());

            if (ES3.KeyExists("ContinueFileExist", ToronSaveclass._datascriptPath))
            {
                //Debug.Log(ES3.Load<bool>("ContinueFileExist", ToronSaveclass._datascriptPath));
                if (ES3.Load<bool>("ContinueFileExist", ToronSaveclass._datascriptPath))
                    _continueButton.interactable = true;
                else
                    _continueButton.interactable = false;
            }
            else
                _continueButton.interactable = false;




        }

        //만약 알림창을 띄우고 그 다음에 한다.
        void ClickNewGameButton()
        {
            if (_continueButton.interactable)
            {
                Global_UIEventSystem.Call_UIEvent(UIEventID.Title_새게임_시작_알림);
            }
            else
            {
                ES3.Save("ContinueFileExist", true, ToronSaveclass._datascriptPath);
                Debug.Log(ES3.Load<bool>("ContinueFileExist", ToronSaveclass._datascriptPath));
                StartNewGame();
            }
        }

        void StartNewGame()
        {
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_씬이동, Data.SceneType.WorldMap);
        }

        //바로 속행한다.
        void ClickContinueGameButton()
        {
            Global_UIEventSystem.Call_UIEvent(UIEventID.Global_씬이동, Data.SceneType.WorldMap);
        }
        void ClickCreditButton()
        {

        }


    }
}

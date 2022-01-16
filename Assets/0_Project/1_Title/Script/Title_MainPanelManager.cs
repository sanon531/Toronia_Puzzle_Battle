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

            Debug.Log(ES3.Load<bool>("ContinueFileExist", ToronSaveclass._datascriptPath));
            if (ES3.KeyExists("ContinueFileExist", ToronSaveclass._datascriptPath))
            {
                if (ES3.Load<bool>("ContinueFileExist", ToronSaveclass._datascriptPath))
                    _continueButton.enabled = true;
                else
                    _continueButton.enabled = false;
            }
            else
                _continueButton.enabled = false;




        }

        //���� �˸�â�� ���� �� ������ �Ѵ�.
        void ClickNewGameButton()
        {
            Debug.Log("Click new button"+ _continueButton.enabled);
            if (_continueButton.enabled)
            {
                Global_UIEventSystem.Call_UIEvent(UIEventID.Title_������_����_�˸�);
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


        }

        //�ٷ� �����Ѵ�.
        void ClickContinueGameButton()
        {

        }
        void ClickCreditButton()
        {

        }


    }
}

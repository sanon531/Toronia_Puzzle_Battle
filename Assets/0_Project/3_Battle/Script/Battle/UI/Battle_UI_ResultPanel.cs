using TMPro;
using ToronPuzzle.Event;
using ToronPuzzle.UI;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using ToronPuzzle.Data;
using ToronPuzzle.Event;


namespace ToronPuzzle.Battle
{
    public enum GameEndSituation
    {
        GameClear,
        EnemyRun,
        Escape,
        GameOver
    }
    public class Battle_UI_ResultPanel : UI_Object, IGameListenerUI
    {
        [SerializeField]
        List<Image> _gradual_Image_List = new List<Image>();
        [SerializeField]
        Button _GoBackButton;
        [SerializeField]
        GameObject _panel_Obj; 
        [SerializeField]
        TextMeshProUGUI _gameResult,_goBackTitle;

        GameEndSituation _currentSituation = GameEndSituation.GameOver;
        public void AssignGameListener()
        {
            Global_UIEventSystem.Register_UIEvent<GameEndSituation>(UIEventID.Battle_����_����, SetGameOverTitle, EventRegistOption.None);
            _GoBackButton.onClick.AddListener(() => PressResultButton());
            foreach (Image _image in _gradual_Image_List)
                _image.color = new Color(0,0,0,0);
            _gameResult.color = new Color(0, 0, 0, 0);
            _goBackTitle.color = new Color(0, 0, 0, 0);
            _panel_Obj.SetActive(false);
        }

        //���� �����
        void SetGameOverTitle(GameEndSituation _situation)
        {
            _currentSituation = _situation;
            _panel_Obj.SetActive(true);
            Debug.Log("Start Game Over"+ _panel_Obj.activeSelf);
            foreach (Image _image in _gradual_Image_List)
                _image.DOColor(Color.white, 0.5f);
            _gameResult.DOColor(Color.white, 0.5f);
            _goBackTitle.DOColor(Color.white, 0.5f);

            switch (_situation)
            {
                case GameEndSituation.GameClear:
                    _gameResult.SetText("����");
                    _goBackTitle.SetText("���");
                    break;
                case GameEndSituation.EnemyRun:
                    _gameResult.SetText("�� ����..");
                    _goBackTitle.SetText("���");
                    break;
                case GameEndSituation.Escape:
                    _gameResult.SetText("������ ����..");
                    _goBackTitle.SetText("���");
                    break;
                case GameEndSituation.GameOver:
                    _gameResult.SetText("���� �й�");
                    _goBackTitle.SetText("����ȭ������");
                    break;
                default:
                    Debug.LogError("NoneDataError");
                    break;
            }
        }

        void PressResultButton()
        {
            switch (_currentSituation)
            {
                case GameEndSituation.GameClear:
                    Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_���̵�, SceneType.WorldMap);
                    break;
                case GameEndSituation.EnemyRun:
                    Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_���̵�, SceneType.WorldMap);
                    break;
                case GameEndSituation.Escape:
                    Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_���̵�, SceneType.WorldMap);
                    break;
                case GameEndSituation.GameOver:
                    Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_���̵�, SceneType.Title);
                    break;
                default:
                    Debug.LogError("Press NoneDataError");
                    break;
            }

        }


    }
}
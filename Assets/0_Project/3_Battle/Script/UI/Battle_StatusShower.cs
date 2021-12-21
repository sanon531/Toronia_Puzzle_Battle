using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ToronPuzzle.Event;
using ToronPuzzle.UI;
using ToronPuzzle.Data;
namespace ToronPuzzle.Battle
{
    public class Battle_StatusShower : UI_Object, IGameListenerUI
    {
        [SerializeField]
        Transform _playerBuff, _enemyBuff;
        List<GameObject> _playerBuffList = new List<GameObject>();
        List<GameObject> _enemyBuffList = new List<GameObject>();
        GameObject _buffShow;

        public void AssignGameListener()
        {
            Global_UIEventSystem.Register_UIEvent<List<CharBuffData>>(UIEventID.Battle_플레이어_특성변동, Change_ShowedPlayerBuff, EventRegistOption.None);
            Global_UIEventSystem.Register_UIEvent<List<CharBuffData>>(UIEventID.Battle_적_특성변동, Change_ShowedEnemyBuff, EventRegistOption.None);
            _buffShow = Resources.Load<GameObject>("BuffShow/BuffShow");
        }

        // Start is called before the first frame update
        void Start()
        {

        }



        void Change_ShowedPlayerBuff(List<CharBuffData> _charStatus)
        {
            foreach (GameObject _buff in _playerBuffList)
                Destroy(_buff);

            foreach (CharBuffData _buffData in _charStatus)
            {
                GameObject _buff = Instantiate(_buffShow, _playerBuff);
                _playerBuffList.Add(_buff);
                _buff.GetComponent<Battle_BuffShow>().SetDataOnShow(_buffData);
            }
        }
        void Change_ShowedEnemyBuff(List<CharBuffData> _charStatus)
        {
            foreach (GameObject _buff in _enemyBuffList)
                Destroy(_buff);

            foreach (CharBuffData _buffData in _charStatus)
            {
                GameObject _buff = Instantiate(_buffShow, _enemyBuff);
                _enemyBuffList.Add(_buff);
                _buff.GetComponent<Battle_BuffShow>().SetDataOnShow(_buffData);
            }

        }

    }
}
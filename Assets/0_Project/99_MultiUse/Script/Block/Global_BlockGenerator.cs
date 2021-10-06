using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Battle;
using ToronPuzzle.Event;

namespace ToronPuzzle
{
    public class Global_BlockGenerator : MonoBehaviour
    {

        public static Global_BlockGenerator instance;
        [SerializeField]
        BlockInfo _lastBlockData;
        #region
        GameObject _spawned;//매개로 사용되는 변수
        GameObject _blockCase_world,_worldBlock, _UIBlock, _outLinerWorld, _outlinerUI;
        public Vector2 BlockSize;
        public Vector3 OutlinePercent =new Vector3(1.2f, 1.2f,1.2f);
        #endregion


        public BlockElement this_BlockElement;


        public void BeginBlockGenerator()
        {
            instance = this;
            _worldBlock = Resources.Load("BlockCaseCell_World") as GameObject;
            _UIBlock = Resources.Load("BlockCaseCell_UI") as GameObject;
            _outLinerWorld = Resources.Load("BlockCaseOutLiner_World") as GameObject;
            _outlinerUI = Resources.Load("BlockCaseOutLiner_UI") as GameObject;
            _blockCase_world = Resources.Load("BlockCaseOutLiner_UI") as GameObject;
        }

        public void GenerateOnBlockPlace(BlockInfo _inputInfo)
        {
            _lastBlockData = _inputInfo;
            int[,] _tempt_BlockArray = (int[,])_lastBlockData._blockShapeArr.Clone();
            Vector2 InputSize = Master_Battle.Data_OnlyInBattle._cellsize;
            GameObject CaseObject = 
                Instantiate(_blockCase_world, transform.position, Quaternion.identity, Master_BlockPlace.instance._blockHolder);
            BlockCase_World _current_Case = CaseObject.GetComponent<BlockCase_World>();

            int _maxX = _tempt_BlockArray.GetLength(0);
            int _maxY = _tempt_BlockArray.GetLength(1);


            for (int i_y = _maxY-1; i_y > 0 ; i_y--)
            {
                for (int j_x = 0; j_x < _maxX; j_x++)
                {
                    if (_tempt_BlockArray[j_x, i_y] == 1)
                    {
                        _spawned = Instantiate(_outLinerWorld, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        Vector3 spawnedvector = new Vector3(InputSize.x * j_x, (InputSize.y * i_y), 0);
                        _spawned.transform.localPosition = spawnedvector;
                        _spawned.transform.localScale = OutlinePercent;


                        _spawned = Instantiate(_worldBlock, new Vector3(0, 0, 0), Quaternion.identity, CaseObject.transform);
                        _spawned.GetComponent<BlockCaseCell>().initializeCell(_current_Case);
                        _spawned.transform.localPosition = spawnedvector;



                    }
                }
            }





            Global_InWorldEventSystem.CallOn블록배치();
        }





    }

 }

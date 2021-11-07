using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
namespace ToronPuzzle
{
    /// <summary>
    /// 처음의 데이터는 여기서 저장 되며 
    /// 여기서 세이브 데이터와의 교환과 정보 처리가 지속됨
    /// 
    /// 모듈의 형성이 주되게 적용될 것 + 
    /// 인게임의 데이터에서는 모듈의 위치, 모듈의 모양, 
    /// 모듈의 그냥 정보 전부 다 전반적으로 다 들어갈것
    /// 
    /// 
    /// </summary>
    public class Global_InGameData : MonoBehaviour
    {
        public static Global_InGameData Instance;
        public PlacePannelData _placePannelData;
        [SerializeField]
        bool isDebug = false;

        [SerializeField]
        List<BlockCase_Module> _ownedModule = new List<BlockCase_Module>();
        public StageInfo _currentStageData ;


        /// <summary>
        /// 디버그 시에만 활용되는 것.
        /// </summary>
        public List<ModuleID> _debug_ModuleIDs = new List<ModuleID>();
        [SerializeField]
        Array2DEditor.Array2DModuleID _currentPlacement ;



        public void BeginInGameData()
        {
            Instance= this;
            if(!isDebug)
                _currentStageData = StageDataPool.StageinfoDic["Basic"];
        }

        public void BegingModuleData()
        {
            if (isDebug)
            {
                // 여기서 모듈들을 디버깅 용으로 모듈 설치를 한다. 
                // 일반적으로는 저장된 블록의 데이터를 기반으로 새로이 저장된 데이터를 따로 저장해서 그걸 기반으로 만든다.
                foreach (ModuleID moduleID in _debug_ModuleIDs)
                {
                    for (int i_y = 0; i_y < _currentPlacement.GridSize.y; i_y++)
                    {
                        for (int j_x = 0; j_x < _currentPlacement.GridSize.x; j_x++)
                        {
                            if (_currentPlacement.GetCell(j_x, i_y) == moduleID)
                            {
                                BlockInfo _temptBlockInfo =ModuleDic._IDModuleBlockDic[moduleID];
                                _temptBlockInfo._blockPlace = new Vector2Int(j_x, i_y);

                                Global_BlockGenerator.instance.GenerateModuleOnBlockPlace(_temptBlockInfo);


                            }
                        }
                    }
                }
            }
        }


    }



    [System.Serializable]
    public class PlacePannelData
    {
        public int _maxX = 4;
        public int _maxY = 6;
        public int[,] _blockPlacedArr = new int[4, 6];
        public List<BlockInfo> _moduleBlockInfos = new List<BlockInfo>();


    }
}


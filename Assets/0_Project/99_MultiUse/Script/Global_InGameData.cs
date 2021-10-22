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
        List<BlockCase_Module> _ownedModule = new List<BlockCase_Module>();



        /// <summary>
        /// 디버그 시에만 활용되는 것.
        /// </summary>
        [SerializeField]
        bool isDebug=false;
        public List<ModuleID> _debug_ModuleIDs = new List<ModuleID>();
        [SerializeField]
        Array2DEditor.Array2DModuleID _currentPlacement ;




        public void BeginInGameData()
        {
            Instance= this;
            if (isDebug)
            {
                // 여기서 대충 

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


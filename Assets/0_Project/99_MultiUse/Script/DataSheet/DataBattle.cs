using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ToronPuzzle.Data
{
    public enum BGImageKind
    {
        AGR_1,
        CYN_1,
        FRN_1,
        BOSS_ARG,
        BOSS_CYN
    }

    public enum StageKind
    {

    }
    [System.Serializable]
    public class StageInfo
    {
        //그냥 스테이지 데이터
        public float _battleTime;
        public float _spawnSpeed;

        public List<BlockInfo> _blockList;


        //적의 정보
        public List<CharacterID> _stageEnemys;


        public StageInfo(float _argBattleTime, float _argSpawnSpeed, List<BlockInfo> _argBlockList,List<CharacterID> _argStageEnemys)
        {
            _battleTime = _argBattleTime;
            _spawnSpeed = _argSpawnSpeed;
            _blockList = _argBlockList;
            _stageEnemys = _argStageEnemys;
        } 
    }

    public static class StageDataPool
    {
        public static Dictionary<string, StageInfo> StageinfoDic
            = new Dictionary<string, StageInfo> {
                { "Basic",
                    new StageInfo(
                        20f,
                        2f,
                        new List<BlockInfo>(){
                            new BlockInfo(BlockElement.Aggressive, BlockShape.One_D,1),
                        },
                        new List<CharacterID>(){
                            CharacterID.멸고단원
                        }
                )},



            };

    }

}

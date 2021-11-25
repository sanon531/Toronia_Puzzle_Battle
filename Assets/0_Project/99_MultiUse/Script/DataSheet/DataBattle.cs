using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ToronPuzzle.Data
{
    /// <summary>
    /// 맵에서 나오는 오브젝트 들에 대한 정보.
    /// </summary>
    public enum ActionObjectKind
    {
        이벤트,
        일반_배틀,
        엘리트_배틀,
        보스_배틀,
        아이템,
        상점,
        정보오염,
        미정

    }

    /// <summary>
    /// 배경 화면의 이미지에대한 설정
    /// </summary>
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
        public string _stageName = "Sample_Map";
        public float _battleTime = 10;
        public float _spawnSpeed = 10;

        public float _startCoolTime = 10f;
        public float _battleCoolTime = 10f;

        public List<BlockInfo> _blockList;


        //적의 정보
        public List<CharacterID> _stageEnemys;

        // float array는 순차적으로, 한 배틀 당의 시간 쿨타임간의 관계임 
        //그리고 아직은 그냥 대강 놓은 거고 대부분의 내용들은 아이템 얻어가면서 바꿔갈것.
        public StageInfo(string _argname,float[] _argFloatData, List<BlockInfo> _argBlockList,List<CharacterID> _argStageEnemys)
        {
            _stageName = _argname;
            _battleTime = _argFloatData[0];
            _spawnSpeed = _argFloatData[1];
            _startCoolTime = _argFloatData[2];
            _battleCoolTime = _argFloatData[3];
            _blockList = _argBlockList;
            _stageEnemys = _argStageEnemys;
        } 
    }

    public static class StageDataPool
    {
        public static Dictionary<string, StageInfo> StageinfoDic
            = new Dictionary<string, StageInfo> {
                { "멸고단_1",
                    new StageInfo("멸고단_1",new float[]{
                        20f,2f,5f,10f},
                        new List<BlockInfo>(){
                            new BlockInfo(BlockElement.Aggressive, BlockShape.One_D,1),
                        },
                        new List<CharacterID>(){
                            CharacterID.멸고단원
                        }
                )},



            };

        public static Dictionary<string, List<CharactorActionInfo>> StrActionListDic = 
            new Dictionary<string, List<CharactorActionInfo>>() {
                { "Basic",new List<CharactorActionInfo>() {new CharactorActionInfo()}
                }
            };

        public static Dictionary<string, CharactorActionInfo> StrActionDic =
            new Dictionary<string, CharactorActionInfo>() {
                {"Attack_1", new CharactorActionInfo() }

            };

    }

}

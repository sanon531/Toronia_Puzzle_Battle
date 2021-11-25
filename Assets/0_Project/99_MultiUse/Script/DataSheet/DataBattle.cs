using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ToronPuzzle.Data
{
    /// <summary>
    /// �ʿ��� ������ ������Ʈ �鿡 ���� ����.
    /// </summary>
    public enum ActionObjectKind
    {
        �̺�Ʈ,
        �Ϲ�_��Ʋ,
        ����Ʈ_��Ʋ,
        ����_��Ʋ,
        ������,
        ����,
        ��������,
        ����

    }

    /// <summary>
    /// ��� ȭ���� �̹��������� ����
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
        //�׳� �������� ������
        public string _stageName = "Sample_Map";
        public float _battleTime = 10;
        public float _spawnSpeed = 10;

        public float _startCoolTime = 10f;
        public float _battleCoolTime = 10f;

        public List<BlockInfo> _blockList;


        //���� ����
        public List<CharacterID> _stageEnemys;

        // float array�� ����������, �� ��Ʋ ���� �ð� ��Ÿ�Ӱ��� ������ 
        //�׸��� ������ �׳� �밭 ���� �Ű� ��κ��� ������� ������ ���鼭 �ٲ㰥��.
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
                { "����_1",
                    new StageInfo("����_1",new float[]{
                        20f,2f,5f,10f},
                        new List<BlockInfo>(){
                            new BlockInfo(BlockElement.Aggressive, BlockShape.One_D,1),
                        },
                        new List<CharacterID>(){
                            CharacterID.���ܿ�
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

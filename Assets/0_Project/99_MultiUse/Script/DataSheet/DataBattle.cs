using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ToronPuzzle.Data
{
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

    // ���������� ���� ť�� ���� ���� ���̸�
    // �����̴� �����̾� ó�� ������ ������ ���´�. 
    // 
    public static class StageDataPool
    {
        public static Dictionary<string, StageInfo> StageinfoDic
            = new Dictionary<string, StageInfo> {
                { "����_1",
                    new StageInfo("����_1",new float[]{
                        25f,1f,5f,10f},
                        new List<BlockInfo>(){
                            new BlockInfo(BlockElement.Aggressive, BlockShape.Three_AG,4),
                            new BlockInfo(BlockElement.Cynical, BlockShape.Three_AG,4),
                            new BlockInfo(BlockElement.Friendly, BlockShape.Three_AG,4)
                        },
                        new List<CharacterID>(){
                            CharacterID.���ܿ�
                        }
                )},
                { "��_����_1",
                    new StageInfo("��_����_1",new float[]{
                        15f,0.75f,5f,8f},
                        new List<BlockInfo>(){
                            new BlockInfo(BlockElement.Aggressive, BlockShape.Three_AG,4),
                            new BlockInfo(BlockElement.Cynical, BlockShape.Three_AG,4),
                            new BlockInfo(BlockElement.Friendly, BlockShape.Three_AG,4)
                        },
                        new List<CharacterID>(){
                            CharacterID.�ݸ��ܿ�
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

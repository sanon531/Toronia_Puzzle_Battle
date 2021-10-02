
namespace ToronPuzzle.Event
{

    public enum UIEventID
    {

        //-> Ÿ��Ʋ UI�̺�Ʈ
        Title_Open�ε�UI,
        Title_Close�ε�UI,

        Title_Open�α���UI,
        Title_Close�α���UI,

        Tield_Open����������,

        Title_Openķ���θ�弱��UI,
        Title_Closeķ���θ�弱��UI,

        Title_Openķ���μ���UI,
        Title_Closeķ���μ���UI,

        Title_Open�κ�UI,
        Title_Close�κ�UI,
        Title_Open�κ�޴�UI,
        Title_Open��������������UI,
        Title_Close��������������UI,
        Title_On���ż���,

        Title_Open�⼮UI,
        Title_Open�⼮UI_WithCloseEvent,
        Title_Close�⼮UI,
        Title_Open����UI,
        Title_Close����UI,
        Title_Open�̺�ƮUI,
        Title_Close�̺�ƮUI,

        Title_Open������UI,
        Title_Open������With��ŷ���UI,
        Title_Close������UI,
        Title_Open�����ʸ޴�UI,
        Title_Close�����ʸ޴�UI,
        Title_Open��ŷ���UI,
        Title_Open���UI,
        Title_Open�������UI,
        Title_Close�������UI,
        Title_Open��ϼ���UI,
        Title_Close��ϼ���UI,

        Title_Open�����ܺ���UI,
        Title_�����ܺ���,

        Title_Openĳ���ͼ���UI,
        Title_Closeĳ���ͼ���UI,
        Title_Open������������UI,
        Title_Open���ۼҸ�ǰ����UI,
        Title_Close���۾����ۼ���UI,

        Title_OpenCashShopUI,
        Title_CloseCashShopUI,
        Title_OnCloseCashShopUI,

        Title_OpenAncientLegacyUI,
        Title_CloseAncientLegacyUI,
        Title_OpenLegacyExploreUI,
        Title_CloseLegacyExploreUI,

        Title_OpenRankingUI,
        Title_CloseRankingUI,
        Title_OpenRankingDetail,
        Title_CloseRankingDetail,

        Title_Open���ۼ���,
        Title_���ۼ���End,

        Title_Open�ƾ�,
        Title_Close�ƾ�,

        Title_OpenUnlockGachaChoice,
        Title_OpenStuffGachaResult,

        Title_Open��íȮ��UI,
        Title_Close��íȮ��UI,

        Title_Refresh��íUI,
        Title_�κ��丮����,
        Title_On��ȭ�Ҹ�Ŭ���̾�Ʈ�����ӿ���,

        Global_On����ȿ���ߵ�,

        //-> ����ȭ�� �ΰ���UI �̺�Ʈ
        Combat_On������,

        Combat_On����º���,

        Combat_Onȿ������,

        Combat_Onĳ���ͼ��õ�,
        Combat_Onĳ���ͼ��ó���,

        Combat_On�ൿ�º���,

        Combat_Show���������,

        //->ķ���� ������ ���� UI����ȭ
        World_On����,

        Global_OnSP����,
        World_On����º���,
        World_On���׹̳ʺ���,
        World_On��ȭ����,
        World_OnSP����,
        Global_On�����ġ����,
        Global_On����ܰ躯��,
        Global_On������ġ����, //�̺�Ʈ�� ���� ������ ����
        Global_On��������, //���� ������ ������� ����
        Global_On��������_With���忬��,
        Global_On��������,

        Global_On�Ҹ�ǰ����,
        Global_On�Ҹ�ǰ����_With���忬��,

        //-> ����ȭ�� UI�̺�Ʈ
        Combat_On�������ε�,

        Combat_OpenActionUI,
        Combat_ShowSkillDescription,
        Combat_HideSkillDescription,
        Combat_OpenTargetSelectUI_Skill,
        Combat_OpenTargetSelectUI_Consumable,
        Combat_OnTargetSelectCanceled,
        Combat_CloseAllActionUI,
        Combat_CloseSelectTargetUI,

        Combat_OpenBattleEvent,
        Combat_SetNextBattleEvent,
        Combat_CloseBattleEvent,
        Combat_ShowSimpleBattleEvent,

        Combat_RefreshTurnCount,
        Combat_OpenTurnCount,
        Combat_CloseTurnCount,

        //-> ����ȭ�� UI�̺�Ʈ
        World_On������ε�,
        World_On����ĳ���ͷε�,

        World_On�ð�����,
        World_On�ð��ѹ���������,
        World_OnTileEventEnd,

        World_����ȿ������,

        World_OpenDiceUI,
        World_CloseDiceUI,
        World_On�ֻ�������,
        World_OnŸ����ǥ����,
        World_�������������̱�,
        World_���������������,
        World_���⼱�ù�ư���̱�,
        World_Ÿ���̹�����ü,
        World_Ÿ�Ϲ��̹������̱�,
        World_Ÿ�Ϲ��̹��������,
        World_TileGizmo��Ȱ��ȭ,
        World_TileGizmoȰ��ȭ,


        World_Open����UI,
        World_Close����UI,
        World_Open���UI,

        World_OpenShopTileUI,
        World_CloseShopTileUI,

        World_OpenRestUI,
        World_CloseRestUI,

        World_OpenSelectFoodUI,
        World_CloseSelectFoodUI,

        World_OpenTargetSelectUI_Consumable,
        World_CloseTargetSelectUI,

        Share_OpenChangeAllyUI,

        Share_OpenChangeConsumableUI,

        World_OnRefresh�����ġ,
        World_CloseVPChange,

        World_On�����Ǿ˸�,

        World_RecommendSkill,
        World_CloseRecommendSkill,

        World_OpenCheckAdUI,
        World_CloseCheckAdUI,

        //-> ���� UI �̺�Ʈ
        Share_OnCloseSkillTab,
        Share_OnCloseStatusTab,

        Share_OpenSkillTab,
        Share_OpenSkillTabWithFocus,
        Share_CloseSkillTab,
        Share_OpenStatusTab,
        Share_CloseStatusTab,

        Share_OpenChoiceRewardUI,
        Share_OpenChoiceRewardUI_WithCardBundle,
        Share_CloseChoiceRewardUI,

        Share_OpenCombatRewardUI,
        Share_CloseCombatRewardUI,

        Share_OpenUnlockUI,
        Share_CloseUnlockUI,

        Share_OpenRandomEventUI,
        Share_CloseRandomEventUI,

        Share_OpenScoreUI,
        Share_CloseScoreUI,

        Share_OpenSettingUI,
        Share_CloseSettingUI,
        Share_OpenHelpUI,
        Share_CloseHelpUI,
        Share_Open����UI,
        Share_Close����UI,

        Share_ĳ�����ʻ�ȭ����,
        Share_��ġ����,

        Share_OpenYesNoPopUp,   //��,�ƴϿ� ����
        Share_CloseYesNoPopUp,
        Share_OpenNoticePopUp,  //Ȯ�θ� ����
        Share_CloseNoticePopUp,

        Share_OpenPurchasePopUp,   //��,�ƴϿ� ����
        Share_ClosePurchasePopUp,

        Share_NetworkError,     //��Ʈ��ũ ����
        Share_AbnormalAccessDetected,   //���������� ����
        Share_ErrorGenerated,   //���� �߻�

        //-> �������̱� �̺�Ʈ
        ToolTipShow_Reward,     // <- Data_Reward
        ToolTipShow_Skill,      // <- SkillID
        ToolTipShow_SkillInfo,  // <- SkillID
        ToolTipShow_Effect,     // <- EffectID
        ToolTipShow_Artifact,   // <- ArtifactID
        ToolTipShow_Consumable, // <- ConsumableID
        ToolTipShow_Character,  // <- Data_Character
        ToolTipShow_Ally,       // <- CharacterID
        ToolTipShow_Tile,       // <- TileType
        ToolTipShow_Achievement,  // <- Achievement
        ToolTipShow,             // <- Data_Tooltip

        ToolTipHide_Current,

        //-> �˾� �̺�Ʈ
        PopUpOpen_LegacyUnlock,     // <- ������� �ر�
        PopUpOpen_LegacyExlore,     // <- ������� Ž��

        PopUpClose_Current,

        //-> �۷ι� UI �̺�Ʈ
        Global_�Է�����,
        Global_�Է���������,

        Global_��Ʈ��ũ���,
        Global_��Ʈ��ũ�������,

        Global_����,
        Global_��������,
        Global_�����������,
        Global_�����ð����Ⱦ���,

        Global_ShowMsg,
        Global_ShowMsg_Error,
        Global_ShowMsg_NotImplemented,

        Debug_World_DrawTileType,

        Global_OnCameraMoved,

        Global_OpenGuide,
        Global_CloseGuide,

        Global_EnqueueMiniGuide,

        Global_���̵�,
        Global_���̵����,
        Global_���̵��������,
        Global_���̵�����,

        //-> Ʃ�丮�� ���� �̺�Ʈ
        Tutorial_On������ε�,
        Tutorial_Open����Ʃ�丮��UI,

        Tutorial_On�������ε�,

        Tutorial_HideWorldUI,
        Tutorial_AppearWorldUI,

        Tutorial_OpenDiceUI_WithPreset,

        Tutorial_ShowWorld��ǳ��_�ƹ����̳���ġ������,
        Tutorial_ShowWorld��ǳ��_�ڵ�����,
        Tutorial_ShowWorld��ǳ��_���ݺ�,
        Tutorial_HideWorld��ǳ��,
        Tutorial_World�Է�����,
        Tutorial_World�Է���������,
        Tutorial_World��ưŬ�������ϱ�,

        Tutorial_ShowCombatButtle_Quen�ƹ����̳���ġ������,
        Tutorial_ShowCombatButtle_Quen�ڵ�����,
        Tutorial_ShowCombatButtle_Cube,
        Tutorial_HideCombatBubble,
        Tutorial_Combat�Է�����,
        Tutorial_Combat�Է���������,
        Tutorial_Combat��ų��밭���ϱ�,
        Tutorial_Combat��ų��밭������,
        Tutorial_Combat�׼�UI������,
        Tutorial_Combat�ൿ�����μҸ����ϱ�,
        Tutorial_Combat�ൿ�����μҸ�������,

        Tutorial_ShowGuideHand,
        Tutorial_HideGuideHand,

        //-> �κ� Ʃ�丮�� �̺�Ʈ
        Tutorial_Lobby_�����ε�,

        Tutorial_Lobby_�ƹ����̳���ġ,
        Tutorial_Lobby_����ưŬ������,

    }
}

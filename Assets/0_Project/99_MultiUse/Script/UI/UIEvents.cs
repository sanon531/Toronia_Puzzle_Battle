
namespace ToronPuzzle.Event
{

    public enum UIEventID
    {

        //-> 타이틀 UI이벤트
        Title_Open로딩UI,
        Title_Close로딩UI,

        Title_Open로그인UI,
        Title_Close로그인UI,

        Tield_Open프로필위젯,

        Title_Open캠페인모드선택UI,
        Title_Close캠페인모드선택UI,

        Title_Open캠페인설정UI,
        Title_Close캠페인설정UI,

        Title_Open로비UI,
        Title_Close로비UI,
        Title_Open로비메뉴UI,
        Title_Open상점아이템정보UI,
        Title_Close상점아이템정보UI,
        Title_On구매성공,

        Title_Open출석UI,
        Title_Open출석UI_WithCloseEvent,
        Title_Close출석UI,
        Title_Open업적UI,
        Title_Close업적UI,
        Title_Open이벤트UI,
        Title_Close이벤트UI,

        Title_Open프로필UI,
        Title_Open프로필With랭킹기록UI,
        Title_Close프로필UI,
        Title_Open프로필메뉴UI,
        Title_Close프로필메뉴UI,
        Title_Open랭킹기록UI,
        Title_Open기록UI,
        Title_Open기록점수UI,
        Title_Close기록점수UI,
        Title_Open기록선택UI,
        Title_Close기록선택UI,

        Title_Open아이콘변경UI,
        Title_아이콘변경,

        Title_Open캐릭터선택UI,
        Title_Close캐릭터선택UI,
        Title_Open시작유물선택UI,
        Title_Open시작소모품선택UI,
        Title_Close시작아이템선택UI,

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

        Title_Open시작선택,
        Title_시작선택End,

        Title_Open컷씬,
        Title_Close컷씬,

        Title_OpenUnlockGachaChoice,
        Title_OpenStuffGachaResult,

        Title_Open가챠확률UI,
        Title_Close가챠확률UI,

        Title_Refresh가챠UI,
        Title_인벤토리갱신,
        Title_On재화소모클라이언트눈속임연출,

        Global_On유물효과발동,

        //-> 전투화면 인게임UI 이벤트
        Combat_On방어도변동,

        Combat_On생명력변동,

        Combat_On효과변동,

        Combat_On캐릭터선택됨,
        Combat_On캐릭터선택끝남,

        Combat_On행동력변동,

        Combat_Show장기전연출,

        //->캠페인 데이터 변동 UI동기화
        World_On전직,

        Global_OnSP변동,
        World_On생명력변동,
        World_On스테미너변동,
        World_On금화변동,
        World_OnSP변동,
        Global_On성향수치변동,
        Global_On성향단계변동,
        Global_On유물수치변동, //이벤트로 보낸 값으로 갱신
        Global_On유물갱신, //현재 데이터 기반으로 갱신
        Global_On유물갱신_With등장연출,
        Global_On유물제거,

        Global_On소모품갱신,
        Global_On소모품갱신_With등장연출,

        //-> 전투화면 UI이벤트
        Combat_On전투씬로드,

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

        //-> 월드화면 UI이벤트
        World_On월드씬로드,
        World_On월드캐릭터로드,

        World_On시간변동,
        World_On시간한바퀴돌리기,
        World_OnTileEventEnd,

        World_전역효과변동,

        World_OpenDiceUI,
        World_CloseDiceUI,
        World_On주사위선택,
        World_On타일좌표선택,
        World_예상도착지점보이기,
        World_예상도착지점숨기기,
        World_방향선택버튼보이기,
        World_타일이미지교체,
        World_타일밤이미지보이기,
        World_타일밤이미지숨기기,
        World_TileGizmo비활성화,
        World_TileGizmo활성화,


        World_Open전직UI,
        World_Close전직UI,
        World_Open노숙UI,

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

        World_OnRefresh성향수치,
        World_CloseVPChange,

        World_On상태탭알림,

        World_RecommendSkill,
        World_CloseRecommendSkill,

        World_OpenCheckAdUI,
        World_CloseCheckAdUI,

        //-> 공용 UI 이벤트
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
        Share_Open쿠폰UI,
        Share_Close쿠폰UI,

        Share_캐릭터초상화갱신,
        Share_노치대응,

        Share_OpenYesNoPopUp,   //예,아니오 선택
        Share_CloseYesNoPopUp,
        Share_OpenNoticePopUp,  //확인만 선택
        Share_CloseNoticePopUp,

        Share_OpenPurchasePopUp,   //예,아니오 선택
        Share_ClosePurchasePopUp,

        Share_NetworkError,     //네트워크 오류
        Share_AbnormalAccessDetected,   //비정상적인 접근
        Share_ErrorGenerated,   //오류 발생

        //-> 툴팁보이기 이벤트
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

        //-> 팝업 이벤트
        PopUpOpen_LegacyUnlock,     // <- 고대유산 해금
        PopUpOpen_LegacyExlore,     // <- 고대유산 탐색

        PopUpClose_Current,

        //-> 글로벌 UI 이벤트
        Global_입력차단,
        Global_입력차단해제,

        Global_네트워크대기,
        Global_네트워크대기해제,

        Global_암전,
        Global_암전해제,
        Global_암전즉시해제,
        Global_일정시간동안암전,

        Global_ShowMsg,
        Global_ShowMsg_Error,
        Global_ShowMsg_NotImplemented,

        Debug_World_DrawTileType,

        Global_OnCameraMoved,

        Global_OpenGuide,
        Global_CloseGuide,

        Global_EnqueueMiniGuide,

        Global_씬이동,
        Global_씬이동대기,
        Global_씬이동대기해제,
        Global_씬이동차단,

        //-> 튜토리얼 전용 이벤트
        Tutorial_On월드씬로드,
        Tutorial_Open월드튜토리얼UI,

        Tutorial_On전투씬로드,

        Tutorial_HideWorldUI,
        Tutorial_AppearWorldUI,

        Tutorial_OpenDiceUI_WithPreset,

        Tutorial_ShowWorld말풍선_아무곳이나터치시진행,
        Tutorial_ShowWorld말풍선_자동진행,
        Tutorial_ShowWorld말풍선_대사반복,
        Tutorial_HideWorld말풍선,
        Tutorial_World입력차단,
        Tutorial_World입력차단해제,
        Tutorial_World버튼클릭강제하기,

        Tutorial_ShowCombatButtle_Quen아무곳이나터치시진행,
        Tutorial_ShowCombatButtle_Quen자동진행,
        Tutorial_ShowCombatButtle_Cube,
        Tutorial_HideCombatBubble,
        Tutorial_Combat입력차단,
        Tutorial_Combat입력차단해제,
        Tutorial_Combat스킬사용강제하기,
        Tutorial_Combat스킬사용강제해제,
        Tutorial_Combat액션UI딜레이,
        Tutorial_Combat행동력전부소모강제하기,
        Tutorial_Combat행동력전부소모강제해제,

        Tutorial_ShowGuideHand,
        Tutorial_HideGuideHand,

        //-> 로비 튜토리얼 이벤트
        Tutorial_Lobby_툴팁로드,

        Tutorial_Lobby_아무곳이나터치,
        Tutorial_Lobby_대상버튼클릭강제,

    }
}

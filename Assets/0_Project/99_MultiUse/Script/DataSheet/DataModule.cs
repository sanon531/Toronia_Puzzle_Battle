using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle.Data
{

    static class ModuleDic
    {
        public static Dictionary<ModuleID, Module_DataTable> ModuleTableDic
        = new Dictionary<ModuleID, Module_DataTable>()
        {
            {ModuleID.기선제압,new Module_DataTable()}

        };

        //이런 식으로 블록의 데이터를 만들고 저장한다. 모듈에 대한 배치로 여기서 함.
        public static Dictionary<ModuleID, BlockInfo> _IDModuleBlockDic =
            new Dictionary<ModuleID, BlockInfo>()
            {
                { ModuleID.기선제압,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.One_D_모듈,new Module_ActBegin(), ModuleID.기선제압,1)},
                { ModuleID.카리스마Lv1,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.Three_G_모듈,new Module_강경업글_공업_약(), ModuleID.카리스마Lv1,4)},
                { ModuleID.분석력Lv1,
                    new BlockInfo(BlockElement.Cynical,BlockShape.Three_G_모듈,new Module_냉소업글_방업_약(), ModuleID.분석력Lv1,4)},
                { ModuleID.책임감Lv1,
                    new BlockInfo(BlockElement.Friendly,BlockShape.Three_G_모듈,new Module_우호업글_균형_약(),ModuleID.책임감Lv1,4)},
                { ModuleID.쇄빙,
                    new BlockInfo(BlockElement.Cynical,BlockShape.Three_G_쇄빙,new Module_쇄빙(), ModuleID.쇄빙,3)},
                { ModuleID.현란한_임기응변,
                    new BlockInfo(BlockElement.Friendly,BlockShape.Two_VL_모듈,new Module_현란한임기응변(), ModuleID.현란한_임기응변,6)},
                { ModuleID.개미지옥 ,
                    new BlockInfo(BlockElement.Friendly,BlockShape.Four_AG_개미지옥,new Module_개미지옥(), ModuleID.개미지옥,6)},
                { ModuleID.승화,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.Three_G_쇄빙,new Module_승화(), ModuleID.승화,6)}

            };

        public static Dictionary<ModuleID,ModuleInfo > _IDModuleDic =
          new Dictionary<ModuleID, ModuleInfo>()
          {
                { ModuleID.기선제압,
                    new Module_ActBegin()},
                { ModuleID.카리스마Lv1,
                    new Module_강경업글_공업_약()},
                { ModuleID.분석력Lv1,
                    new Module_냉소업글_방업_약()},
                { ModuleID.책임감Lv1,
                    new Module_우호업글_균형_약()},
                { ModuleID.쇄빙,
                    new Module_쇄빙()},
                { ModuleID.현란한_임기응변,
                    new Module_현란한임기응변()},
                { ModuleID.개미지옥 ,
                  new Module_개미지옥() },
                { ModuleID.승화 ,
                  new Module_승화() },


          };


        public static Dictionary<ModuleID, string> _module_devcomment = new Dictionary<ModuleID, string>()
            {
                {ModuleID.카리스마Lv1,
                    "백금으로 만든 월계관이자, \n" +
                    "마주한 이에게 내려찍는 말없는 협상 \n" +
                    " - 총독의 미덕에 대하여" },
                {ModuleID.분석력Lv1,
                    "이성적 사고의 기본은 한 이야기를 들었을때 \n" +
                    "감정을 토해내기 보다 논리를 적용하는 것에 있다. \n" +
                    " - 생각아 놀자 1장 서두" },
                {ModuleID.책임감Lv1,
                    "책임감은 권리의 삯이자 세계를 떠받히는 가장 작은 돌이로다 .\n" +
                    " - 율람복음 3장 14절" },
                {ModuleID.쇄빙,
                    "고래도 개미도 세포는 평등하며 \n" +
                    "태양도 터럭도 같은 원자로 이루어 졌듯. \n"+
                    "크기에 압도되었을 때는 그것을 해체하라. \n" +
                    "논리는 가장 위대한 메스일지니 \n" +
                    " - 자인 아르록,파괴 변증법 p.42"},
                { ModuleID.카리스마Lv2,
                    "고개를 숙이는 것은 비참하고 증오를 부르는 일일텐테 \n" +
                    "어째서 그 어떠한 선택보다도 나의 힘줄을 잡아 끄는걸까." },

                { ModuleID.현란한_임기응변,
                    "날카로운 칼로 수십 번 잘라내고 바느질로 수천번 꼬매었음에도\n" +
                    "마치 거미의 그것처럼 흔적 하나 없는 듯하구나. \n" +
                    " - 천하만람기, 우르 파피루스에 대한 글" },
                { ModuleID.개미지옥,
                    "이곳을 생각을 했다면 이미 들이게 된 것이고 \n" +
                    "들이게된 순간 이미 발버둥 칠 수도 없는 것이다\n" +
                    " - 도금된 무채색의 도시에서 " },
                { ModuleID.승화,
                    "아무리 식히고자 하더라도 명치 밑에서 수천번 단조질해대는 \n" +
                    "분노는 그대들의 역겹게 꿈틀대는 혀들의 벽을 불태워버릴 것이요 \n" +
                    " - 파괴의 칸의 8개조 포고문 " }


            };

        public static Dictionary<ModuleID, string> _module_skillExplain =
            new Dictionary<ModuleID, string>()
            {
                {ModuleID.카리스마Lv1,
                    "<sprite=0> 블록의 공격력을 약간 올립니다." },
                {ModuleID.분석력Lv1,
                    "<sprite=1> 블록의 방어력을 약간 올립니다." },
                {ModuleID.책임감Lv1,
                    "<sprite=2> 블록의 공격력 방어력을 약간 올립니다." },
                { ModuleID.쇄빙,
                    "<sprite=1> 블록의 공격력을 약간 올립니다.\n"+
                    "모듈의 발동 구역에 배치된 1개 이상의 <sprite=1> 블록들을\n" +
                    " 1x1 <sprite=1> 블록들로 재생성합니다." },
                { ModuleID.현란한_임기응변,
                    "모듈의 배치를 배틀 중에도 변경할 수 있게 됩니다."
                },
                { ModuleID.개미지옥,
                    "강력한 <sprite=2> 블록 추가 보너스를 얻게 됩니다. \n" +
                    "대신 특정 구간에 블럭을 놓을 경우 해당 블록공격력 * 10 데미지를 받게 됩니다." },
                { ModuleID.승화,
                    "<sprite=0>  블럭이 설치될경우 즉시 파괴하고 적에게 \n" +
                    "해당 블럭 값만큼의 데미지로 환산합니다. "}

            };





    }
}
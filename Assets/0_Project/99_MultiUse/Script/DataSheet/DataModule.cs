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
                    new BlockInfo(BlockElement.Aggressive,BlockShape.Three_G_쇄빙,new Module_승화(), ModuleID.승화,6)},
                { ModuleID.충동 ,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.One_D_모듈,new Module_ActBegin(), ModuleID.충동,1)},
                { ModuleID.착취 ,
                    new BlockInfo(BlockElement.Aggressive,BlockShape.One_D_모듈,new Module_ActBegin(), ModuleID.착취,1)},


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
                { ModuleID.충동 ,
                  new Module_ActBegin() },
                { ModuleID.착취 ,
                  new Module_ActBegin() },


          };


        public static Dictionary<ModuleID, string> _module_devcomment = new Dictionary<ModuleID, string>()
            {

                //기선제압
                {ModuleID.기선제압,
                    "시작이 반이란 것은 거짓이다. 고작해야 1% 정도? \n" +
                    "그러나 눈덩이 처럼 불어나는 눈사태의 시작이라면 능히 90%는 \n" +
                    "넘기지 않겠는가? \n" +
                    " - 총독의 미덕에 대하여" },


                //카리스마
                {ModuleID.카리스마Lv1,
                    "백금으로 만든 월계관이자, \n" +
                    "마주한 이에게 <red>내려찍는</red> 말없는 협상 \n" +
                    " - 총독의 미덕에 대하여" },
                { ModuleID.카리스마Lv2,
                    "고개를 숙이는 것은 비참하고 증오를 부르는 일일텐테 \n" +
                    "어째서 그 어떠한 선택보다도 나의 힘줄을 잡아 끄는걸까." },

                //분석력
                {ModuleID.분석력Lv1,
                    "이성적 사고의 기본은 한 이야기를 들었을때 \n" +
                    "감정을 토해내기 보다 논리를 적용하는 것에 있다. \n" +
                    " - 생각아 놀자 1장 서두" },
                //책임감
                {ModuleID.책임감Lv1,
                    "책임감은 권리의 삯이자 세계를 떠받히는 가장 작은 돌이로다 .\n" +
                    " - 율람복음 3장 14절" },
                //쇄빙
                {ModuleID.쇄빙,
                    "고래도 개미도 세포는 평등하며 \n" +
                    "태양도 터럭도 같은 원자로 이루어 졌듯. \n"+
                    "크기에 압도되었을 때는 그것을 <blue>해체</blue>하라. \n" +
                    "<blue>논리</blue>는 가장 위대한 메스일지니 \n" +
                    " - <blue>자인 아르록,파괴 변증법 p.42</blue>"},

                //무자비
                {ModuleID.무자비,
                    "낙숫물이 바위를 뚫는다라 \n" +
                    "재질이 납으로 바뀐다면 찰나에 끝나지 않겠나?\n" +
                    " - <blue> 휴전 협정에 반하여 - 파괴의 칸</blue>"},

                //현란한 임기응변
                { ModuleID.현란한_임기응변,
                    "날카로운 칼로 수십 번 잘라내고 바느질로 수천번 꼬매었음에도\n" +
                    "마치 거미의 그것처럼 흔적 하나 없는 듯하구나. \n" +
                    " - 천하만람기, 우르 파피루스에 대한 글" },
                //개미지옥
                { ModuleID.개미지옥,
                    "이곳을 생각을 했다면 이미 들이게 된 것이고 \n" +
                    "들이게된 순간 이미 발버둥 칠 수도 없는 것이다\n" +
                    " - 도금된 무채색의 도시에서 " },
                //승화
                { ModuleID.승화,
                    "아무리 수천번 벼려진 <blue>철</blue>에서도 단단히 여미어진 <yellow>땅</yellow>에서도 \n" +
                    "<red>태양 볕</red>은 그녀를 녹슬이고 그를 갈라버린다.\n" +
                    " - 창조파 속담 " },
                //충동
                { ModuleID.충동,
                    "<blue>파괴</blue>의 사상은 곧 <blue>충돌</blue>의 사상이라! \n" +
                    "모든 것들은 우주의 천체 마냥 이리저리 움직이면서 <blue>부딪힐</blue> 수 밖에 없게되며 \n" +
                    "집단은 그들의 방향과 크기로 이루어진 벡터로써 태어난 이유를 완성시켜야한다. \n" +
                    "이는 인력이요 능력이자 본능이다.  \n"+
                    " - 충동의 어록.p1 - 파괴의 칸 할라 다이샨 " },
                //충동
                { ModuleID.착취,
                    "착취가 악인가? 단지 저들의 것을 뺏어서 우리의 배를 불렸다고 욕하는 것인가?  \n" +
                    "저들은 무엇 하나 산출해내지 못하는 머저리들로 어떠한 진보도 이뤄내지못하는 황충들이며 \n" +
                    "길거리 광인의 지꺼림마냥 공허하고 무가치 하다. 우리는 그들로부터 '간접적'으로 학대받는  \n" +
                    "전 인류의 피해를 보상해줄 유일한 존재로서 저들의 '나태'에 대항한 것일 뿐이다.\n"+
                    " - 이식주의의 여명 - 박거상 " },


                //공허한 지껄임
                {ModuleID.공허한_지껄임,
                    "최고의 지성들이 수십개의 단어를 엮고 꼬아서 만든 것은 \n " +
                    "그저 더 많은 유예를 위한 도화선이었을 뿐 \n " +
                    " - 총회 장악 후 실종된 의원의 마지막 글"
                },
                //꼬리무는 순환 논증
                {ModuleID.꼬리무는_순환논증,
                    "그러니 물리법칙으로부터 자유로울 수 있는 이 방식은..  \n "
                },
                {ModuleID.흑백논리,
                    "세상에 중간은 없어 회색은 가장 나쁜 색이다고 \n "+
                    "극단이야말로 최고의 힘이지 약간이라도 타협하는 순간 저 새끼들한테 지는거야 알겠어? \n " +
                    " - 선동록"
                },

                {ModuleID.양자역학적_결론,
                    "세상에는 '그렇죠 아무렴요' 라는 소리를 되내면서 사람의 기분을 슬슬긁는 \n "+
                    "관측 하기전 까지 결론이 안나는 말로 엿먹이는 참신한 새끼들이 존재한다 \n " +
                    "내가 야만인이었다면 이미 뚝배기를 깨버렸을텐데 말야 - 의적 까오 반탕 "
                },
                {ModuleID.성급한_일반화,
                    "그러니까 노랗기만 하면 전부 금이란 말이죠?  \n "+
                    "지금 제가 때려서 시퍼렇게 멍들었으니 당신은 오늘부터 블루베리입니다. \n " +
                    " - 대변가 적역 "
                }


                // 숙청 : 다이샨 도대체 왜 내가 죽어야 하는거지? 탑을 쌓고도 모자랐나? - 자인 아르록 
                // 선택적 망각 : 웃기군 힘줄이 보일 정도로 고래고래 주장하던 자들이 이젠 그의 정반대를 저리 열성 적으로 외치고 있다는 것이
                //  : 우리가 공민주의를 주장하는 이유는 당신들이 생각하는 것처럼 순진한게 아닙니다. 
                //  인간은 악하며 고통 속에서 상식을 벗어난 행동을 저지르고 자신을 합리화하나
                //  남의 일에 대해서는 괴상하리만큼 위선적으로 깐깐한 정의를 주장하기 때문입니다.
                //  그 말은 적어도 최소한의 안정도를 가진 시민 사회를 만들 수 있다면 사회적 정의는 영원히 존속 될 수 있습니다.
                //  민공주의는 그 정의를 그것을 통해 올바름에 가장 가까이 다가갈 수 있는것입니다.
                               
            };

        public static Dictionary<ModuleID, string> _module_skillExplain =
            new Dictionary<ModuleID, string>()
            {
                {ModuleID.카리스마Lv1,
                    "<sprite=0> <red>블록</red>의 <red>공격력</red>을 약간 올립니다." },
                {ModuleID.분석력Lv1,
                    "<sprite=1> <blue>블록</blue>의 <blue>방어력</blue>을 약간 올립니다." },
                {ModuleID.책임감Lv1,
                    "<sprite=2> 블록의 공격력 방어력을 약간 올립니다." },
                { ModuleID.쇄빙,
                    "<sprite=1> <blue>블록</blue>의 <red>공격력</red>을 약간 올립니다.\n"+
                    "모듈의 발동 구역에 배치된 1개 이상의 <sprite=1> <blue>블록</blue>들을\n" +
                    " 1x1 <sprite=1> <blue>블록들</blue>로 재생성합니다." },
                { ModuleID.현란한_임기응변,
                    "모듈의 배치를 배틀 중에도 변경할 수 있게 됩니다."
                },
                { ModuleID.개미지옥,
                    "강력한 <sprite=2> 블록 추가 보너스를 얻게 됩니다. \n" +
                    "대신 특정 구간에 블럭을 놓을 경우 해당 블록공격력 * 10 데미지를 받게 됩니다." },
                { ModuleID.무자비,
                    "모든 블록을 채웠을 경우 데미지가 1.5배가 됩니다. \n" +
                    "대신 빈공간이 있는 채로 제출 할 경우 데미지가 반감 됩니다." },
                { ModuleID.승화,
                    "<sprite=0>  블럭이 설치될경우 즉시 파괴하고 적에게 \n" +
                    "해당 블럭 값만큼의 데미지로 환산합니다. "},

                { ModuleID.충동,
                    "파괴 블록과 관련된 기술 삽입 예정" },
                { ModuleID.착취,
                    "강경 블록과 관련된 기술 삽입 예정" },
                { ModuleID.공허한_지껄임,
                    "이번 턴동안 모든 데미지를 무시합니다." },


            };





    }
}
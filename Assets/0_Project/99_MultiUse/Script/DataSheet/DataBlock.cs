using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle.Data
{



    public enum BlockShape
    {
        One_D,
        Two_H, Two_V,
        Three_V, Three_H, Three_G, Three_AG,
        Four_D, Four_V, Four_S, Four_AS, Four_T, Four_G, Four_AG,




        Full_Four_Six,
        UnDefined

    }
    static class BlockShapePool
    {
        public static Dictionary<BlockShape, int[,]> shapeDic = new Dictionary<BlockShape, int[,]>()
    {
        //가로 직선은 V, 세로 직선은 H, 기역자는 G, 역기역자는 AG
        //점 또는 네모는 D, T자는 T, 십자가는 C, 소문자b 형은 b , 소문자 d형은 d , 
        //번개 모양은 S, 반대 번개 모양은 AS

        {BlockShape.One_D, new int[,]{ {1} } },
        {BlockShape.Two_H, new int[,]{ {1,1}}},
        {BlockShape.Two_V, new int[,]{ {1},{1} }},
        {BlockShape.Three_H, new int[,]{ {1,1,1} }},
        {BlockShape.Three_V, new int[,]{ { 1 },{ 1 },{ 1 } }},
        {BlockShape.Three_G, new int[,]{ { 1,1 },{ 0,1 } }},
        {BlockShape.Three_AG, new int[,]{ { 1,1 },{ 1,0 } }},
        {BlockShape.Four_D, new int[,]{ { 1,1 },{ 1,1 } }},
        {BlockShape.Four_V, new int[,]{ { 1,1,1,1 } }},
        {BlockShape.Four_S, new int[,]{ { 1,1,0 },{0,1,1 } }},
        {BlockShape.Four_AS, new int[,]{ { 0,1,1 },{1,1,0 }}},
        {BlockShape.Four_T, new int[,]{ { 1, 1, 1 },{ 0,1,0 }}},
        {BlockShape.Four_G, new int[,]{ { 1,1,1 },{0,0,1 }}},
        {BlockShape.Four_AG, new int[,]{ { 1,1,1 },{1,0,0 }}},
        {BlockShape.Full_Four_Six, new int[,]{ { 1,1,1,1 },{ 1,1,1,1 },{ 1,1,1,1 },{ 1,1,1,1 },{ 1,1,1,1 },{ 1,1,1,1 },}},





    };


    }

    static class BlockPool
    {
        public static StringBlockInfoDictionary ExampleBlock = new StringBlockInfoDictionary()
        { };
        public static List<BlockInfo> TestBlocks = new List<BlockInfo>()
        {
            new BlockInfo(BlockElement.Aggressive, BlockShape.One_D,new Vector2Int(1,1)),
            new BlockInfo(BlockElement.Cynical, BlockShape.One_D,new Vector2Int(1,2)),

        };

    }



}

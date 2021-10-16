using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle.Data
{



    public enum ShapeEnum
    {
        One_D,
        Two_H, Two_V,
        Three_V, Three_H, Three_G, Three_AG,
        Four_D, Four_V, Four_S, Four_AS, Four_T, Four_G, Four_AG,
        UnDefined

    }
    static class BlockShapePool
    {
        public static Dictionary<ShapeEnum, int[,]> shapeDic = new Dictionary<ShapeEnum, int[,]>()
    {
        //가로 직선은 V, 세로 직선은 H, 기역자는 G, 역기역자는 AG
        //점 또는 네모는 D, T자는 T, 십자가는 C, 소문자b 형은 b , 소문자 d형은 d , 
        //번개 모양은 S, 반대 번개 모양은 AS

        {ShapeEnum.One_D, new int[,]{ {1} } },
        {ShapeEnum.Two_H, new int[,]{ {1,1}}},
        {ShapeEnum.Two_V, new int[,]{ {1},{1} }},
        {ShapeEnum.Three_H, new int[,]{ {1,1,1} }},
        {ShapeEnum.Three_V, new int[,]{ { 1 },{ 1 },{ 1 } }},
        {ShapeEnum.Three_G, new int[,]{ { 1,1 },{ 0,1 } }},
        {ShapeEnum.Three_AG, new int[,]{ { 1,1 },{ 1,0 } }},
        {ShapeEnum.Four_D, new int[,]{ { 1,1 },{ 1,1 } }},
        {ShapeEnum.Four_V, new int[,]{ { 1,1,1,1 } }},
        {ShapeEnum.Four_S, new int[,]{ { 1,1,0 },{0,1,1 } }},
        {ShapeEnum.Four_AS, new int[,]{ { 0,1,1 },{1,1,0 }}},
        {ShapeEnum.Four_T, new int[,]{ { 1, 1, 1 },{ 0,1,0 }}},
        {ShapeEnum.Four_G, new int[,]{ { 1,1,1 },{0,0,1 }}},
        {ShapeEnum.Four_AG, new int[,]{ { 1,1,1 },{1,0,0 }}},





    };


    }

    static class BlockPool
    {
        public static StringBlockInfoDictionary ExampleBlock = new StringBlockInfoDictionary()
        { };
        public static List<BlockInfo> TestBlocks = new List<BlockInfo>()
        {
            new BlockInfo(BlockElement.Aggressive, ShapeEnum.One_D,new Vector2Int(1,1)),
            new BlockInfo(BlockElement.Cynical, ShapeEnum.One_D,new Vector2Int(1,2)),

        };

    }



}

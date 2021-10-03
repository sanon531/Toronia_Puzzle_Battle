using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ToronPuzzle.Data
{
    public enum PlacingCaseSkin
    {
        Normal
    }
    public enum PlacingCellSkin
    {
        Normal, Burning, Glitch, Shielded
    }

    static class SkinDic
    {
        public static Dictionary<PlacingCaseSkin, string> SkinToStringDic = new Dictionary<PlacingCaseSkin, string>()
        {
            { PlacingCaseSkin.Normal,"asd"}
        };

    }


}
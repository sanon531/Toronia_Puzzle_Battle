using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ToronPuzzle.Data
{
    public static class CameraAimData
    {
        public static Dictionary<CameraAimName, CameraAimInfo> aimInfos = new Dictionary<CameraAimName, CameraAimInfo>()
    {
        { CameraAimName.Aim_Player,new CameraAimInfo(new Vector2 (0f,  1f),5f) },
        { CameraAimName.Aim_Player_Zoom_Little,new CameraAimInfo(new Vector2 (-1f,2f),4f)},
        { CameraAimName.Aim_Player_Zoom_Middle,new CameraAimInfo(new Vector2 (-1.45f,3f),3f) },
        { CameraAimName.Aim_Player_Zoom_Big,new CameraAimInfo(new Vector2 (-2f,4f),2f) },
        { CameraAimName.Aim_Enemy,new CameraAimInfo(new Vector2 (2f,1f),5f)},
        { CameraAimName.Aim_Enemy_Zoom_Little,new CameraAimInfo(new Vector2 (3f,2f),4f) },
        { CameraAimName.Aim_Enemy_Zoom_Middle,new CameraAimInfo(new Vector2 (3.5f,3f),3f) },
        { CameraAimName.Aim_Enemy_Zoom_Big,new CameraAimInfo(new Vector2 (3.5f,4f),2f)}
    };


    }

    public enum CameraAimName
    {
        Aim_Player,
        Aim_Player_Zoom_Little,
        Aim_Player_Zoom_Middle,
        Aim_Player_Zoom_Big,
        Aim_Enemy,
        Aim_Enemy_Zoom_Little,
        Aim_Enemy_Zoom_Middle,
        Aim_Enemy_Zoom_Big,

    }
    public struct CameraAimInfo
    {
        public Vector2 targetPos;
        public float CameraZoomSize;

        public CameraAimInfo(Vector2 target)
        {
            targetPos = target;
            CameraZoomSize = 5f;
        }
        public CameraAimInfo(Vector2 arg_Target, float arg_zoomSize)
        {
            targetPos = arg_Target;
            CameraZoomSize = arg_zoomSize;
        }


    }
}
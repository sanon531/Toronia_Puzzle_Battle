using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ToronPuzzle.Data
{
    public static class CameraAimData
    {
        public static Dictionary<CameraAimEnum, CameraAimInfo> aimInfos = new Dictionary<CameraAimEnum, CameraAimInfo>()
        {
            { CameraAimEnum.Aim_Player,new CameraAimInfo(new Vector2 (0f,  1f),5f) },
            { CameraAimEnum.Aim_Player_Zoom_Little,new CameraAimInfo(new Vector2 (-1f,2f),4f)},
        { CameraAimEnum.Aim_Player_Zoom_Middle,new CameraAimInfo(new Vector2 (-1.45f,3f),3f) },
        { CameraAimEnum.Aim_Player_Zoom_Big,new CameraAimInfo(new Vector2 (-2f,4f),2f) },
        { CameraAimEnum.Aim_Enemy,new CameraAimInfo(new Vector2 (2f,1f),5f)},
        { CameraAimEnum.Aim_Enemy_Zoom_Little,new CameraAimInfo(new Vector2 (3f,2f),4f) },
        { CameraAimEnum.Aim_Enemy_Zoom_Middle,new CameraAimInfo(new Vector2 (3.5f,3f),3f) },
        { CameraAimEnum.Aim_Enemy_Zoom_Big,new CameraAimInfo(new Vector2 (3.5f,4f),2f)}
        };

        public static Dictionary<CameraAimEnum, WorldMoveInfo> movInfos = new Dictionary<CameraAimEnum, WorldMoveInfo>()
                    {
        { CameraAimEnum.Aim_Player,
                new WorldMoveInfo(new Vector2(0f,  0f),1f) },
        { CameraAimEnum.Aim_Player_Zoom_Little,
                new WorldMoveInfo(new Vector2(1.35f,-1f),1.2f)},
        { CameraAimEnum.Aim_Player_Zoom_Middle,
                new WorldMoveInfo(new Vector2(2.5f,-3f),1.5f) },
        { CameraAimEnum.Aim_Player_Zoom_Big,
                new WorldMoveInfo(new Vector2(4f,-6f),2f) },
        { CameraAimEnum.Aim_Enemy,
                new WorldMoveInfo(new Vector2(-0.5f,0f),1f)},
        { CameraAimEnum.Aim_Enemy_Zoom_Little,
                new WorldMoveInfo(new Vector2(-3.35f,-1f),1.2f) },
        { CameraAimEnum.Aim_Enemy_Zoom_Middle,
                new WorldMoveInfo(new Vector2(-5f,-3f),1.5f) },
        { CameraAimEnum.Aim_Enemy_Zoom_Big,
                new WorldMoveInfo(new Vector2(-7.5f,-6f),2f)}
        };


    };


}

public enum CameraAimEnum
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

public struct WorldMoveInfo
{
    public Vector2 targetPos;
    public float ZoomSize;

    public WorldMoveInfo(Vector2 target)
    {
        targetPos = target;
        ZoomSize = 1f;
    }
    public WorldMoveInfo(Vector2 arg_Target, float arg_zoomSize)
    {
        targetPos = arg_Target;
        ZoomSize = arg_zoomSize;
    }
}


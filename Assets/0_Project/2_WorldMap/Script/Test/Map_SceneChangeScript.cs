using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToronPuzzle.Event;
using ToronPuzzle.Data;

namespace ToronPuzzle.WorldMap
{
    public class Map_SceneChangeScript : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => OnClick());
        }
        void OnClick()
        {
            Global_UIEventSystem.Call_UIEvent<SceneType>(UIEventID.Global_æ¿¿Ãµø, SceneType.Battle);
        }

    }

}

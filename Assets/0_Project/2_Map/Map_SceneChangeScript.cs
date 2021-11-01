using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToronPuzzle.Event;
namespace ToronPuzzle.Map
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

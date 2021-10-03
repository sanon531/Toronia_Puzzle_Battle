using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle.Battle
{
    public class Battle_DragDropManager : MonoBehaviour
    {
        // Update is called once per frame
        bool IsPressed;

        void Update()
        {

            if (Input.GetMouseButtonDown(0))
                OnClicked();




            if (IsPressed)
            {
                HoveringOnClick();
            }
        }

        void OnClicked()
        {
            Instantiate(Resources.Load("Debug/Dot") as GameObject, Input.mousePosition,Quaternion.identity,transform);

        }


        void HoveringOnClick()
        {


        }

    }

}

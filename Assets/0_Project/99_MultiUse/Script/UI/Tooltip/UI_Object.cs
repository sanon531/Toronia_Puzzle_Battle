using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle.UI
{
    public class UI_Object : MonoBehaviour
    {
        public virtual void SetActive(bool on)
        {
            gameObject.SetActive(on);
        }
    }

    public interface IGameListenerUI
    {
        void AssignGameListener();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace ToronPuzzle.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        protected List<UI_Object> uI_Objects = new List<UI_Object>();

        //여기서 저장된 것들의 선언들을 불러온다. 
        public virtual void BeginUIManager()
        {
            foreach (UI_Object _Object in uI_Objects)
            {
                _Object.gameObject.GetComponent<IGameListenerUI>().AssignGameListener();
            }

        }


    }

}


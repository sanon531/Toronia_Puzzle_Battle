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
        private Dictionary<string, UI_Object> _dictionary;

        //여기서 저장된 것들의 선언들을 불러온다. 
        public virtual void BeginUIManager()
        {
            _dictionary = uI_Objects
                .ToDictionary(v => v.name, v => v);
        }

        public UI_Object Get(string val)
        {
            return _dictionary[val];
        }
        public T Get<T>(string val) where T : UI_Object
        {
            return _dictionary[val] as T;
        }

    }

}


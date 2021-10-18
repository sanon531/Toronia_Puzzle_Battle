using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;

namespace ToronPuzzle.Battle
{
    public class Battle_BackgroundPlacer : MonoBehaviour
    {

        public static Battle_BackgroundPlacer Instance;
        public BackgroundObjectDictionary _currentBGDic;

        public void BeginBackgound(BGImageKind _bGkind)
        {
            Instance = this;

            foreach (KeyValuePair< BGImageKind ,GameObject> pair in _currentBGDic)
            {
                if (pair.Key == _bGkind)
                    pair.Value.SetActive(true);
                else
                    pair.Value.SetActive(false);

            }

        }

    }

}

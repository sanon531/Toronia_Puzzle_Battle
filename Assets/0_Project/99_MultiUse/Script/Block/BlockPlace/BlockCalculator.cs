using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ToronPuzzle
{
    public class BlockCalculator : MonoBehaviour
    {
        public List<GameObject> _bonusXColumnLines = new List<GameObject>();
        public List<GameObject> _bonusYRowLines = new List<GameObject>();

        [SerializeField]
        protected List<int> _filledLineX = new List<int>();
        [SerializeField]
        protected List<int> _filledLineY = new List<int>();
        public GameObject _perfectSetting;
        public Vector2 _fullFXpos = new Vector2();
        public ElementVectorDictionary _currentElementValue;

        public virtual void BeginBlockcCalculaor()
        {


        }
        public virtual void CalcPannelData(List<BlockInfo> _argBlockInfos) { }
        public virtual void CalcBonusLine(int[,] _arg_Arr) { }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle.Battle
{
    // �ӽ÷� �ۼ��ص� UI��ġ �ǵ���. ���̸� ���� ����ϼ��� ������.
    public class Battle_UI_AnchorHolder : MonoBehaviour
    {
        public GameObject LDAchor;
        public GameObject RUAchor;
      
        // Start is called before the first frame update
        void Awake()
        {
            Master_Battle.CanvasData.LDAchorPos= LDAchor.transform.position;
            Master_Battle.CanvasData.RUAchorPos = RUAchor.transform.position;
            Master_Battle.CanvasData._screenWorldSize = RUAchor.transform.position - LDAchor.transform.position;

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

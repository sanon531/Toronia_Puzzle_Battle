using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle.Battle
{

    public class Battle_CollisionReturn : MonoBehaviour
    {

        public void BeginCollisionReturn(Vector2 _sizeDelta)
        {
            RectTransform _rect = gameObject.GetComponent<RectTransform>();
            _rect.sizeDelta = _sizeDelta;
            _rect.anchoredPosition = isSpawn ? new Vector2(-_sizeDelta.x,0) : new Vector2(_sizeDelta.x,0);

        }

        [SerializeField]
        bool isSpawn = true;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.name);
            if (collision.gameObject.GetComponent<Battle_Conveyer_Case>() == null)
                return;

            if (isSpawn)
                Battle_ConveyerManager.instance.SetBlockOnConveyer(collision.gameObject.GetComponent<Battle_Conveyer_Case>());
            else
            {
                //지우는 케이스가 블록 케이스든거랑 동일 한거면 오리진 케이스를 지움.
                Battle_ConveyerManager.instance.DeleteBlockOnConveyer(collision.gameObject.GetComponent<Battle_Conveyer_Case>());
            }

        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    public class SelfDestructCode : MonoBehaviour
    {
        [SerializeField]
        private float _destoyTime = 2f;
        // Start is called before the first frame update
        void OnEnable()
        {
            Global_CoroutineManager.Run(DelayedDestroyCode());
        }


        IEnumerator DelayedDestroyCode()
        {
            yield return new WaitForSeconds(_destoyTime);
            Destroy(gameObject);
        }

    }
}
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
        Coroutine coroutine;
        void OnEnable()
        {
            coroutine = Global_CoroutineManager.Run(DelayedDestroyCode());
        }
        private void OnDestroy()
        {
            Global_CoroutineManager.Stop(coroutine);
        }

        IEnumerator DelayedDestroyCode()
        {
            yield return new WaitForSeconds(_destoyTime);
            if(gameObject)
                Destroy(gameObject);
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ToronPuzzle
{

    public class Global_CoroutineManager : MonoBehaviour
    {
        public static Global_CoroutineManager Instance;

        public void BeginCoroutineManager()
        {
            Instance = this;
        }


        public static Coroutine Run(IEnumerator routine)
        {
            return Instance.StartCoroutine(routine);
        }

        public static void InvokeDelay(UnityAction function, float delayTime)
        {
            Instance.StartCoroutine(DelayRoutine());

            IEnumerator DelayRoutine()
            {
                if (delayTime > 0)
                {
                    yield return new WaitForSeconds(delayTime);
                }
                else
                {
                    yield return null;  //�������Ӹ� ��ŵ�ϰ������ ������ Ÿ�� 0�� ��� ����
                }
                function?.Invoke();
            }
        }


        public static void Stop(Coroutine coroutine)
        {
            Debug.Log("StopCoroutine");
            Instance.StopCoroutine(coroutine);
        }

    }

}

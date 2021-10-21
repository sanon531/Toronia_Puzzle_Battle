using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToronPuzzle
{
    public class Global_PauseManager : MonoBehaviour
    {
        public void PauseGame()
        {

        }


        /// <summary>
        /// 모든 계산이 종료된 뒤에야 정지함으로 오류를 줄임
        /// </summary>
        /// <returns></returns>
        IEnumerator PauseWhenEnd()
        {
            yield return new WaitForEndOfFrame();
            
        }

    }
}

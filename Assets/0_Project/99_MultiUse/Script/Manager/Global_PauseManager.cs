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
        /// ��� ����� ����� �ڿ��� ���������� ������ ����
        /// </summary>
        /// <returns></returns>
        IEnumerator PauseWhenEnd()
        {
            yield return new WaitForEndOfFrame();
            
        }

    }
}

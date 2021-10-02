using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Data;
using ToronPuzzle.Event;

namespace ToronPuzzle.Battle
{
    public class Master_BlockPlace : MonoBehaviour
    {
        [SerializeField] GameObject _placingCase;
        [SerializeField] Vector2 _screenSize;
        private void Awake()
        {
            _screenSize = new Vector2( Screen.width / 100, Screen.height / 100);
            transform.position = new Vector2(-_screenSize.x, -_screenSize.y);

        }

        private

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

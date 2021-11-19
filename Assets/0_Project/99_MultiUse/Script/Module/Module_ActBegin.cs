using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Event;
namespace ToronPuzzle.Data
{

    public class Module_ActBegin : ModuleInfo
    {
        protected override void Enable()
        {
            base.Enable();

        }
        protected override void Disable()
        {
            base.Disable();
        }
        private void Effect()
        {

        }
    }

    public class Module_현란한임기응변 : ModuleInfo
    {
        protected override void Enable()
        {
            base.Enable();
            Global_InWorldEventSystem.CallOn모듈항상들기(true);
        }
        protected override void Disable()
        {
            base.Disable();
            Global_InWorldEventSystem.CallOn모듈항상들기(false);
        }
        private void Effect()
        {

        }

    }


}

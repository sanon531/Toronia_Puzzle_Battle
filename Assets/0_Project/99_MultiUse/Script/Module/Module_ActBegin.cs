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

    public class Module_�������ӱ����� : ModuleInfo
    {
        protected override void Enable()
        {
            base.Enable();
            Global_InWorldEventSystem.CallOn����׻���(true);
        }
        protected override void Disable()
        {
            base.Disable();
            Global_InWorldEventSystem.CallOn����׻���(false);
        }
        private void Effect()
        {

        }

    }


}

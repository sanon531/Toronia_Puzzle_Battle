using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.Event;

namespace ToronPuzzle.Data
{
    public class Module_OnlyElement : ModuleInfo
    {
        protected Vector3 _amount = new Vector3();
        protected override void Enable()
        {
            base.Enable();
        }
        protected override void Disable()
        {
            base.Disable();
        }
    }


    public sealed class Module_강경업글_공업_약 : ModuleInfo
    {
        protected override void Enable()
        {
            base.Enable();
            float _amount = BlockElementPool._powerTofloatDic[Element_Power.약];
            Global_InWorldEventSystem.CallOn속성배율변동(
                BlockElement.Aggressive, new Vector3(_amount, 0f, 0f));
        }
        protected override void Disable()
        {
            base.Disable();
        }

    }
    
    public sealed class Module_냉소업글_방업_약 : ModuleInfo
    {
        protected override void Enable()
        {
            base.Enable();
            float _amount = BlockElementPool._powerTofloatDic[Element_Power.약];
            Global_InWorldEventSystem.CallOn속성배율변동(
                BlockElement.Cynical, new Vector3( 0f, _amount, 0f));


        }
        protected override void Disable()
        {
            base.Disable();


        }


    }

    public sealed class Module_우호업글_균형_약 : ModuleInfo
    {
        protected override void Enable()
        {
            base.Enable();
            float _amount = BlockElementPool._powerTofloatDic[Element_Power.약];
            Global_InWorldEventSystem.CallOn속성배율변동(
                BlockElement.Friendly, new Vector3(_amount, _amount, 0f));


        }
        protected override void Disable()
        {
            base.Disable();


        }


    }

}

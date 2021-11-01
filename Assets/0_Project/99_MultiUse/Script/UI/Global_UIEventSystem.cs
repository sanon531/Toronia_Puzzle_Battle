using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToronPuzzle.UI;
using System;


namespace ToronPuzzle.Event
{
    public delegate void EventFunc();
    public delegate void EventFunc<T>(T param1);
    public delegate void EventFunc<T1, T2>(T1 param1, T2 param2);

    public enum EventRegistOption
    {
        None = 0,
        Permanent = 1,  //Scene변경에도 사라지지 않음.
    }
    public static class Global_UIEventSystem 
    {
        public static event EventFunc onTooltipShow;
        public static void CallOnTooltipShow() { onTooltipShow.Invoke(); }



        private static Dictionary<UIEventID, DelegateList> _uiEvents = new Dictionary<UIEventID, DelegateList>();
        private static Dictionary<UIEventID, DelegateList> _permanentEvents = new Dictionary<UIEventID, DelegateList>();


        //////////////////////////////////////////////////////////////////////////////////////////////////
        // 주의 : 씬이 바뀔 때 ui event 는 모두 클리어되어야 한다.
        public static void Clear_SceneLocalUIEvent()
        {
            _uiEvents = new Dictionary<UIEventID, DelegateList>(_permanentEvents);
            Debug.Log("UI Event Cleared");
        }


        public static void Call_UIEvent(UIEventID eventID)
        {
            if (null == _uiEvents)
            {
                return;
            }

            if (false == _uiEvents.ContainsKey(eventID))
            {
                Debug.Log("등록되지 않은 이벤트입니다 : " + eventID);
                return;
            }

            // 해당 이벤트에 달린 모든 함수를 실행.
            List<Delegate> eventList = _uiEvents[eventID].GetEventList();
            foreach (EventFunc func in eventList)
            {
                func();
            }
        }

        public static void Call_UIEvent<T>(UIEventID eventID, T param)
        {
            if (null == _uiEvents)
            {
                return;
            }

            if (false == _uiEvents.ContainsKey(eventID))
            {
                Debug.Log("등록되지 않은 이벤트입니다 : " + eventID);
                return;
            }

            // 해당 이벤트에 달린 모든 함수를 실행.
            List<Delegate> eventList = _uiEvents[eventID].GetEventList();
            foreach (EventFunc<T> func in eventList)
            {
                func(param);
            }
        }

        public static void Call_UIEvent<T1, T2>(UIEventID eventID, T1 param1, T2 param2)
        {
            if (null == _uiEvents)
            {
                return;
            }

            if (false == _uiEvents.ContainsKey(eventID))
            {
                Debug.Log("등록되지 않은 이벤트입니다 : " + eventID);
                return;
            }

            // 해당 이벤트에 달린 모든 함수를 실행.
            List<Delegate> eventList = _uiEvents[eventID].GetEventList();
            foreach (EventFunc<T1, T2> func in eventList)
            {
                func(param1, param2);
            }

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        // UI 이벤트 등록 부분. 인자 개수에 따라서 다른 RegisterUIEvent 함수로 등록하면 된다.
        public static void Register_UIEvent(UIEventID eventID, EventFunc func, EventRegistOption option = EventRegistOption.None)
        {
            // 이벤트가 아예 없었으면 새로 할당해주어야 한다.
            if (false == _uiEvents.ContainsKey(eventID))
            {
                DelegateList list = new DelegateList();
                list.AddFunction<EventFunc>(func);

                _uiEvents.Add(eventID, list);
            }
            else
            {
                // 이벤트에 함수 추가.
                _uiEvents[eventID].AddFunction<EventFunc>(func);
            }

            if (option.HasFlag(EventRegistOption.Permanent))
            {
                // 이벤트가 아예 없었으면 새로 할당해주어야 한다.
                if (false == _permanentEvents.ContainsKey(eventID))
                {
                    DelegateList list = new DelegateList();
                    list.AddFunction<EventFunc>(func);

                    _permanentEvents.Add(eventID, list);
                }
                else
                {
                    // 이벤트에 함수 추가.
                    _permanentEvents[eventID].AddFunction<EventFunc>(func);
                }
            }
        }

        public static void Register_UIEvent<T>(UIEventID eventID, EventFunc<T> func, EventRegistOption option = EventRegistOption.None)
        {
            // 이벤트가 아예 없었으면 새로 할당해주어야 한다.
            if (false == _uiEvents.ContainsKey(eventID))
            {
                DelegateList list = new DelegateList();
                list.AddFunction<EventFunc<T>>(func);

                _uiEvents.Add(eventID, list);
            }
            else
            {
                // 이벤트에 함수 추가.
                _uiEvents[eventID].AddFunction<EventFunc<T>>(func);
            }

            if (option.HasFlag(EventRegistOption.Permanent))
            {
                // 이벤트가 아예 없었으면 새로 할당해주어야 한다.
                if (false == _permanentEvents.ContainsKey(eventID))
                {
                    DelegateList list = new DelegateList();
                    list.AddFunction<EventFunc<T>>(func);

                    _permanentEvents.Add(eventID, list);
                }
                else
                {
                    // 이벤트에 함수 추가.
                    _permanentEvents[eventID].AddFunction<EventFunc<T>>(func);
                }
            }
        }

        public static void Register_UIEvent<T1, T2>(UIEventID eventID, EventFunc<T1, T2> func, EventRegistOption option = EventRegistOption.None)
        {
            // 이벤트가 아예 없었으면 새로 할당해주어야 한다.
            if (false == _uiEvents.ContainsKey(eventID))
            {
                DelegateList list = new DelegateList();
                list.AddFunction<EventFunc<T1, T2>>(func);

                _uiEvents.Add(eventID, list);
            }
            else
            {
                // 이벤트에 함수 추가.
                _uiEvents[eventID].AddFunction<EventFunc<T1, T2>>(func);
            }

            if (option.HasFlag(EventRegistOption.Permanent))
            {
                // 이벤트가 아예 없었으면 새로 할당해주어야 한다.
                if (false == _permanentEvents.ContainsKey(eventID))
                {
                    DelegateList list = new DelegateList();
                    list.AddFunction<EventFunc<T1, T2>>(func);

                    _permanentEvents.Add(eventID, list);
                }
                else
                {
                    // 이벤트에 함수 추가.
                    _permanentEvents[eventID].AddFunction<EventFunc<T1, T2>>(func);
                }
            }
        }








    }

    public struct DelegateList
    {
        private List<Delegate> _funcList;
        public List<Delegate> GetEventList() { return _funcList; }

        public void AddFunction<T>(T func)
        {
            if (null == _funcList)
            {
                _funcList = new List<Delegate>();
            }

            _funcList.Add(func as Delegate);
        }

        public void DeleteFunction<T>(T func)
        {
            _funcList.Remove(func as Delegate);
        }

        public bool IsEmpty()
        {
            if (null == _funcList)
            {
                return true;
            }

            if (_funcList.Count <= 0)
            {
                return true;
            }

            return false;
        }
    }

}

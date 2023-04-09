using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum eState
{
    STATE_NONE = -1,
    STATE_STAND = 0,
    STATE_MOVE,
    STATE_ATTACK,
}
public enum eEvent
{
    EVENT_STOPTOMOVE =0,
    EVENT_STOPTOATTACK =-1,
    EVENT_MOVETOSTOP,
    EVENT_MOVETOATTACK,
    EVENT_ATTACKTOMOVE,
    EVENT_ATTACKTOSTOP
}
public class FSM 
{
    Dictionary<eState, Dictionary<eEvent, eState>> stateList =
         new Dictionary<eState, Dictionary<eEvent, eState>>();

    eState curState;
    public eState CURSTATE
    {
        get { return curState; }
        set { curState = value; }
    }

    public FSM() { }

    public void AddState( eState _curState, eEvent inputEvent, eState _outState)//
    {
        // 현재키를 갖고 있을 경우
        if( stateList.ContainsKey(_curState))
        {
            stateList[_curState].Add(inputEvent, _outState);
        }
        else
        {   // 현재키를 갖고 있지 않을 경우
            Dictionary<eEvent, eState> list = new Dictionary<eEvent, eState>();
            list.Add(inputEvent, _outState);
            stateList.Add(_curState,list);
        }
    }

    // 매개변수 -> 전이조건(입력이벤트)에 따른 출력 상태를 리턴
    public eState? GetOutState( eEvent inputEvent)
    {
        //current 에서 조건 1과 조건2로 가는 것이 담겨있는 리스트
        Dictionary<eEvent, eState> list = stateList[curState];
        eState outState;
        if( list.TryGetValue(inputEvent , out outState))
        {
            return list[inputEvent]; 
        }
        return null;
    }
    // 현재상태에서 입력에 따른 전이
    public void SetTransition( eEvent Event)
    {
        // curState는 현재상태를 저장하고 있으므로 
        // 전이조건에 맞는 출력상태를 현재상태에 대입
        Dictionary<eEvent, eState> list = stateList[curState];
        eState result;
        if(list.TryGetValue(Event,out result))
        {
            curState = result;
        }
    }

    // stateList에 저장된 모든 키와 값을 출력
    public void DisplayData()
    {
        foreach (KeyValuePair<eState,Dictionary<eEvent ,eState>> one in stateList )
        {

            string str = one.Key.ToString() + "\n";

            foreach(KeyValuePair<eEvent,eState> o in one.Value)
            {
                str += "    " + o.Key.ToString()+""+o.Value.ToString() + "\n";
            }
            Debug.Log(str);
        }
    }

}

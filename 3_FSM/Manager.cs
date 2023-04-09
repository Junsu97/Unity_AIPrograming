using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    FSM fsm = new FSM();
    void Start()
    {
        fsm.AddState(eState.STATE_STAND, eEvent.EVENT_STOPTOMOVE, eState.STATE_MOVE);
        fsm.AddState(eState.STATE_STAND, eEvent.EVENT_STOPTOATTACK, eState.STATE_ATTACK);

        fsm.AddState(eState.STATE_MOVE, eEvent.EVENT_MOVETOSTOP, eState.STATE_STAND);
        fsm.AddState(eState.STATE_MOVE, eEvent.EVENT_MOVETOATTACK, eState.STATE_ATTACK);

        fsm.AddState(eState.STATE_ATTACK, eEvent.EVENT_ATTACKTOSTOP, eState.STATE_STAND);
        fsm.AddState(eState.STATE_ATTACK, eEvent.EVENT_ATTACKTOMOVE, eState.STATE_MOVE);

        fsm.CURSTATE = eState.STATE_STAND;

        eState? outState = fsm.GetOutState(eEvent.EVENT_STOPTOMOVE);
        if(outState != null)
        {
            Debug.Log(outState);
        }
        eState? outResult = fsm.GetOutState(eEvent.EVENT_MOVETOATTACK);
        if( outResult == null)
        {
            Debug.Log(fsm.CURSTATE +"일 경우" +
                eEvent.EVENT_MOVETOATTACK+"이벤트 없다");
        }
    }

    void Update()
    {
        
    }
}

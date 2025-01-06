using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    public static class Actions
    {
        public static Action partyTimeEvent;
    }

    private void OnEnable()
    {
        Actions.partyTimeEvent += ReadInput;
    }
    private void OnDisable()
    {
        
    }
    void ReadInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Actions.partyTimeEvent;
            Debug.Log("Space pressed, action taken");
        }
    }
}

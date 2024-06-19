using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "IntEvent", menuName = "IntEventChannel", order = 0)]
public class IntEventChannel : ScriptableObject
{
    public UnityAction<int> OnEventRaised;

    public void RaiseEvent(int val)
    {
        OnEventRaised?.Invoke(val);
    }
}

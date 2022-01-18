using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public UnityEvent NextLevelEvent = new UnityEvent();
    public UnityEvent VictoryEvent = new UnityEvent();
}

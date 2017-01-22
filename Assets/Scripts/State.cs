using UnityEngine;
using System.Collections;

public class State : MonoBehaviour
{
    public enum StateEnum
    {
        PREPERATION,
        RUNNING,
        COLLISION,
        SUCCESS,
        FAILURE
    };
}
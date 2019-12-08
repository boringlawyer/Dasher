using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class ReasonForDying : ScriptableObject
{
    public enum Reason { Abyss, TooManyClicks, FellOffScreen, HitObstacle};
    public Reason reason;
    public void Create()
    {

    }
}
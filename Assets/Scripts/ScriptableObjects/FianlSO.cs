using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Final Source", menuName = "Final")]
public class FianlSO : ScriptableObject
{
    private Ends _ends;
    public Ends ends { get { return _ends; } set { _ends = value; } }
}

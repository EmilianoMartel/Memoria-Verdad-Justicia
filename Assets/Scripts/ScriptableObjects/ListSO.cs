using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "List Data Source", menuName = "ListData")]
public class ListSO :ScriptableObject
{
    private List<Names> _names;
    private List<LastNames> _lastNames;
    private List<Stories> _stories;
    private List<Acronyms> _acronyms;

    public List<Names> names { get { return _names; } set{ _names = value; } }
    public List<LastNames> lastNames { get { return _lastNames; } set { _lastNames = value; } }
    public List<Stories> stories { get { return _stories; } set { _stories = value; } }
    public List<Acronyms> acronyms { get { return _acronyms; } set { _acronyms = value; } }
}

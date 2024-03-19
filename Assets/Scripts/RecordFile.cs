using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordFile
{
    private string _name;
    private string _lastName;
    private string _job;
    private string _politicalPartyName;
    private string _background;
    private string _gender;

    public string name { get { return _name; }set { _name = value; } }
    public string lastName { get { return _lastName; }set { _lastName = value; } }
    public string job { get { return _job; }set { _job = value; } }
    public string background { get { return _background; }set { _background = value; } }
    public string politicalPartyName { get { return _politicalPartyName; } set { _politicalPartyName = value; } }
    public string gender { get { return _gender; }set { _gender = value; } }
}
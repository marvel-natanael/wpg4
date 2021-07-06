using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DialogList
{
    [SerializeField] List<string> lines;
    public List<string> Lines
    {
        get { return lines; }
    }
}

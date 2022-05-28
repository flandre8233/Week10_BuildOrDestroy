using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveFile
{
    public List<SaveTile> Map;
    public int TotalTime;
    public int Intervention;
    public DateTime LeaveDateTime;
    public string SubjectName;
}

[System.Serializable]
public class SaveTile
{
    public int X;
    public int Y;
    public int Index;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System;
public class Saver : SingletonMonoBehavior<Saver>
{
    [SerializeField] GodInterference GodInterference;
    private void OnApplicationQuit()
    {
        DataToJson();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            DataToJson();
        }
    }

    public static void DataToJson()
    {
        SaveFile Save = GetGameStatusToSaveFile();
        string jsonStr = JsonMapper.ToJson(Save);
        WriteString("PlayerSave", jsonStr);
    }

    public static void ClearSave()
    {
        SaveFile Save = new SaveFile();
        string jsonStr = JsonMapper.ToJson(Save);
        WriteString("PlayerSave", jsonStr);
    }

    static SaveFile GetGameStatusToSaveFile()
    {
        SaveFile output = new SaveFile();
        output.Map = TilemapData.instance.ToSaveTile();
        output.TotalTime = (int)LifeTimer.instance.GetTotalTime();
        output.Intervention = instance.GodInterference.Interventions;
        output.LeaveDateTime = DateTime.UtcNow;
        output.SubjectName = SubjectName.instance.Subject;
        return output;
    }

    public static void WriteString(string FileName, string Content)
    {
        string path = Application.persistentDataPath + "/" + FileName + ".txt";
        StreamWriter writer = new StreamWriter(path);
        writer.Write(Content);
        writer.Close();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
public class Loader : SingletonMonoBehavior<Loader>
{
    [SerializeField] GodInterference GodInterference;

    string path;

    void Start()
    {
        path = Application.persistentDataPath;
        string JsonStr = ReadString("PlayerSave");
        JsonToData(JsonStr);
    }

    public static void JsonToData(string JsonStr)
    {
        SaveFile Load = JsonMapper.ToObject<SaveFile>(JsonStr);
        TilemapData.instance.ReadTile(Load.Map);
        LifeTimer.instance.SetTotalTime(Load.TotalTime);
        instance.GodInterference.Interventions = Load.Intervention;
        LeaveTimer.instance.LeaveGameDateTime = Load.LeaveDateTime;
        SubjectName.instance.Subject = Load.SubjectName;
    }

    public string ReadString(string FileName)
    {
        string path = Application.persistentDataPath + "/" + FileName + ".txt";
        StreamReader reader = new StreamReader(path);
        string Result = reader.ReadToEnd();
        reader.Close();
        return Result;
    }

}


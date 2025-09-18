using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //用于存储玩家信息的类，可序列化让其可以转换为json文件
    [System.Serializable] class Savedata
    {
        
    }
    const string PLAYER_DATA_KEY = "BananaCat";
    const string PLAYER_DATA_FILE_NAME = "BananaCat.sav";
    public void Save()
    {
        SaveByJson();
    }
    public void Load()
    {
        LoadFromJson();
    }
    //存档功能
    private void SaveByJson()
    {
        SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME,SavingData());
    }
    //读档功能
    private void LoadFromJson()
    {
        var savedata = SaveSystem.LoadFromJson<Savedata>(PLAYER_DATA_FILE_NAME);
        LoadData(savedata);
    }
    Savedata SavingData()
    {
        var savedata = new Savedata();
        //Todo:存储数据到savedata里

        return savedata;
    }
    private void LoadData(Savedata savedata)
    {
        //Todo:把savedata里的数据返回来
    }
    //删除数据
    [UnityEditor.MenuItem("Developer/Delete Player Data Prefs")]
    public static void DeletePlayerDataSaveFile()
    {
        SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public List<bool> list = new List<bool> {true , false , false};
    public List<int> ints = new List<int> { 0 , 0 , 0 };
    public bool haveData = false;
    //用于存储玩家信息的类，可序列化让其可以转换为json文件
   
    [System.Serializable] class Savedata
    {
        public List<bool> list = new List<bool>();//记录是否通关
        public List<int> ints = new List<int>();//记录几颗星
        public bool haveData;//记录是否有存档
    }
    const string PLAYER_DATA_KEY = "BananaCat";
    const string PLAYER_DATA_FILE_NAME = "BananaCat.sav";
    //初始化存档，避免他为空
    public void FirstSave()
    {
        Savedata newdata = new Savedata();
        newdata.list = list;
        newdata.ints = ints;
        newdata.haveData = true;
        SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, newdata);
    }
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
        Savedata savedata = Check();
        //存储数据到savedata里
        savedata.list = list;
        savedata.ints = ints;
        savedata.haveData = haveData;
        return savedata;
    }
    private void LoadData(Savedata savedata)
    {
        //Todo:把savedata里的数据返回来     
        list = savedata.list;
        ints = savedata.ints;  
        haveData = savedata.haveData;
    }
    //删除数据
    [UnityEditor.MenuItem("Developer/Delete Player Data Prefs")]
    public static void DeletePlayerDataSaveFile()
    {
        SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
    }
    Savedata Check()
    {
        var savedata = SaveSystem.LoadFromJson<Savedata>(PLAYER_DATA_FILE_NAME);//先把档里的东西读出来看要不要覆盖
        //Todo:进度高的覆盖

        for (int i = 0; i < savedata.list.Count; i++)
        {
            if (savedata.list[i] == true)
            {
                list[i] = true;
            }
        }
        for (int i = 0; i < savedata.ints.Count; i++)
        {
            if (savedata.ints[i] >= ints[i])
            {
                ints[i] = savedata.ints[i];
            }
        }
        if( savedata.haveData)
        {
            haveData = savedata.haveData;
        }


        return savedata;
    }
}

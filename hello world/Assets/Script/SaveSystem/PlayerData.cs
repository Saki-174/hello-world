using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //���ڴ洢�����Ϣ���࣬�����л��������ת��Ϊjson�ļ�
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
    //�浵����
    private void SaveByJson()
    {
        SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME,SavingData());
    }
    //��������
    private void LoadFromJson()
    {
        var savedata = SaveSystem.LoadFromJson<Savedata>(PLAYER_DATA_FILE_NAME);
        LoadData(savedata);
    }
    Savedata SavingData()
    {
        var savedata = new Savedata();
        //Todo:�洢���ݵ�savedata��

        return savedata;
    }
    private void LoadData(Savedata savedata)
    {
        //Todo:��savedata������ݷ�����
    }
    //ɾ������
    [UnityEditor.MenuItem("Developer/Delete Player Data Prefs")]
    public static void DeletePlayerDataSaveFile()
    {
        SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
    }
}

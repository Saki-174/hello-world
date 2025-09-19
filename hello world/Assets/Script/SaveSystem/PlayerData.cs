using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public List<bool> list = new List<bool> {true , false , false};
    public List<int> ints = new List<int> { 0 , 0 , 0 };
    public bool haveData = false;
    //���ڴ洢�����Ϣ���࣬�����л��������ת��Ϊjson�ļ�
   
    [System.Serializable] class Savedata
    {
        public List<bool> list = new List<bool>();//��¼�Ƿ�ͨ��
        public List<int> ints = new List<int>();//��¼������
        public bool haveData;//��¼�Ƿ��д浵
    }
    const string PLAYER_DATA_KEY = "BananaCat";
    const string PLAYER_DATA_FILE_NAME = "BananaCat.sav";
    //��ʼ���浵��������Ϊ��
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
        Savedata savedata = Check();
        //�洢���ݵ�savedata��
        savedata.list = list;
        savedata.ints = ints;
        savedata.haveData = haveData;
        return savedata;
    }
    private void LoadData(Savedata savedata)
    {
        //Todo:��savedata������ݷ�����     
        list = savedata.list;
        ints = savedata.ints;  
        haveData = savedata.haveData;
    }
    //ɾ������
    [UnityEditor.MenuItem("Developer/Delete Player Data Prefs")]
    public static void DeletePlayerDataSaveFile()
    {
        SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
    }
    Savedata Check()
    {
        var savedata = SaveSystem.LoadFromJson<Savedata>(PLAYER_DATA_FILE_NAME);//�Ȱѵ���Ķ�����������Ҫ��Ҫ����
        //Todo:���ȸߵĸ���

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

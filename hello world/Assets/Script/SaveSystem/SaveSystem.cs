using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//����JSON�Ĵ浵ϵͳ
public static class SaveSystem
{
    //�浵�����������������浵�ļ����ʹ�������ݣ�
    public static void SaveByJson(string saveFileName,object data)
    {
        var json = JsonUtility.ToJson(data);//��dataת��Ϊjson��ʽ���ı�
        var path = Path.Combine(Application.persistentDataPath, saveFileName);//�ϲ�����·�����ļ�����һ��·��
        try
        {
            File.WriteAllText(path,json);//��һ���������ļ���·�����ļ�������(�洢�Ǹ�д��ʽ)
            #if UNITY_EDITOR
            Debug.Log($"Susscessfully saved data to {path}.");
            #endif
        }
        catch(System.Exception exception)
        {
            #if UNITY_EDITOR
            Debug.LogError($"Fail to save data to {path}. \n{exception}");
            #endif
        }
    }
    //�����������ļ���
    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        try
        {
            var json = File.ReadAllText(path);//��ȡ·������ļ�����json�ļ�
            var data = JsonUtility.FromJson<T>(json);//��jsonת��Ϊ��Ҫ�ķ�������
            return data;

        }
        catch (System.Exception exception)
        {
            #if UNITY_EDITOR
            Debug.LogError($"Fail to load data to {path}. \n{exception}");
            #endif
            return default;
        }
    }

    //ɾ���浵�ļ�,������Ҫɾ���浵���ļ���
    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        try
        {
            File.Delete(path);

        }
        catch (System.Exception exception)
        {
            #if UNITY_EDITOR
            Debug.LogError($"Fail to delete {path}. \n{exception}");
            #endif
        }
    }
}

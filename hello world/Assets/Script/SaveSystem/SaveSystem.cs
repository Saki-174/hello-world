using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//基于JSON的存档系统
public static class SaveSystem
{
    //存档，传入两个参数（存档文件名和存入的数据）
    public static void SaveByJson(string saveFileName,object data)
    {
        var json = JsonUtility.ToJson(data);//将data转换为json格式的文本
        var path = Path.Combine(Application.persistentDataPath, saveFileName);//合并永久路径和文件名成一个路径
        try
        {
            File.WriteAllText(path,json);//第一个参数是文件夹路径和文件夹名字(存储是覆写方式)
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
    //读档，传入文件名
    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);
        try
        {
            var json = File.ReadAllText(path);//读取路径里的文件返回json文件
            var data = JsonUtility.FromJson<T>(json);//将json转换为需要的泛型数据
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

    //删除存档文件,传入需要删除存档的文件名
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

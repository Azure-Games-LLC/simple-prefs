using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace SPrefs
{
    public class SimplePrefs : MonoBehaviour
    {
        private static Dictionary<string, int> intDict = new Dictionary<string, int>();
        private static Dictionary<string, float> floatDict = new Dictionary<string, float>();
        private static Dictionary<string, string> stringDict = new Dictionary<string, string>();
        private static Dictionary<string, string> typeDict = new Dictionary<string, string>();

        public static int GetInt(string key, int defaultValue = 0)
        {
            if (!intDict.ContainsKey(key))
            {
                intDict.Add(key, PlayerPrefs.GetInt(key, defaultValue));
            }

            return intDict[key];
        }

        public static float GetFloat(string key, float defaultValue = 0f)
        {
            if (!floatDict.ContainsKey(key))
            {
                floatDict.Add(key, PlayerPrefs.GetFloat(key, defaultValue));
            }

            return floatDict[key];
        }

        public static string GetString(string key, string defaultValue)
        {
            if (!stringDict.ContainsKey(key))
            {
                stringDict.Add(key, PlayerPrefs.GetString(key, defaultValue));
            }
            
            return stringDict[key];
        }

        public static T GetData<T>(string key, bool createIfNull)
        {
            if(!typeDict.ContainsKey(key))
            {
                typeDict.Add(key, PlayerPrefs.GetString(key));
            }

            T data = default(T); 

            if (string.IsNullOrEmpty(typeDict[key]) && createIfNull)
            {
                SetData(key, data);
            }
            else
            {
                data = JsonUtility.FromJson<T>(typeDict[key]);
            }

            return data;
        }

        public static void SetInt(string key, int val)
        {
            if(!intDict.ContainsKey(key))
            {
                intDict.Add(key, val);
            }
            else
            {
                intDict[key] = val;
            }

            PlayerPrefs.SetInt(key, val);
        }

        public static void SetFloat(string key, float val)
        {
            if (!floatDict.ContainsKey(key))
            {
                floatDict.Add(key, val);
            }
            else
            {
                floatDict[key] = val;
            }

            PlayerPrefs.SetFloat(key, val);
        }

        public static void SetString(string key, string val)
        {
            if (!stringDict.ContainsKey(key))
            {
                stringDict.Add(key, val);
            }
            else
            {
                stringDict[key] = val;
            }

            PlayerPrefs.SetString(key, val);
        }

        public static void SetData<T>(string key, T data)
        {
            string s = JsonUtility.ToJson(data);

            if (!typeDict.ContainsKey(key))
            {
                typeDict.Add(key, PlayerPrefs.GetString(key));
            }
            else
            {
                typeDict[key] = s;
            }

            PlayerPrefs.SetString(key, s);
        }

        public static void Save(UnityAction OnComplete)
        {
            PlayerPrefs.Save();

            if (OnComplete != null) OnComplete.Invoke();
        }

        [MenuItem("Simple Prefs/Delete All")]
        public static void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
        }

        public static void DeleteAll(UnityAction OnComplete)
        {
            PlayerPrefs.DeleteAll();

            if (OnComplete != null) OnComplete.Invoke();
        }

        public static void DeleteKey(string key, UnityAction OnComplete)
        {
            PlayerPrefs.DeleteKey(key);

            if (OnComplete != null) OnComplete.Invoke();
        }
    }
}
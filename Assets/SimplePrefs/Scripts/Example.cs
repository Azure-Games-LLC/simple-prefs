using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPrefs;

public class Example : MonoBehaviour
{
    public enum NumberTypes
    {
        One,
        Two,
        Three
    }

    public NumberTypes number;

    [ContextMenu("Save Enum")]
    void SaveEnum()
    {
        SimplePrefs.SetData<NumberTypes>("numberType", number);
    }

    [ContextMenu("Get Enum")]
    void GetEnum()
    {
        number = SimplePrefs.GetData<NumberTypes>("numberType", true);
    }
}

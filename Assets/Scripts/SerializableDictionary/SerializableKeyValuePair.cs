using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class SerializableKeyValuePairList<TKey, TValue> : List<SerializableKeyValuePair<TKey, TValue>>
{
    public SerializableKeyValuePairList() : base()
    {
    }
}

[Serializable]
public class SerializableKeyValuePair<TKey,TValue>
{
    public TKey Key;
    public TValue Value;

    public SerializableKeyValuePair(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }

    public void SetValue(TValue value)
    {
        Value = value;
    }
}











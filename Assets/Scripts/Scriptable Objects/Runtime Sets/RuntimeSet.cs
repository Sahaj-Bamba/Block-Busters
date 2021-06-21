using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuntimeSet", menuName = "Runtime Set/Runtime Set")]
public abstract class RuntimeSet<T> : ScriptableObject
{
    private List<T> items = new List<T>();
    public int Cnt;
    public void Initialize()
    {
        items.Clear();
        Cnt = 0;
    }

    public int Count()
    {
        return items.Count;
    }

    public T GetItem(int index)
    {
        return items[index];
    }

    public void Add(T t)
    {
        if (!items.Contains(t)) { Cnt++; items.Add(t); }
    }

    public void Remove(T t)
    {
        if (items.Contains(t)) { Cnt--; items.Remove(t); }
    }

}

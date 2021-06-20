using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RuntimeSet", menuName = "Runtime Set/Runtime Set")]
public abstract class RuntimeSet<T> : ScriptableObject
{
    private List<T> items = new List<T>();

    public void Initialize()
    {
        items.Clear();
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
        if (!items.Contains(t)) { items.Add(t); }
    }

    public void Remove(T t)
    {
        if (items.Contains(t)) { items.Remove(t); }
    }

}

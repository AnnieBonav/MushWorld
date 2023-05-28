using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay.")]
    public GameObject itemPrefab;

    [Header("Only UI")]
    public bool stackable = true;
    public Sprite image;
}

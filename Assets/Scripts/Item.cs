using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public Sprite Image;
    public string Description;
    public GameObject Item3DModel;
}

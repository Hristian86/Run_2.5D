using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseStats
{
    [SerializeField]
    private int baseValue;

    public int GetValue { get => this.baseValue; }
}

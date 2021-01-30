using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public enum TransformType
{
    [Description("初始")]
    Normal,
    [Description("手术刀")]
    Scalpel,
    [Description("盾牌")]
    Shield,
    [Description("火把")]
    Torch,
    [Description("绳索")]
    Lope,
}
[DisallowMultipleComponent]
public class TransformItem : MonoBehaviour
{
    public TransformType type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

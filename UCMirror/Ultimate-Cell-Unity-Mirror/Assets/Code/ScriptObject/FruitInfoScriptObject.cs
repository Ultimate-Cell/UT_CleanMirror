using UnityEngine;
using UnityEngine.UI;
using static EventType;

[CreateAssetMenu(fileName = "Fruit Tree Info ScriptObject", menuName = "Fruit Tree Info ScriptObject")]
public class FruitInfoScriptObject : ScriptableObject 
{
    [Header("果实名称")]
    public string Name;

    [Header("果实Id")]
    public int FruitId;

    [Header("果实是否被触发")]
    public bool isTigger;

    [Header("是否为根节点果实")]
    public bool isRootFruit;

    [Header("是否为阵营节点果实")]
    public bool isCampFruit;

    [Header("触发花费点数")]
    public int CostPointsInfo;

    [Header("果实所属阵营")]
    public FruitTrees FruitCamp;

    [Header("果实触发图片样式")]
    public Sprite FruitIconTiggered;

    [Header("果实尚未触发图片样式")]
    public Sprite FruitIconNotTiggered;
}
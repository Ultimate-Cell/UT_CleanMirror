using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static EventType;

[CreateAssetMenu(fileName = "Fruit Tree Info ScriptObject", menuName = "Select Fruit Tree Info ScriptObject")]
public class FruitSelectInfoScriptObject : ScriptableObject
{
    public string Name;

    public int FrutitCampId;

    public FruitTrees FruitSelectCamp;

    public FruitInfoScriptObject NecessaryCampFruit;

    public FruitInfoScriptObject FreelyCampFruit1;

    public FruitInfoScriptObject FreelyCampFruit2;

    public FruitInfoScriptObject FreelyCampFruit3;

}

using UnityEngine;
using UnityEngine.UI;
using static EventType;

[CreateAssetMenu(fileName = "Settings Info Object", menuName = "Settings Info Object")]
public class SettingsInfo : ScriptableObject
{
    [Header("客户端链接")]
    public string localhost;
}
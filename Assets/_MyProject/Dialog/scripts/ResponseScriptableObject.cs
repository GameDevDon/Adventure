using UnityEngine;
using UnityEngine.Events;

public enum responseTypes
{
   ShowDialog,
   CloseDialog,
   GiveQuest,
   CompleteQuest,
   GiveItem,
   TakeItem,
}

[CreateAssetMenu(fileName ="NewResponse", menuName = "Adventure/Dialog Response")]
public class ResponseScriptableObject : ScriptableObject 
{
    public GameObject       buttonPrefab;
    [TextArea]
    public string           responseText;
    public responseTypes    responseType;
    public Quest_SO         quest;
    public Item_SO          item;
}

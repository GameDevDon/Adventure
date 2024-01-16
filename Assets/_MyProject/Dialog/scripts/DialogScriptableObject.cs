using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData/NewDialog", menuName = "Adventure/Dialog")]
public class DialogScriptableObject : ScriptableObject
{
    [TextArea] public string dialogText;
    public ResponseScriptableObject[] responses;
    
}

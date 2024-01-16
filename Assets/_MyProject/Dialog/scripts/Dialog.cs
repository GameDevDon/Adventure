using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog : MonoBehaviour
{
    // use two dialog objects as dialog may change after first conversation 
    [SerializeField] DialogScriptableObject InitialDialogObject;
    [SerializeField] DialogScriptableObject dialogObject;
    // The UI panel into which the reponses will be created
    [SerializeField] GameObject responsePanel;
    [SerializeField] TMP_Text uiDialogText;
    

    private void Awake()
    {
        if (dialogObject == null)
        {
            Debug.LogError("Dialog Object Not Set on: " + this.name);
        }
    }

    private void OnEnable()
    {
        uiDialogText.text = dialogObject.dialogText;
        int length = dialogObject.responses.Length;
        for (int i = 0; i < length; i++)
        {
            GameObject prefabObject = Instantiate(dialogObject.responses[i].buttonPrefab,responsePanel.transform);
            prefabObject.GetComponent<TMP_Text>().text = dialogObject.responses[i].responseText;
            // get the DialogResponse script included in the prefab.
            DialogResponseButton buttonScript= prefabObject.GetComponent<DialogResponseButton>();
            // passes the reference to this script and the index of the array to the newly instanciated buttton
            buttonScript.dialog = this;
            buttonScript.reponseIndex = i;           
        }
    }

    public void MakeSelection(int selectedResponse)
    {
        
    }
}

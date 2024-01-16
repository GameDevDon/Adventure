using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogResponseButton : MonoBehaviour
{
    [SerializeField] private Button yourButton;
    public Dialog dialog;
    public int reponseIndex;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(RespondToCick);
    }

    void RespondToCick()
    {
        Debug.Log("You have clicked button" + reponseIndex.ToString());
    }
}
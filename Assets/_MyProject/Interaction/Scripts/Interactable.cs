
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool           runInstantly;
    [SerializeField] private UnityEvent     interactionEvents;
    [SerializeField] private string         toolTipText;
    [SerializeField] private Vector3        toolTipPosition;
                     private InputActions   inputActions;
    
    private void OnTriggerEnter(Collider objectCollided)
    {
        // if the object entering the trigger is the player
        if (objectCollided.CompareTag("player"))
        {
            inputActions = objectCollided.GetComponent<InputActions>();
            inputActions.currentInteractionObject = this;
        }
        if(toolTipText != null)
        {
            ShowToolTip();
        }
        if (runInstantly)
        {
            Interact();
        }
    }


    public void SetCurrentInteractable (GameObject player)
    {
        inputActions = player.GetComponent<InputActions>();
        inputActions.currentInteractionObject = this;
        if (toolTipText != null)
        {
            ShowToolTip();
        }
        if (runInstantly)
        {
            Interact();
        }

    }

    private void ShowToolTip()
    {
        // UIManager.ShowToolTip (position,string);
    }
    public void Interact()
    {
        interactionEvents.Invoke();
    }
}

using UnityEngine;

public class DialogueActivator : MonoBehaviour, IIteractable
{
    [SerializeField] private DialogueObject dialogueObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && collision.TryGetComponent(out Player player))
        {
            player.Interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && collision.TryGetComponent(out Player player))
        {
            if(player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable = null;
            }
        }
    }
    public void Interact(Player player)
    {
        player.DialogueUI.ShowDialogue(dialogueObject);
    }
}


using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 1;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;

    public virtual void Interact()
    {
        //This method is meant to be overwriten by each differnt opject type
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (isFocus)
            {
                float distance = Vector3.Distance(player.position, interactionTransform.position);
                if (distance <= radius)
                {

                    Interact();
                    hasInteracted = true;


                }
            }
        }
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocus()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}

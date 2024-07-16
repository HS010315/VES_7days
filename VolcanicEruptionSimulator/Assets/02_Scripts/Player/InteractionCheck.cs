using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    public float interactionDistance = 3.0f;
    public Camera playerCamera;
    public Text interactionText;
    public PlayerStateInfo playerStateInfo;

    private IInteractable currentInteractable;

    void Update()
    {
        DetectInteractable();
        HandleInteraction();
    }

    void DetectInteractable()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null )
            {
                currentInteractable = interactable;
                interactionText.gameObject.SetActive(true);
                interactionText.text = "E를 눌러 상호작용";
                return;
            }
        }

        currentInteractable = null;
        interactionText.gameObject.SetActive(false);
    }

    void HandleInteraction()
    {
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }
}
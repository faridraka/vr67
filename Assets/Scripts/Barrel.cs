using UnityEngine;

public class Barrel : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;

    [Header("Push")]
    public float pushForce = 15f;
    public float pushDistance = 5f;

    void Awake()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PushObject();
        }
    }

    void PushObject()
    {
        // Raycast dari tengah layar (lebih cocok untuk FPS)
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out RaycastHit hit, pushDistance))
        {
            Rigidbody rb = hit.collider.attachedRigidbody;

            if (rb != null && rb.CompareTag("Barrel"))
            {
                rb.AddForce(playerCamera.transform.forward * pushForce, ForceMode.Impulse);
            }
        }
    }
}

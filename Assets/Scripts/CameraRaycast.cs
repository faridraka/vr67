using UnityEngine;
using TMPro;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField] private float rayDistance = 3f;
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private float highlightWidth = 5f;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI actionText;

    private Outline currentOutline;

    void Start()
    {
        ClearUI();
    }

    void Update()
    {
        RaycastCheck();
    }

    void RaycastCheck()
    {
        Outline newOutline = null;
        GameObject hitObject = null;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, rayDistance, interactLayer))
        {
            hitObject = hit.collider.gameObject;

            newOutline = hit.collider.GetComponentInParent<Outline>();

            if (newOutline == null)
                newOutline = hit.collider.GetComponentInChildren<Outline>();

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Interact : " + hit.collider.name);
            }
        }

        if (newOutline != currentOutline)
        {
            if (currentOutline != null)
                currentOutline.OutlineWidth = 0f;

            currentOutline = newOutline;

            if (currentOutline != null)
                currentOutline.OutlineWidth = highlightWidth;
        }

        if (hitObject != null)
        {
            UpdateUI(hitObject);
        }
        else
        {
            ClearUI();
        }

        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);
    }

    void UpdateUI(GameObject obj)
    {
        titleText.text = "Object: " + obj.name;

        if (obj.CompareTag("Barrel"))
        {
            actionText.text = "Kamu bisa push dengan mouse";
        }
        else if (obj.CompareTag("Excavator"))
        {
            actionText.text = "No Action";
        }
        else if (obj.CompareTag("Traffic Alert"))
        {
            actionText.text = "No Action";
        }
        else
        {
            actionText.text = "";
        }
    }

    void ClearUI()
    {
        titleText.text = "";
        actionText.text = "";
    }
}

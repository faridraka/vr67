using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField] private float rayDistance = 3f;
    [SerializeField] private LayerMask interactLayer = 1 << 3;
    [SerializeField] private Color highlightColor = Color.yellow;

    private Renderer[] currentRenderers;
    private Material[][] originalMaterials;
    private Material highlightMaterial;

    private void Start()
    {
        highlightMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        highlightMaterial.color = highlightColor;
    }

    private void Update()
    {
        RaycastCheck();
    }

    private void RaycastCheck()
    {
        ClearHighlight();

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, rayDistance, interactLayer))
        {
            currentRenderers = hit.collider.GetComponentsInChildren<Renderer>();

            originalMaterials = new Material[currentRenderers.Length][];

            for (int i = 0; i < currentRenderers.Length; i++)
            {
                originalMaterials[i] = currentRenderers[i].materials;

                Material[] newMaterials = new Material[currentRenderers[i].materials.Length];

                for (int j = 0; j < newMaterials.Length; j++)
                {
                    newMaterials[j] = highlightMaterial;
                }

                currentRenderers[i].materials = newMaterials;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Interact : " + hit.collider.name);
            }
        }

        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);
    }

    private void ClearHighlight()
    {
        if (currentRenderers == null) return;

        for (int i = 0; i < currentRenderers.Length; i++)
        {
            if (currentRenderers[i] != null)
            {
                currentRenderers[i].materials = originalMaterials[i];
            }
        }

        currentRenderers = null;
        originalMaterials = null;
    }
}

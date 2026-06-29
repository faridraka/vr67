using UnityEngine;
using TMPro;

public class AuthorizedZone : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI zoneText;

    [Header("Text")]
    public string defaultText = "Safe Zone";
    public string authorizedText = "Authorized Zone";

    [Header("Colors")]
    public Color safeColor = Color.green;
    public Color authorizedColor = Color.red;

    [Header("Target")]
    public string playerTag = "Player";

    void Start()
    {
        zoneText.text = defaultText;
        zoneText.color = safeColor;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            zoneText.text = authorizedText;
            zoneText.color = authorizedColor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            zoneText.text = defaultText;
            zoneText.color = safeColor;
        }
    }
}

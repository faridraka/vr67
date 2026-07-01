using UnityEngine;
using TMPro;

public class AuthorizedZone : MonoBehaviour
{
    public static bool isAuthorized = false;

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
        Debug.Log("Player masuk Authorized Zone");

        isAuthorized = true;

        zoneText.text = authorizedText;
        zoneText.color = authorizedColor;
    }
    }

    void OnTriggerExit(Collider other)
    {
    if (other.CompareTag(playerTag))
    {
        Debug.Log("Player keluar Authorized Zone");

        isAuthorized = false;

        zoneText.text = defaultText;
        zoneText.color = safeColor;
    }
    }
}

using UnityEngine;

public class RadioController : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlayerNearby = false;
    private Transform mainCameraTransform;

    [Header("UI Settings")]
    [SerializeField] private GameObject radioPromptCanvas; // Masukkan objek Canvas World Space di sini

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        // Mengambil referensi kamera utama
        if (Camera.main != null)
        {
            mainCameraTransform = Camera.main.transform;
        }

        // Memastikan UI mati saat awal game
        if (radioPromptCanvas != null)
        {
            radioPromptCanvas.SetActive(false);
        }
    }

    void Update()
    {
        // Fitur Interaksi
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ToggleRadio();
        }

        // Membuat UI selalu menghadap ke Kamera (Billboard Effect)
        if (radioPromptCanvas != null && radioPromptCanvas.activeSelf && mainCameraTransform != null)
        {
            radioPromptCanvas.transform.LookAt(radioPromptCanvas.transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
        }
    }

    void ToggleRadio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (radioPromptCanvas != null) radioPromptCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (radioPromptCanvas != null) radioPromptCanvas.SetActive(false);
        }
    }
}
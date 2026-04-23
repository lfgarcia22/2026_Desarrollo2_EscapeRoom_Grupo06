using TMPro;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Transform teleportPoint;
    public TextMeshProUGUI pressEText;

    private bool isPlayerNear = false;
    private GameObject currentPlayer;

    private static float nextTeleportTime = 0f;
    public float cooldown = 1f;

    void Start()
    {
        pressEText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && Time.time > nextTeleportTime)
        {
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        nextTeleportTime = Time.time + cooldown;

        // Reset estado ANTES de mover
        isPlayerNear = false;
        pressEText.gameObject.SetActive(false);

        currentPlayer.transform.position = teleportPoint.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentPlayer = other.gameObject;
            isPlayerNear = true;
            pressEText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            pressEText.gameObject.SetActive(false);
        }
    }
}
using TMPro;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public GameObject player;
    public Transform teleportPoint; // A dónde se moverá
    public TextMeshProUGUI pressEText;

    private bool isPlayerNear = false;

    void Start()
    {
        pressEText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            TeleportPlayer();
            isPlayerNear = false;
        }
    }

    void TeleportPlayer()
    {
        player.transform.position = teleportPoint.position;
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
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
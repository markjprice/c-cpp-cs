using Unity.AI.Navigation.LowLevel;
using UnityEngine;

public class HazardZone : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HazardZone_OnTriggerEnter");

        if (!other.TryGetComponent<PlayerController>(out _))
        {
            return;
        }

        Debug.Log("HazardZone_OnTriggerEnter_LoseGame");

        gameManager?.LoseGame();
    }
}

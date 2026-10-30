using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int crystalValue = 1;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<PlayerController>(out _))
        {
            return;
        }

        if (gameManager is null)
        {
            return;
        }

        gameManager.CollectCrystal(crystalValue);
        Destroy(gameObject);
    }
}

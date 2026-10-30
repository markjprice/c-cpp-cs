using UnityEngine;

public class ExitGate : MonoBehaviour
{
    [SerializeField] private Renderer gateRenderer;
    [SerializeField] private Material lockedMaterial;
    [SerializeField] private Material unlockedMaterial;

    private GameManager gameManager;
    private bool wasUnlocked;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        if (gateRenderer is null)
        {
            gateRenderer = GetComponent<Renderer>();
        }
    }

    private void Start()
    {
        UpdateGateAppearance();
    }

    private void Update()
    {
        if (gameManager is null)
        {
            return;
        }

        if (gameManager.IsExitUnlocked != wasUnlocked)
        {
            UpdateGateAppearance();
        }
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

        if (gameManager.IsExitUnlocked)
        {
            gameManager.WinGame();
        }
        else
        {
            int remaining =
                gameManager.RequiredCrystals - gameManager.CrystalsCollected;

            Debug.Log($"The exit is locked. Collect {remaining} more crystals.");
        }
    }

    private void UpdateGateAppearance()
    {
        if (gameManager is null || gateRenderer is null)
        {
            return;
        }

        wasUnlocked = gameManager.IsExitUnlocked;

        gateRenderer.material =
            wasUnlocked ? unlockedMaterial : lockedMaterial;
    }
}

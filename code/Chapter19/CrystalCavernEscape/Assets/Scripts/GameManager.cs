using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text crystalCounterText;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private int requiredCrystals = 6;

    private int crystalsCollected;
    private bool gameOver;

    public int CrystalsCollected => crystalsCollected;
    public int RequiredCrystals => requiredCrystals;
    public bool IsExitUnlocked => crystalsCollected >= requiredCrystals;
    public bool IsGameOver => gameOver;

    private void Start()
    {
        UpdateCrystalCounter();
        ShowMessage("Collect all crystals to unlock the exit.");
    }

    private void Update()
    {
        if (KeyboardQuitRequested())
        {
            QuitGame();
        }

        if (gameOver && KeyboardRestartRequested())
        {
            RestartScene();
        }
    }

    private static bool KeyboardQuitRequested()
    {
        return UnityEngine.InputSystem.Keyboard.current?.escapeKey
            .wasPressedThisFrame == true;
    }

    private static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void CollectCrystal(int amount)
    {
        if (gameOver)
        {
            return;
        }

        crystalsCollected += amount;
        crystalsCollected = Mathf.Min(crystalsCollected, requiredCrystals);

        UpdateCrystalCounter();

        if (IsExitUnlocked)
        {
            ShowMessage("Exit unlocked! Reach the gate to escape.");
        }
    }

    public void WinGame()
    {
        if (gameOver)
        {
            return;
        }

        gameOver = true;
        ShowMessage("You escaped! Press R to restart.");
    }

    public void LoseGame()
    {
        if (gameOver)
        {
            return;
        }

        gameOver = true;
        ShowMessage("You were caught! Press R to restart.");
    }

    private void UpdateCrystalCounter()
    {
        if (crystalCounterText is null)
        {
            return;
        }

        crystalCounterText.text =
            $"Crystals: {crystalsCollected}/{requiredCrystals}";
    }

    private void ShowMessage(string message)
    {
        if (messageText is null)
        {
            return;
        }

        messageText.text = message;
    }

    private static bool KeyboardRestartRequested()
    {
        return UnityEngine.InputSystem.Keyboard.current?.rKey.wasPressedThisFrame
            == true;
    }

    private static void RestartScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
    }
}

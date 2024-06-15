using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    // Singleton instance
    public static SettingsManager Instance { get; private set; }

    // References
    public GameObject optionsPanel;
    public Slider volumeSlider;
    public Button muteButton;
    public Button backButton;
    public GameObject backButtonObject; // GameObject to enable/disable back button

    private bool isMuted = false;
    private Sprite[] musicStateSprites;

    private void Awake()
    {
        // Implement singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(SetVolume);
            volumeSlider.value = AudioListener.volume * 100; // Initialize slider value
        }

        if (muteButton != null)
        {
            muteButton.onClick.AddListener(ToggleMute);
        }

        if (backButton != null)
        {
            backButton.onClick.AddListener(GoBack);
        }

        // Load music state sprites from Resources
        LoadMusicStateSprites();

        // Initialize mute button texture
        UpdateMuteButtonSprite();
    }

    private void Update()
    {
        // Check if the current scene is the menu scene
        if (SceneManager.GetActiveScene().buildIndex == 0) // Assuming 0 is the menu scene index
        {
            backButtonObject.SetActive(false);
        }
        else
        {
            backButtonObject.SetActive(true);
        }
    }

    // Method to toggle options panel
    public void ToggleOptionsPanel()
    {
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(!optionsPanel.activeSelf);
        }
        else
        {
            Debug.LogWarning("Options Panel is not assigned.");
        }
    }

    // Method to set volume
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume / 100;
    }

    // Method to mute/unmute
    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;

        // Update mute button sprite
        UpdateMuteButtonSprite();
    }

    // Method to update the mute button sprite and color
    private void UpdateMuteButtonSprite()
    {
        if (muteButton != null && musicStateSprites != null && musicStateSprites.Length == 2)
        {
            muteButton.image.sprite = isMuted ? musicStateSprites[1] : musicStateSprites[0];

            Color buttonColor = muteButton.image.color;
            buttonColor.a = isMuted ? 0.5f : 1f;
            muteButton.image.color = buttonColor;
        }
    }

    // Method to load music state sprites from Resources
    private void LoadMusicStateSprites()
    {
        var allSprites = Resources.LoadAll<Sprite>("Sprites/UI/Icons"); // Load all sprites in Resources folder
        musicStateSprites = allSprites.Where(sprite => sprite.name.StartsWith("musicState")).OrderBy(sprite => sprite.name).ToArray();
    }

    // Method to go back to the previous scene
    public void GoBack()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex > 0)
        {
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
    }
}

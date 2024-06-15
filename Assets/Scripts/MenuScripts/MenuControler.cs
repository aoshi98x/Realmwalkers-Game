using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControler : MonoBehaviour
{
    public Button optionsButton;

    private void Start()
    {
        optionsButton.onClick.AddListener(OpenOptions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        if(SceneManager.GetActiveScene().buildIndex < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OpenOptions()
    {
        if (SettingsManager.Instance != null)
        {
            SettingsManager.Instance.ToggleOptionsPanel();
        }
        else
        {
            Debug.LogWarning("SettingsManager no está presente en la escena.");
        }
    }

}

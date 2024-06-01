using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumExample : MonoBehaviour
{
    public enum GameMode {VisualNovel, Crafting, Battle, Shop, Stoped};
    public GameMode gameMode;
    public string button;

    void Update()
    {
        switch (button)
        {
            case "Dialogos":
                gameMode = GameMode.VisualNovel;
            break;

            case "Crafteo":
                gameMode = GameMode.Crafting;
            break;

            case "Batalla":
                gameMode = GameMode.Battle;
            break;   

            case "Tienda":
                gameMode = GameMode.Shop;
            break;
            default:
                gameMode = GameMode.Stoped;
            break;
        }
        GameFlow(gameMode);
    }

    void GameFlow(GameMode gameMode)
    {
        switch (gameMode)
        {
            case GameMode.VisualNovel:
                Debug.Log("Leyendo...");
            break;
            case GameMode.Battle:
                Debug.Log("En tu cara bitch!");
            break;
            case GameMode.Crafting:
                Debug.Log("Ay esta grasa no se quita... ");
            break;
            case GameMode.Shop:
                Debug.Log("Veci regaleme por fa de tan");
            break;
            case GameMode.Stoped:
            break;
        }
    }
}

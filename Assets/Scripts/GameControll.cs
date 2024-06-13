using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;
using TMPro;
using System;

public class GameControll : MonoBehaviour
{
    public GameObject fungusGameObject;
    public GameObject shopGameObject;
    public Flowchart flowchart;
    [SerializeField] private int positionInHistory = -1;
    public List<string> Scens = new List<string>();
    public string bloqueNombre;

    public void chanceName(TextMeshProUGUI name)
    {
        string nombre = name.text.ToString();
        print(nombre);
        
        //flowchart.SetVariable<string>("PlayerName", nombre);
        Debug.Log("ya tienes otro nombre");
    }
    public void ActiveShop()
    {
        positionInHistory += 1;
        bloqueNombre = Scens[positionInHistory];
        if (fungusGameObject != null)
        {
            fungusGameObject.SetActive(false);
        }
        if (shopGameObject != null)
        {
            shopGameObject.SetActive(true);
        }
    }

    public void ActiveFungus()
    {
        // Activa el controlador de Fungus
        if (fungusGameObject != null)
        {
            fungusGameObject.SetActive(true);
        }

        // Opcionalmente, salta a un bloque específico
        if (flowchart != null && !string.IsNullOrEmpty(bloqueNombre))
        {
            Block targetBlock = flowchart.FindBlock(bloqueNombre);
            if (targetBlock != null)
            {
                flowchart.ExecuteBlock(targetBlock);
            }
        }
    }


    
}

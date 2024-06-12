using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllMaintenance : MonoBehaviour
{
    private bool buttonManteinance;
    [SerializeField] private GameObject buttonManteinanceGameObject;

    void Update()
    {
        if (Input.GetMouseButton(0) && buttonManteinance == true)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rayDirection = Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, rayDirection);

            // Si el rayo golpea un collider
            if (hit.collider != null)
            {
                Debug.Log("Collider detectado: " + hit.collider.name);
            }
            else
            {
                buttonManteinance = false;
                buttonManteinanceGameObject.SetActive(true);
            }
        }
    }

    public void ActiveButtonManteinance()
    {
        buttonManteinance = true;
    }
}

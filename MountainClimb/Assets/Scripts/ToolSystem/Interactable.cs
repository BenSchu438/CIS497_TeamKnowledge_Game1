/*
 * Team Knowledge, Benjamin Schuster
 * SP Game 1 - Mountain Climb
 * Abstract supertype for interactable objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class Interactable : MonoBehaviour
{
    public bool playerClose = false;

    public Tools currentTool;

    // Set default tool to nothing
    void Awake()
    {
        currentTool = gameObject.AddComponent<Nothing>();
    }

    void Update()
    {
        // Interact if player is close
        if(Input.GetKeyDown(KeyCode.E) && playerClose)
        {
            UseTool();
        }
    }

    public void EquipAxe()
    {
        Destroy(GetComponent<Tools>());
        currentTool = gameObject.AddComponent<Axe>();
    }

    public void EquipPick()
    {
        Destroy(GetComponent<Tools>());
        currentTool = gameObject.AddComponent<Pick>();
    }

    public void UnEquip()
    {
        Destroy(GetComponent<Tools>());
        currentTool = gameObject.AddComponent<Nothing>();
    }

    public abstract void UseTool();

    // Determins if player is close enough to use
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerClose = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerClose = false;
    }
}

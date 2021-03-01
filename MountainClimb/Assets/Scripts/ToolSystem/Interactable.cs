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
    public bool hasAxe;
    public bool hasPick;

    public bool playerClose = false;

    public Tools currentTool;

    //temp demo text
    public Text equipText;

    // Set default tool to nothing
    void Awake()
    {
        currentTool = gameObject.AddComponent<Nothing>();
    }

    void Update()
    {
        // Equip tool if possible
        if(Input.GetKeyDown(KeyCode.Alpha1) && hasAxe)
        {
            // 1 - equip axe
            Destroy(GetComponent<Tools>());
            currentTool = gameObject.AddComponent<Axe>();
            equipText.text = "Currently Equipped: Axe";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && hasPick)
        {
            // 2 - equip picks
            Destroy(GetComponent<Tools>());
            currentTool = gameObject.AddComponent<Pick>();
            equipText.text = "Currently Equipped: Picks";
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            // Space - Unequip tools
            Destroy(GetComponent<Tools>());
            currentTool = gameObject.AddComponent<Nothing>();
            equipText.text = "Currently Equipped: Nothing";
        }

        // Interact if player is close
        if(Input.GetKeyDown(KeyCode.E) && playerClose)
        {
            UseTool();
        }
    }

    public abstract void UseTool();

    // Use these when player obtains tools in level
    public void ObtainAxe()
    {
        hasAxe = true;
    }
    public void ObtainPick()
    {
        hasPick = true;
    }

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

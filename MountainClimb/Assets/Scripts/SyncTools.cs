using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncTools : MonoBehaviour
{
    // Use this to tell all interactables when a new tool is equipped
    public GameObject[] trees;
    public GameObject[] walls;

    private void Awake()
    {
        // get all trees and walls
        trees = GameObject.FindGameObjectsWithTag("CuttableTree");
        walls = GameObject.FindGameObjectsWithTag("ClimbableWall");
    }

    public void SyncAxe()
    {
        foreach (GameObject trees in trees)
            trees.GetComponent<Interactable>().EquipAxe();
        foreach (GameObject walls in walls)
            walls.GetComponent<Interactable>().EquipAxe();
    }
    public void SyncPick()
    {
        foreach (GameObject trees in trees)
            trees.GetComponent<Interactable>().EquipPick();
        foreach (GameObject walls in walls)
            walls.GetComponent<Interactable>().EquipPick();
    }
    public void SyncNothing()
    {
        foreach (GameObject trees in trees)
            trees.GetComponent<Interactable>().UnEquip();
        foreach (GameObject walls in walls)
            walls.GetComponent<Interactable>().UnEquip();
    }
}

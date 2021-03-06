/*
 * Team Knowledge, Benjamin Schuster
 * SP Game 1 - Mountain Climb
 * concrete axe type that, when used, makes sure that an axe item is equipped
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Tools, IObserver
{
    public GameObject buttonRef;

    public void NewCommand(bool b)
    {
        buttonRef.SetActive(b);
    }

    public override bool Use(GameObject i)
    {
        return i.CompareTag("CuttableTree");
    }
}

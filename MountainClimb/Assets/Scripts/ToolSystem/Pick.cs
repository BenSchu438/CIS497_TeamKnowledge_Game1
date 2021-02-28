/*
 * Team Knowledge, Benjamin Schuster
 * SP Game 1 - Mountain Climb
 * concrete pick type that, when used, makes sure that an pick item is equipped
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : Tools
{
    public override bool Use(GameObject i)
    {
        return i.CompareTag("ClimbableWall");
    }
}

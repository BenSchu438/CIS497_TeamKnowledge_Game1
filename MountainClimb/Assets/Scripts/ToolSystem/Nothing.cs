/*
 * Team Knowledge, Benjamin Schuster
 * SP Game 1 - Mountain Climb
 * concrete nothing type that, when used, does nothing
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nothing : Tools
{
    public override bool Use(GameObject i)
    {
        //will always fail use when no tool equipped
        return false;
    }
}

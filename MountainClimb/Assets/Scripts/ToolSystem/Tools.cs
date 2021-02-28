/*
 * Team Knowledge, Benjamin Schuster
 * SP Game 1 - Mountain Climb
 * abstract supertype for tools
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tools : MonoBehaviour
{
    public abstract bool Use(GameObject i);
}

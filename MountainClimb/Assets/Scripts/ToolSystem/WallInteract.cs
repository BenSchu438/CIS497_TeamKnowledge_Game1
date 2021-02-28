/*
 * Team Knowledge, Benjamin Schuster
 * SP Game 1 - Mountain Climb
 * concrete wall interaction object, when used, move player to top
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallInteract : Interactable
{
    public GameObject startPlayer;
    public GameObject midPlayer;
    public GameObject finalPlayer;

    //reference to player 
    public GameObject player;

    public float waitTime1;
    public float waitTime2;

    private void Awake()
    {
        //disable the fallenlog incase its left on
        player = GameObject.FindGameObjectWithTag("Player");
        currentTool = gameObject.AddComponent<Nothing>();
    }

    public override void UseTool()
    {
        if (currentTool.Use(this.gameObject))
        {
            // Move player to top of wall
            Debug.Log("Start climbing wall...");
            StartCoroutine(ClimbWall(startPlayer.transform.position, midPlayer.transform.position, finalPlayer.transform.position));
        }
    }

    IEnumerator ClimbWall(Vector3 startPoint, Vector3 midPoint, Vector3 endPoint)
    {
        // Instead of moving player, move the player model and hide the actual player object
        startPlayer.SetActive(true);
        player.SetActive(false);

        // Fix bug where teleporting player technically doesnt trigger 'OnTriggerExit' method in parent
        playerClose = false;

        // Climb up wall
        float time = 0;
        while (time < waitTime1)
        {
            startPlayer.transform.position = Vector3.Lerp(startPlayer.transform.position, midPoint, time / waitTime1);
            time += Time.deltaTime;
            yield return null;
        }
        startPlayer.transform.position = midPoint;
        // Climb over ledge
        time = 0;
        while(time < waitTime2)
        {
            startPlayer.transform.position = Vector3.Lerp(startPlayer.transform.position, endPoint, time / waitTime2);
            time += Time.deltaTime;
            yield return null;
        }
        startPlayer.transform.position = endPoint;

        // Teleport actual player object to top, put temp player model back, reverse their visability
        startPlayer.SetActive(false);
        startPlayer.transform.position = startPoint;
        player.transform.position = endPoint;
        player.SetActive(true);
        

        yield return null;
    }
}

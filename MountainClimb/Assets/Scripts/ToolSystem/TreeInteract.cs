/*
 * Team Knowledge, Benjamin Schuster
 * SP Game 1 - Mountain Climb
 * concrete tree interaction object, when used, chop down tree
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteract : Interactable
{
    //fallen log is for reference
    public GameObject standingLog;
    public GameObject fallenLog;
    public float waitTime;

    private void Awake()
    {
        //disable the fallenlog incase its left on
        fallenLog.SetActive(false);
        currentTool = gameObject.AddComponent<Nothing>();
    }

    public override void UseTool()
    {
        if (currentTool.Use(this.gameObject))
        {
            //chop down tree
            Vector3 endPos = fallenLog.transform.position;
            Quaternion endRot = fallenLog.transform.rotation;
            StartCoroutine(TreeFall(endPos, endRot));
        }
    }

    //make standing log smoothly fall where fallen log is
    IEnumerator TreeFall(Vector3 endPos, Quaternion endRot)
    {
        float time = 0;
        Vector3 startPos = standingLog.transform.position;
        Quaternion startRot = standingLog.transform.rotation;

        while(time < waitTime)
        {
            time += Time.deltaTime;
            standingLog.transform.position = Vector3.Lerp(startPos, endPos, time / waitTime);
            standingLog.transform.rotation = Quaternion.Lerp(startRot, endRot, time / waitTime);
            
            yield return null;
        }
        standingLog.transform.position = fallenLog.transform.position;
        standingLog.transform.rotation = fallenLog.transform.rotation;
        yield return null;
    }
}

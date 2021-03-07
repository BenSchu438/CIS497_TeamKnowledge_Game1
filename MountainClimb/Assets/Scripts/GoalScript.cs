using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            gameManager.GetComponent<GameManager>().EndLevel();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnPlayer : MonoBehaviour
{
    public GameObject fadeScreen;
    public float fadeSpeed;

    public Vector3 lastCheckpoint;

    private void Start()
    {
        lastCheckpoint = transform.position;
    }

    public float bottomLimit = -10f;

    private void Update()
    {
        // if player falls off map, respawn
        if (transform.position.y < bottomLimit)
            Respawn();
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        lastCheckpoint = newCheckpoint;
    }

    private void Respawn()
    {
        StartCoroutine(Fade(fadeSpeed, lastCheckpoint));
    }

    public IEnumerator Fade(float fadeSpeed, Vector3 lastCheckpoint)
    {
        // fade out
        Color objectColor = fadeScreen.GetComponent<Image>().color;
        float fadeAmount;

        while(fadeScreen.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            fadeScreen.GetComponent<Image>().color = objectColor;
            yield return null;
        }

        // after dark, turn off player movement
        float temp = GetComponent<PlayerController>().speed;
        GetComponent<PlayerController>().speed = 0;
        transform.position = lastCheckpoint;
        yield return new WaitForSeconds(1f);

        // fade in
        while (fadeScreen.GetComponent<Image>().color.a > 0)
        {
            fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            fadeScreen.GetComponent<Image>().color = objectColor;
            yield return null;
        }

        // return players speed
        GetComponent<PlayerController>().speed = temp;
    }
}

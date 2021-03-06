using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, ISubject
{
    // add here when collecting in game
    List<IObserver> collectedTools = new List<IObserver>();
    // Use this to initialize reaquired tools from previous level. Fill in inspector
    public GameObject[] storedTools;

    public bool opened = false;
    public float transTime;
    public Vector3 openPos;
    public Vector3 closePos;
    
    private void Awake()
    {
        // register each precollected tool
        foreach (GameObject icons in storedTools)
        {
            this.RegisterTool(icons.GetComponent<IObserver>());
        }
    }

    public void RegisterTool(IObserver s)
    {
        if (collectedTools != null && !collectedTools.Contains(s))
            collectedTools.Add(s);
    }

    public void ToggleViewable()
    {
        foreach (IObserver icons in collectedTools)
            icons.NewCommand(opened);
    }

    public void UnRegisterTool(IObserver s)
    {
        if (collectedTools.Contains(s))
            collectedTools.Remove(s);
    }

    // When I is pressed, open inventory
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && opened)
        {
            Debug.Log("Close Inventory");
            opened = false;
            //StartCoroutine(MoveTo(openPos, closePos));
            this.GetComponent<RectTransform>().anchoredPosition = closePos;

            ToggleViewable();
        }
        else if(Input.GetKeyDown(KeyCode.I) && !opened )
        {
            Debug.Log("Open Inventory");
            opened = true;
            //StartCoroutine(MoveTo(closePos, openPos));
            this.GetComponent<RectTransform>().anchoredPosition = openPos;

            ToggleViewable();
        }
    }

    //IEnumerator MoveTo(Vector3 start, Vector3 end)
    //{
    //    float time = 0;
    //    while (time <= transTime)
    //    {
    //        time += Time.deltaTime;
    //        this.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(this.GetComponent<RectTransform>().anchoredPosition, end, (time / transTime));
    //    }
    //    yield return null;
    //}
}

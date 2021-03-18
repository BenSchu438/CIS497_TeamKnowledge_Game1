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
    //public float transTime;
    public Vector3 openPos;
    public Vector3 closePos;
    public GameObject openInvBut;
    public GameObject closeInvBut;
        
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

    // When tab is pressed, open inventory
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && opened)
        {
            CloseInv();
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && !opened )
        {
            OpenInv();
        }
    }

    public void OpenInv()
    {
        Debug.Log("Open Inventory");
        opened = true;
        this.GetComponent<RectTransform>().anchoredPosition = openPos;
        openInvBut.SetActive(false);
        closeInvBut.SetActive(true);

        ToggleViewable();
    }
    public void CloseInv()
    {
        Debug.Log("Close Inventory");
        opened = false;
        this.GetComponent<RectTransform>().anchoredPosition = closePos;
        openInvBut.SetActive(true);
        closeInvBut.SetActive(false);

        ToggleViewable();
    }
}

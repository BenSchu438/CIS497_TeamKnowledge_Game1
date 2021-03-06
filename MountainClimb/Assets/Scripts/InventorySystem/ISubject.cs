using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    public void RegisterTool(IObserver s);
    public void UnRegisterTool(IObserver s);
    public void ToggleViewable();
}

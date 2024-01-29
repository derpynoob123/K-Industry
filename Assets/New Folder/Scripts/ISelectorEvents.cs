using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ISelectorEvents
{
    public void AddObserverToSelectedEvent(Action observer);
    public void AddObserverToDeselectedEvent(Action observer);
}

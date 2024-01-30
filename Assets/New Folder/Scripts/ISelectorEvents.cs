using System;

public interface ISelectorEvents
{
    public void AddObserverToSelectedEvent(Action observer);
    public void AddObserverToDeselectedEvent(Action observer);
}

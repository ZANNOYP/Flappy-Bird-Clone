using System;

public interface IRepeatTimer
{
    void StartRepeat(float interval, Func<bool> condition, Action tick);
    void StopRepeat();
}

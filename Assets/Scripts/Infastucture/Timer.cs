using System;

public class Timer
{
    private readonly float _round;
    private readonly Action _onTimerRound;

    private float _accumulatedTime;
    
    public Timer(float round, Action onTimerRound)
    {
        onTimerRound = onTimerRound ?? throw new ArgumentNullException();
        
        _round = round;
        _onTimerRound = onTimerRound;
    }

    public void Tick(float deltaTime)
    {
        _accumulatedTime += deltaTime;
        
        if (_accumulatedTime >= _round) 
            Round();
    }

    private void Round()
    {
        _onTimerRound();
        _accumulatedTime = 0;
    }
}
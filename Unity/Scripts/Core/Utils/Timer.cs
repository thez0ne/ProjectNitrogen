using System;

// Author: Anik Patel
// Description: Unity independant timer that can be used in MonoBehaviours
// Version: 1.0
// Changes: [N/A]
namespace Zone.Core.Utils
{
    public class Timer
    {
        public float _duration { get; private set;}

        // Event to subscribe a method for when the timer is done
        public event Action OnTimerEnd;


        public Timer(float duration)
        {
            _duration = duration;
        }

        public void Tick(float dt)
        {
            // Timer is done
            if (_duration <= 0f)
            {
                return;
            }

            _duration -= dt;

            // Timer is not done
            if (_duration > 0f)
            {
                return;
            }

            OnTimerEnd?.Invoke();
        }
    }
}
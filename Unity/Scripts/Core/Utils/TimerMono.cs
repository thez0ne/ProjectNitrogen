using UnityEngine;

// Author: Anik Patel
// Description: MonoBehaviour base class for a Timer, extend this and implement HandleTimerEnd before attaching to a GameObject
// Version: 1.0
// Changes: [N/A]
namespace Zone.Core.Utils
{
    public abstract class TimerMono : MonoBehaviour
    {
        [SerializeField] float duration;
        private Timer timer;

        void Start()
        {
            timer = new Timer(duration);
            timer.OnTimerEnd += HandleTimerEnd;
        }

        void Update()
        {
            timer.Tick(Time.deltaTime);
        }

        protected abstract void HandleTimerEnd();
    }
}
using UnityEngine;

namespace DBSkillSystem
{
    public class GameTimer
    {
        public bool IsFinish => countDown >= Duration;
        public float Duration { get; set; }

        public float countDown = 0f;

        public GameTimer(float duration)
        {
            Duration = duration;
        }
        
        public void Update()
        {
            if (!IsFinish)
            {
                countDown += Time.deltaTime * 1000;
            }
        }

        public void Reset()
        {
            countDown = 0;
        }
    }
}
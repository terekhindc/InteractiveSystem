using System;
using UnityEngine.Events;

namespace VR_Corp.InteractiveSystem.EventsCollection
{
    [Serializable]
    public class TriggerEvents
    {
        public UnityEvent detect;
        public UnityEvent stay;
        public UnityEvent lost;
    }
}
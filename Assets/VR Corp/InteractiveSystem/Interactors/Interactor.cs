using UnityEngine;
using UnityEngine.Events;
using VR_Corp.InteractiveSystem.EventsCollection;

namespace VR_Corp.InteractiveSystem.Interactors
{
    [AddComponentMenu("VRCORP/InteractiveSystem/Interactors/BaseInteractor")]
    public class Interactor : MonoBehaviour
    {
        [SerializeField]public TriggerEvents events;
    }
}

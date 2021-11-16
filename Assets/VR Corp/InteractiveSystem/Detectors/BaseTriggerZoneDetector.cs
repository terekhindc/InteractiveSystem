using System;
using UnityEngine;
using VR_Corp.InteractiveSystem.Interactors;

namespace VR_Corp.InteractiveSystem.Detectors
{
    [AddComponentMenu("VRCORP/InteractiveSystem/Detectors/BaseTriggerZoneDetector")]
    [RequireComponent(typeof(SphereCollider))]
    [ExecuteAlways]
    public class BaseTriggerZoneDetector : MonoBehaviour
    {
        [Range(1,100)] public int distance = 1;
        private SphereCollider m_Collider;

        private void OnEnable()
        {
            m_Collider = GetComponent<SphereCollider>();
            m_Collider.radius = distance;
            m_Collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.TryGetComponent(out Interactor interactable))
                interactable.events.detect.Invoke();
        }

        private void OnTriggerStay(Collider col)
        {
            if (col.gameObject.TryGetComponent(out Interactor interactable))
                interactable.events.stay.Invoke();
        }
        
        private void OnTriggerExit (Collider col)
        {
            if (col.gameObject.TryGetComponent(out Interactor interactable))
                interactable.events.lost.Invoke();
        }

        private void OnDrawGizmos()
        {
            m_Collider.radius = distance;
            Gizmos.DrawSphere(transform.position, distance);
        }
    }
}

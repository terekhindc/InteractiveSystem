using System;
using UnityEngine;
using VR_Corp.InteractiveSystem.Interactors;

namespace VR_Corp.InteractiveSystem.Detectors
{
    [AddComponentMenu("VRCORP/InteractiveSystem/Detectors/RayDetector")]
    [RequireComponent(typeof(LineRenderer))]
    [ExecuteAlways]
    public class RayDetector : MonoBehaviour
    {
        private LineRenderer m_LineRenderer;
        [Range(1, 100)] public int distance = 1;
        private Interactor m_Interactable;

        private void OnEnable()
        {
            m_LineRenderer = GetComponent<LineRenderer>();
            m_LineRenderer.useWorldSpace = false;
            m_LineRenderer.SetPosition(1, Vector3.zero);
            m_LineRenderer.startWidth = 0.03f;
            m_LineRenderer.endWidth = 0.03f;
        }

        private void Update()
        {
            Launch();
        }

        private void Launch ()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 200))
            {
                if (hit.transform.TryGetComponent(out Interactor interactable))
                {
                    m_LineRenderer.SetPosition(1, (Vector3.forward*100));
                    m_Interactable = interactable;
                    m_Interactable.events.detect.Invoke();
                }
                else
                {
                    if (m_Interactable is null) return;
                    m_Interactable = null;
                    m_Interactable.events.lost.Invoke();
                }
            }
            else
            {
                m_LineRenderer.SetPosition(1, (Vector3.zero));
                if (m_Interactable is null) return;
                m_Interactable.events.lost.Invoke();
                m_Interactable = null;
            }
        }

        private void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position, transform.forward*distance, Color.green, 1);
        }
    }
}

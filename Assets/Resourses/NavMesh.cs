using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
	NavMeshAgent m_MeshAgent;
	Vector3 m_TargetPoint;
	public Transform[] pathPoints;
	int m_IDPoint = 0;


	void Start ()
	{
		m_MeshAgent = GetComponent<NavMeshAgent> ();
		m_TargetPoint = transform.position;
		m_MeshAgent.SetDestination (pathPoints [m_IDPoint].position);
	}

	void Update ()
	{
		/*if (Input.GetAxis("Mouse Y")>0.01){
            Debug.Log("Time.deltaTime * Input.GetAxis(\"Mouse Y\") == " + Time.deltaTime * Input.GetAxis("Mouse Y"));
            Camera.main.transform.rotation = Quaternion.AngleAxis(60f * Input.GetAxis("Mouse X"), Input.mousePosition);
        }*/
		/*if(Input.GetMouseButtonDown(1)){
            Ray m_Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit m_hit;
            if(Physics.Raycast(m_Ray, out m_hit)){
                m_TargetPoint = m_hit.point;
            }
        }
        m_MeshAgent.SetDestination(m_TargetPoint);*/

		if (Vector3.Distance (transform.position, pathPoints [m_IDPoint].position) < 1.5) {
			// Debug.Log("Vector3.Distance(transform.position, pathPoints[m_IDPoint].position) == " + Vector3.Distance(transform.position, pathPoints[m_IDPoint].position));
			m_IDPoint = ++m_IDPoint % pathPoints.Length;
			m_MeshAgent.SetDestination (pathPoints [m_IDPoint].position);
		}
	}
}

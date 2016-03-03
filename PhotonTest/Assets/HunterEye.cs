using UnityEngine;
using System.Collections;

public class HunterEye : MonoBehaviour {

    public Hunter hunter;
	// Use this for initialization
    private NavMeshAgent agent;
    private int floorMask;

    void Start() {
        hunter = this.transform.parent.GetComponent<Hunter>();
        agent = this.transform.parent.parent.GetComponent<NavMeshAgent>();
        floorMask = LayerMgr.GetGroupToLayer("floor");
    
    }
    

    void OnTriggerStay(Collider other)
    {
        if (agent == null) return;
            //agentを使ってあたり判定
            NavMeshHit hit;
            if(agent.Raycast(other.transform.position, out hit))
            {
                    
                   // Debug.Log("障害物があって見えない");
                    hunter.LostTarget(other.gameObject);
            }
            else
            {
                if (other.gameObject.layer + 3 == hunter.gameObject.layer)
                {
                    //発見
                    Debug.Log("見える");
                    hunter.GoTarget(other.transform);
                }
                else
                {
                    hunter.LostTarget(other.gameObject);
               //     Debug.Log("違う階だから見えない");
                }

            }
        
        /*
         * 
         Vector3 direction = ((this.transform.position) - other.transform.position);
         Vector3 normal = direction.normalized;
         Ray ray = new Ray((this.transform.position), normal);
         Debug.DrawRay((this.transform.position), normal, Color.red);
         RaycastHit hita;
         if (Physics.Raycast(ray, out hita, 100, floorMask))
         {
             Debug.Log("見えない" + hita.transform.name);
         }
         */

    }
}

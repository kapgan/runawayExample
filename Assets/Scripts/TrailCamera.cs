using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    /*[SerializeField]
    private Transform target;
    [SerializeField]
    float trailDistance = 5.0f;
    [SerializeField]
    float heighOffset = 3.0f;
    [SerializeField]
    float CameraDelay = 0.02f;

    void Update()
    {
        Vector3 followPos = target.position - target.forward * trailDistance;
        followPos.y += heighOffset;
        transform.position += (followPos - transform.position) * CameraDelay;
        transform.LookAt(target.transform);
    }*/
    public class TrailCamera : MonoBehaviour
    {
        public Transform target;        
        public float distance;            
        public float maxDriftRange;       
        public float angleX;          
        public float angleY;           
    public float z=0;
    private Transform m_transform_cache;    
        private Transform myTransform
        {
            get
            {
                if (m_transform_cache == null)
                {
                    m_transform_cache = transform;
                }
                return m_transform_cache;
            }
        }

        
        void OnValidate()
        {
            if (target != null)
            {
                Vector3 targetPos = GetTargetPos();
              
                myTransform.position = targetPos;
               
                myTransform.LookAt(target);
            }
        }

      
        void LateUpdate()
        {

            Vector3 targetPos = GetTargetPos();
           
            float t = Vector3.Distance(myTransform.position, targetPos) / maxDriftRange;

           
            myTransform.position = Vector3.Lerp(myTransform.position, targetPos, t * Time.deltaTime);
         
            myTransform.LookAt(target);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(myTransform.position, target.position);
        }

        private Vector3 GetTargetPos()
        {
            Vector3 targetPos = new Vector3(0, z, -distance);
            
            targetPos = Quaternion.Euler(angleX, angleY, 0) * targetPos;
                
            return target.position + (target.rotation * targetPos);
        }
    }



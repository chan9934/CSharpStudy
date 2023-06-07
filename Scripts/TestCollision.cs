using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision {collision.gameObject.name}");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger {other.gameObject.name}");
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log($"{hit.collider.gameObject.name}");
            }
            //Vector3 mousPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            //Vector3 dir = mousPos - Camera.main.transform.position;
            //dir = dir.normalized;

            //RaycastHit hit;
            //Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);
            //if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
            //{
            //    Debug.Log($"{hit.collider.name}");
            //}
        }
    }
}

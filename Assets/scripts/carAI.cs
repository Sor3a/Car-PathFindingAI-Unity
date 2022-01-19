using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carAI : MonoBehaviour
{
    [SerializeField] float speed,distance,slowedSpeed;
    [SerializeField] LayerMask blockLayer;
    [SerializeField] Transform end1, end2;
    float realSpeed,rotation = 0f;
    Transform checker1, checker2;
    Collider oldhit;
    float mvtDirection = 1f;
    private void Awake()
    {
        checker1 = transform.GetChild(0);
        checker2 = transform.GetChild(1);
    }

    private void Start()
    {
        realSpeed = speed;
    }
    private void FixedUpdate()
    {
        Ray r = new Ray(transform.position, Vector3.forward);
        Ray r2 = new Ray(checker1.position, Vector3.forward);
        Ray r3 = new Ray(checker2.position, Vector3.forward);
        RaycastHit hit ;



        if (Physics.Raycast(r, out hit,distance, blockLayer) || Physics.Raycast(r2,out hit, distance, blockLayer ) || Physics.Raycast(r3,out hit, distance, blockLayer))
        {
            if (rotation == 0)
                mvtDirection = Vector2.Distance(transform.position, end1.position) >= Vector2.Distance(transform.position, end2.position) ? 1f : -1f;
            realSpeed = slowedSpeed;
            if (Mathf.Abs(rotation) < 25f)
                rotation += 4 * mvtDirection;

        }
        else
        {
            if (oldhit != null)
            {
                if (checker1.position.z >= oldhit.transform.position.z)
                {
                    realSpeed = speed;
                    if (rotation != 0)
                        rotation -= 4* mvtDirection;
                }
            }
            
        }

        if (hit.collider != null && hit.collider != oldhit)
        {
            oldhit = hit.collider;
        }

        transform.rotation = Quaternion.Euler(0, rotation, 0);
        transform.Translate(transform.forward * realSpeed * Time.deltaTime);
    }


}

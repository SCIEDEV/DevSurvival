using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 4.0f;

    public GameObject projectile;

    public float countdown = 0.1f;

    public float projectileVelocity = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, moveSpeed) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0, moveSpeed) * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetMouseButton(0))
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitOutput;
                var hit = Physics.Raycast(ray, out hitOutput, 100);
                if (hit)
                {
                    Vector3 hitPosition = hitOutput.point;
                    hitPosition.y = transform.position.y;

                    Vector3 direction = hitPosition - transform.position;

                    var proj = Instantiate(this.projectile, transform.position + direction.normalized * 1.5f, Quaternion.identity);
                    proj.GetComponent<Rigidbody>().velocity = direction.normalized * projectileVelocity;
                    proj.transform.forward = direction.normalized;
                }
                countdown = 0.1f;
            }

        }
    }
}
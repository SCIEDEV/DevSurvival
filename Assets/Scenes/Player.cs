using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 4.0f;

    public GameObject projectile;

    public float countdown = 0.1f;

    public float projectileVelocity = 30f;

    private CharacterController controller;

    public RectTransform healthBar;

    public float playerMaxHealth = 100;
    private float playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        playerHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDisplacement = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            moveDisplacement += new Vector3(0, 0, moveSpeed);// * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDisplacement -= new Vector3(0, 0, moveSpeed);// * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            moveDisplacement += new Vector3(moveSpeed, 0, 0);// * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveDisplacement -= new Vector3(moveSpeed, 0, 0);// * Time.deltaTime;
        }

        controller.SimpleMove(moveDisplacement);

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

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;

        //calculate percentage (0-1) of player health
        float percentage = playerHealth / playerMaxHealth;

        //get the MAX width of the healthbar (through finding the width of its parent)
        float parentWidth = ((RectTransform)healthBar.parent.transform).rect.width;

        //calculate the inverse of the bar width as a distance from the right, thus 1- percentage
        float barWidth = (1 - percentage) * parentWidth;

        //apply the offset (the RIGHT variable on the rect inspector)
        healthBar.offsetMax = new Vector2(-barWidth ,0);
    }
}
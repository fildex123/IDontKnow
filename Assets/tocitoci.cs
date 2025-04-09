using Unity.Mathematics;
using UnityEngine;

public class RotateAndMoveWithCenter : MonoBehaviour
{
    public GameObject protihrac;
    public GameObject hrac;
    public Transform centerObject;
    public HingeJoint2D joint;
    public float moveSpeed = 0f;
    public float acChange = 500f;
    public float sromax = 50f;
    public float max = 0f;
    public float rotchaneg = 500;
    public float test=3000;
    private Rigidbody2D centerRigidbody;
    public float silaDash = 100f;
    public float DashCooldown = 100;
    private void Start()
    {
        centerRigidbody = centerObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (centerObject.GetComponent<ui>().currentHealth > 0)
        {
            JointMotor2D motor = joint.motor;
            Vector2 direction = transform.up;
            DashCooldown+= Time.fixedDeltaTime;
            if (moveSpeed < 0.1 && moveSpeed > -0.1) { moveSpeed = 0; }
            if (motor.motorSpeed < 0.1 && motor.motorSpeed > -0.1) { motor.motorSpeed = 0; }
            moveSpeed *= 0.81f;
            motor.motorSpeed *= 0.81f;
            if (max > sromax)
            {
                max = sromax;
                moveSpeed = 0;
                transform.position = centerObject.position;
                transform.Translate(direction * test * Time.fixedDeltaTime, Space.World);
            }
            else if (max < -sromax)
            {
                max = -sromax;
                moveSpeed = 0;
                transform.position = centerObject.position;
                transform.Translate(-direction * test * Time.fixedDeltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.W) && (max < sromax))
            {
                moveSpeed += acChange * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.S) && (max > -sromax))
            {
                moveSpeed -= acChange * Time.fixedDeltaTime;
            }
            max += moveSpeed;
            transform.Translate(direction * moveSpeed * Time.fixedDeltaTime, Space.World);
            if (Input.GetKey(KeyCode.A))
            {
                motor.motorSpeed += rotchaneg * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                motor.motorSpeed -= rotchaneg * Time.fixedDeltaTime;
            }
            joint.motor = motor;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if(DashCooldown>5)
                {
                    if(max>=0)
                    {
                        centerObject.transform.Translate(direction * 100 * Time.fixedDeltaTime, Space.World);
                        centerRigidbody.AddForce(direction * silaDash, ForceMode2D.Force);
                    }
                    else
                    {
                        centerObject.transform.Translate(-direction * 100 * Time.fixedDeltaTime, Space.World);
                        centerRigidbody.AddForce(-direction * silaDash, ForceMode2D.Force);
                    }
                        DashCooldown = 0;
                }
            }
        }
        else
        {
            JointMotor2D motor = joint.motor;
            motor.motorSpeed = 0;
            joint.motor = motor;
            gameObject.SetActive(false);
            hrac.SetActive(false);
        }
    }
}
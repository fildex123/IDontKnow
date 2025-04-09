using Unity.Mathematics;
using UnityEngine;

public class RotateAndMoveWithCenter3 : MonoBehaviour
{
    public GameObject protihrac;
    public GameObject hrac;
    public Transform centerObject;// Støed kruhu
    public HingeJoint2D joint;
    public float moveSpeed = 0f;
    public float acChange = 500f;
    public float sromax = 50f;
    public float max = 0f;
    public float rotchaneg = 500;
    public float test = 3000;
    private void Start()
    {

    }
    void FixedUpdate()
    {
        if (centerObject.GetComponent<ui>().currentHealth > 0)
        {
            JointMotor2D motor = joint.motor;
            Vector2 direction = transform.up;
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
            if (Input.GetKey(KeyCode.UpArrow) && (max < sromax))
            {
                moveSpeed += acChange * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow) && (max > -sromax))
            {
                moveSpeed -= acChange * Time.fixedDeltaTime;
            }
            max += moveSpeed;
            transform.Translate(direction * moveSpeed * Time.fixedDeltaTime, Space.World);
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                motor.motorSpeed += rotchaneg * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                motor.motorSpeed -= rotchaneg * Time.fixedDeltaTime;
            }
            joint.motor = motor;
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
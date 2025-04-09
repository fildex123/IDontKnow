using Unity.Mathematics;
using UnityEngine;

public class RotateAndMoveWithCenter2 : MonoBehaviour
{
    public GameObject hrac;
    public GameObject protihrac;
    public Transform centerObject;
    public HingeJoint2D joint;
    public float moveSpeed = 0f;
    public float acChange = 500f;
    public float sromax = 50f;
    public float max = 0f;
    public float rotchaneg = 500;
    public float test = 3000;
    public float pocOp=0;
    public char op;
    public float rpocOp = 0;
    private System.Random random = new System.Random();
    public char rop;
    private void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (centerObject.GetComponent<ui>().currentHealth > 0)
        {
            if (pocOp < 1)
            {
                switch (random.Next(1, 4))
                {
                    case 1:
                        op = 'w';
                        pocOp = random.Next(1, 3);
                        break;
                    case 2:
                        op = 's';
                        pocOp = random.Next(1, 3);
                        break;
                    default:
                        op = 'n';
                        pocOp = random.Next(1, 3);
                        break;

                }
            }
            /*if (rpocOp < 1)
            {
                switch (random.Next(1, 4))
                {
                    case 1:
                        rop = 'd';
                        rpocOp = random.Next(1, 3);
                        break;
                    case 2:
                        rop = 'a';
                        rpocOp = random.Next(1, 3);
                        break;
                    default:
                        rop = 'n';
                        rpocOp = random.Next(1, 3);
                        break;
                }
            }*/

            if (hrac.transform.position.x > transform.position.y)
            {
                rop = 'd';
            }
            else
            {
                rop = 'a';
            }
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
            if (op == 'w')
            {
                if (max < sromax)
                    moveSpeed += acChange * Time.fixedDeltaTime;
            }
            if (op == 's')
            {
                if (max > -sromax)
                    moveSpeed -= acChange * Time.fixedDeltaTime;
            }
            max += moveSpeed;
            transform.Translate(direction * moveSpeed * Time.fixedDeltaTime, Space.World);
            if (rop == 'a')
            {
                motor.motorSpeed += rotchaneg * Time.fixedDeltaTime;
            }
            if (rop == 'd')
            {
                motor.motorSpeed -= rotchaneg * Time.fixedDeltaTime;
            }

            pocOp -= Time.fixedDeltaTime;
            rpocOp -= Time.fixedDeltaTime;
            joint.motor = motor;
        }
        else
        {
            JointMotor2D motor = joint.motor;
            motor.motorSpeed = 0;
            joint.motor = motor;
            gameObject.SetActive(false);
            protihrac.SetActive(false);
        }
    }
}
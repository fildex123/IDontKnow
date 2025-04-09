using System;
using UnityEngine;
public class vytvorPlatform : MonoBehaviour
{
    public GameObject circlePart;
    public GameObject hrac;
    public int RenderSize;
    void Start()
    {
        float vel= UnityEngine.Random.Range(1.0f,1.5f);
        Vytvor(vel, 1, 1);
        Vytvor(vel, -1, 1);
        Vytvor(vel, 1, -1);
        Vytvor(vel, -1, -1);
        hrac= GameObject.FindWithTag("Player");
    }
    private void Vytvor(float vel,float px,float py)
    {
        {
            GameObject pradol = Instantiate(circlePart, new Vector3(transform.position.x + px * vel*vel, transform.position.y+ py * vel*vel, 0), transform.rotation);
            pradol.transform.SetParent(transform);
            px= UnityEngine.Random.Range(vel, 2*vel);
            pradol.transform.localScale = new Vector3(px, px, 1f);
        }
    }
}

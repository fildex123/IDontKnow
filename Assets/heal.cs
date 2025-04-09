using UnityEngine;

public class heal : MonoBehaviour
{
    public string HealTaker = "takeHeal";
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(HealTaker))
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class sleduj_objekt : MonoBehaviour
{
    public Transform sleduj;
    void Start()
    {
        
    }
    void Update()
    {
        gameObject.transform.position = sleduj.position;
    }
}

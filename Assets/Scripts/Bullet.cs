using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float m_speed = 2f;
    public TankControler m_source;

    void Awake()
    {
        Destroy(gameObject, 20f);
    }

    void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * m_speed, Space.World);
    }
}

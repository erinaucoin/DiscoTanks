using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public TankControler m_tankControl;
    private int m_direction = 0;
    private float m_timeToSwitchDirection;
    private float m_timeToShoot = 1f;

    private void Awake()
    {
        m_tankControl = GetComponent<TankControler>();
    }

    private void Update()
    {
        m_timeToSwitchDirection -= Time.deltaTime;
        if (m_timeToSwitchDirection <= 0f)
            SwitchDirection();

        MoveTank();

        m_timeToShoot -= Time.deltaTime;
        if (m_timeToShoot <= 0f)
            MakeTheTankShoot();
    }

    private void MakeTheTankShoot()
    {
        if (m_tankControl != null)
        {
            m_tankControl.Shoot();
            m_timeToShoot = UnityEngine.Random.Range(0.75f, 1.25f);
        }
    }

    private void MoveTank()
    {
        if (m_tankControl != null)
        {
            switch (m_direction)
            {
                case 1:
                    m_tankControl.MoveUp();
                    break;

                case 2:
                    m_tankControl.MoveRight();
                    break;

                case 3:
                    m_tankControl.MoveDown();
                    break;

                case 4:
                    m_tankControl.MoveLeft();
                    break;
            }
        }
    }

    private void SwitchDirection()
    {
        m_direction = UnityEngine.Random.Range(1, 5);
        m_timeToSwitchDirection = UnityEngine.Random.Range(1.5f, 2.5f);
    }
}
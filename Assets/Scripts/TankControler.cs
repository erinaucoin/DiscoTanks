using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankControler : MonoBehaviour
{

    private static int scoreMain = 0;

    [SerializeField]
    public Animator m_animator;
    private Vector3 m_lookDirection = Vector3.up;
    private Vector3 m_bulletRotation = Vector3.zero;
    private Vector3 m_randomPosition = Vector3.zero;
    public KeyCode m_upButton;
    public KeyCode m_downButton;
    public KeyCode m_leftButton;
    public KeyCode m_rightButton;
    public KeyCode m_attackButton;
    public Bullet m_bullet;
    public EnemyAI m_enemy;
    public bool m_isControlledByPlayer = false;
    public string vulnerableTo;
    private int scoreCount = 0;
    public ScoreController m_scoreController;
    public ScoreController m_scoreControllerEnemy;

    public AudioSource m_downAudio;

    public HighscoreAsset m_highScoreAsset;


    void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetKey - pressed and held
        //GetKeyUp - let go on frame
        //GetKeyDown - pressed down on frame

        if (Input.GetKey(m_upButton))
        {
            MoveUp();

        }
        else if (Input.GetKey(m_downButton))
        {
            MoveDown();

        }
        else if (Input.GetKey(m_leftButton))
        {
            MoveLeft();
        }
        else if (Input.GetKey(m_rightButton))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(m_attackButton))
        {
            Shoot();
        }

        if (Input.GetKeyDown(m_downButton))
        {
            TurnDownForWhat();
        }

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    int prevScore;
        //    m_highScoreAsset.m_players.TryGetValue(m_highScoreAsset.playerName, out prevScore);

        //    if (prevScore < m_scoreControllerEnemy.GetScore())
        //        m_highScoreAsset.m_players[m_highScoreAsset.playerName] = m_scoreControllerEnemy.GetScore();
            
        //    SceneManager.LoadScene(0);
        //}
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals(vulnerableTo))
        {

            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null && bullet.m_source != this)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
                if (m_scoreController != null)
                {
                    m_scoreController.updateScore();
                }
            }
        }
    }

    public void TurnDownForWhat()
    {
        if (m_downAudio != null)
            m_downAudio.Play();
    }

    public void Shoot()
    {
        Bullet bullet = Instantiate(m_bullet, transform.position, Quaternion.identity);
        bullet.transform.Rotate(m_bulletRotation);
        bullet.m_source = this;
        //if (m_audio != null)
        //    m_audio.Play();

        if (m_isControlledByPlayer)
        {
            m_randomPosition = Random.insideUnitCircle;
            EnemyAI spawnedEnemy = Instantiate(m_enemy, m_randomPosition, Quaternion.identity);
            spawnedEnemy.m_tankControl = spawnedEnemy.GetComponent<TankControler>();
            spawnedEnemy.GetComponent<TankControler>().m_scoreController = m_scoreControllerEnemy;
        }
    }

    public void MoveUp()
    {
        m_animator.SetTrigger("TurnUp");
        m_lookDirection = new Vector3(0f, 1f, 0f);
        m_bulletRotation = new Vector3(0f, 0f, 0f);
        transform.Translate(m_lookDirection * Time.deltaTime);
    }

    public void MoveDown()
    {
        m_animator.SetTrigger("TurnDown");
        m_lookDirection = new Vector3(0f, -1f, 0f);
        m_bulletRotation = new Vector3(0f, 0f, 180f);
        transform.Translate(m_lookDirection * Time.deltaTime);
    }

    public void MoveRight()
    {
        m_animator.SetTrigger("RightSideOfLife");
        m_lookDirection = new Vector3(1f, 0f, 0f);
        m_bulletRotation = new Vector3(0f, 0f, -90f);
        transform.Translate(m_lookDirection * Time.deltaTime);
    }

    public void MoveLeft()
    {
        m_animator.SetTrigger("ToTheLeft");
        m_lookDirection = new Vector3(-1f, 0f, 0f);
        m_bulletRotation = new Vector3(0f, 0f, 90f);
        transform.Translate(m_lookDirection * Time.deltaTime);
    }
}

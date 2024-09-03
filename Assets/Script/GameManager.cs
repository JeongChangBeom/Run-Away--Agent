using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Clear;
    public GameObject GameoverText;
    public Image Dash;
    public GameObject Pause;
    public Text TimeText;
    public float time;

    private PlayerHealth playerhealth;
    public Text HealthText;
    private int healthcount;
    private bool isDead;

    public Text DashCooldownText;
    private float DashCooldown;
    private PlayerController playercontroller;

    private float Itemtimer1;
    private float Itemtimer2;
    private float Itemtimer3;
    public GameObject HealItem;
    public GameObject BarrierItem;
    public GameObject DestroyItem;

    public int itemX1, itemX2, itemY1, itemY2;


    void Start()
    {
        Time.timeScale = 1;

        playerhealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();

        isDead = false;
    }

    void Update()
    {
        if (!isDead)
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                time = 0;
                Time.timeScale = 0;
                Clear.SetActive(true);
            }
            TimeText.text = (int)time + "";

            healthcount = playerhealth.Health;

            if(healthcount <= 0)
            {
                healthcount = 0;

                playerhealth.Die();
            }
            HealthText.GetComponent<Text>().text = "X " + healthcount;

            DashCooldown = playercontroller.dashCoolCounter;
            
            if(DashCooldown <= 0)
            {
                Dash.color = Color.white;
                DashCooldownText.GetComponent<Text>().text = "";
            }
            else
            {
                Dash.color = Color.black;
                DashCooldownText.GetComponent<Text>().text =((int)DashCooldown + 1) + "";
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                Pause.SetActive(true);
            }

            //아이템 생성 범위 (스테이지별 수정)
            float RandomX = UnityEngine.Random.Range(itemX1, itemX2);
            float RandomY = UnityEngine.Random.Range(itemY1, itemY2);

            Vector2 RandomPos = new Vector2(RandomX, RandomY);

            Itemtimer1 += Time.deltaTime;

            if (Itemtimer1 > Random.Range(10, 15))
            {
                GameObject Spawnitem1 = Instantiate(HealItem, RandomPos, Quaternion.identity);
                Itemtimer1 = 0;
            }

            Itemtimer2 += Time.deltaTime;

            if (Itemtimer2 > Random.Range(20, 30))
            {
                GameObject Spawnitem2 = Instantiate(BarrierItem, RandomPos, Quaternion.identity);
                Itemtimer2 = 0;
            }

            Itemtimer3 += Time.deltaTime;

            if (Itemtimer3 > Random.Range(20, 30))
            {
                GameObject Spawnitem3 = Instantiate(DestroyItem, RandomPos, Quaternion.identity);
                Itemtimer3 = 0;
            }

        }
        else
        { 
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void EndGame()
    {
        //stageBgm.Stop();

        isDead = true;

        GameoverText.SetActive(true);

        Time.timeScale = 0;
    }

    public void reStart()
    {
        Time.timeScale = 1;
        Pause.SetActive(false);
    }

    public void goMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

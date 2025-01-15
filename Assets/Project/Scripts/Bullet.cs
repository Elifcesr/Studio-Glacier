using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float shotSpeed = 7f;
    public int bulletDamage = 10; 

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        transform.position += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "Enemy")
        //{
        //    Destroy(other.gameObject);
        //}
        //Destroy(this.gameObject);

        if (other.tag == "Enemy")
        {
            MusicController.instance.PlayBulletMusic();
            Destroy(gameObject);
            if(other.GetComponent<EnemyController>().currentHealth > 10)
            {
                other.GetComponent<EnemyController>().currentHealth -= bulletDamage;
                other.GetComponent<EnemyController>().UpdateEnemyHealthText(other.GetComponent<EnemyController>().currentHealth);
            }
            else if (other.GetComponent<EnemyController>().currentHealth <= 10)
            {
                other.GetComponent<EnemyController>().UpdateEnemyHealthText(0);
                other.GetComponent<BoxCollider2D>().enabled = false;
                Destroy(other.gameObject,.4f);

                //if (WaveManager.instance.enemyAmount == 1)
                //{
                //    GameManager.instance.StartCoroutine(GameManager.instance.EndLevelCo());
                //}
                //else
                //{
                //    WaveManager.instance.enemyAmount--;
                //}
                WaveManager.instance.enemyAmount--;
                Debug.Log("WaveManager.instance.enemyAmount : " + WaveManager.instance.enemyAmount);
            }
            //else
            //{
            //    other.GetComponent<EnemyController>().UpdateEnemyHealthText(0);
            //    Destroy(other.gameObject,.4f);

            //    if (WaveManager.instance.enemyAmount == 0)
            //    {
            //        StartCoroutine(GameManager.instance.EndLevelCo());
            //    }
            //    else
            //    {
            //        WaveManager.instance.enemyAmount--;
            //    }
            //}
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
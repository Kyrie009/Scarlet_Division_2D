using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameBehaviour
{
    public EnemyData enemyData;
    int health;
    int attack;
    int knockback;
  
    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    public void Setup()
    {
        health = enemyData.health;
        attack = enemyData.attack;
        knockback = enemyData.knockBack;
    }
    //damage on contact - might want to use ontrigger enter for enemies here.
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Enemy Damage
            _P.Hit(attack);
            //Knockback
      
        }

    }

    //Takes Damage
    public void Hit(int _dmg)
    {       
        health -= _dmg;
        StartCoroutine(GotHit());
        if (IsDead())
        {
            Destroy(this.gameObject);
            //enemydies
        }
    }
    //Hit indicator
    IEnumerator GotHit()
    {       
        this.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<SpriteRenderer>().color = Color.white; 
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}

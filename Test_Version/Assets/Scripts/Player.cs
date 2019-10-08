using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    bool canAttack = true;
    

    // Start is called before the first frame update
    void Start()
    {
        _hp = 80;
        _damage = 10;
        _defence = 1;
        _evasion = 0;  
        _accuracy = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public override bool AttackSuccess(int accuracy, int evasion)
    {
        return base.AttackSuccess(accuracy, evasion);
    }

    public override int OnDamage(bool attackSuccess, int damage, int defence)
    {
        return base.OnDamage(attackSuccess, damage, defence);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Monster")
        {
            if (Input.GetKeyDown(KeyCode.Z) && canAttack)
            {
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(other.gameObject.transform.position, 0);
                int i = 0;
                while (i < hitColliders.Length)
                {
                    Character monster = hitColliders[i].gameObject.GetComponent<Character>();
                    int damage = OnDamage(AttackSuccess(_accuracy, monster._evasion), _damage, monster._defence);
                    monster._hp -= damage;
                    i++;
                }
                canAttack = false;
            }
            if (Input.GetKeyUp(KeyCode.Z))
            {
                canAttack = true;
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Character
{

    // Start is called before the first frame update
    void Start()
    {
        _hp = 30;
        _damage = 5;
        _defence = 1;
        _accuracy = 100;
        _evasion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    public override bool AttackSuccess(int accuracy, int evasion)
    {
        return base.AttackSuccess(accuracy, evasion);
    }

    public override int OnDamage(bool attackSuccess, int damage, int defence)
    {
        return base.OnDamage(attackSuccess, damage, defence);
    }

    public override void Die()
    {
        base.Die();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyData", menuName = "ScriptableObjects/Enemy")]
public class Enemy : ScriptableObject
{
    public string enemyName = "Name";
    public Sprite sprite;
    public int health;
    public int damage;
    public float speed;
    public Animator anim;

}

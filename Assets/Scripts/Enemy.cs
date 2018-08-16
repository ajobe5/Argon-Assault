using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform fxParent;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int hitPoints = 10;

    ScoreBoard scoreBoard;

	// Use this for initialization
	void Start ()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        // TODO Consider hit FX
        if (hitPoints <= 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        hitPoints--;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = fxParent;
        Destroy(gameObject);
    }
}

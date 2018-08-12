using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour {

    [SerializeField] float timeUntilDestroyed = 5f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, timeUntilDestroyed);
	}
}

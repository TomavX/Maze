using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {
    public float speed = 3f;
    public float obstacleRange = 5f;
    private bool _alive;

    public bool Alive
    {
        set
        {
            _alive = value;
        }
    }

    private void Start()
    {
        _alive = true;
    }

	// Update is called once per frame
	void Update () {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Vector3 originPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + .6f);
            Ray ray = new Ray(originPoint, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, .5f, out hit))
                if (hit.distance < obstacleRange)
                    transform.Rotate(0, Random.Range(-110, 110), 0);
        }
	}
}

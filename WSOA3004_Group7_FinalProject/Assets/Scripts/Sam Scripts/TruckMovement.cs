using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    private Vector3 endPosition, startPosition;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = new Vector3(-18, -1.31f, 1);
        endPosition = new Vector3(18, -1.31f, 1);
        this.transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, endPosition, speed * Time.deltaTime);
    }
}

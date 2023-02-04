using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaAnimation : MonoBehaviour
{
    public Transform streamLeft;
    public Transform streamRight;
    public float speed = 0.005f;

    public bool isMovingLeft = true;

    void Start()
    {
        StartCoroutine(TurnDirection());
    }

    void Update()
    {
        if (isMovingLeft)
        {
            transform.position = Vector3.Lerp(transform.position, streamLeft.position, speed * Time.deltaTime);
        }
        else 
        {
            transform.position = Vector3.Lerp(transform.position, streamRight.position, speed * Time.deltaTime);
        }
    }

    public IEnumerator TurnDirection()
    {
        isMovingLeft = !isMovingLeft;
        yield return new WaitForSeconds(5f);
        StartCoroutine(TurnDirection());
    } 
}

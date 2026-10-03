using JetBrains.Annotations;
using Unity.Collections;
using UnityEngine;

public class BaseFish : MonoBehaviour
{
    public Transform tankBackground;
    public SpriteRenderer fishy;

    public float speed = 1f;
    public float turnDistance = 0.05f;

    private int direction = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        float fishHalfSize = transform.localScale.x/2 + turnDistance;
        float leftEdge = -tankBackground.localScale.x/2 + fishHalfSize;
        float rightEdge = tankBackground.localScale.x/2 - fishHalfSize;

        if (transform.position.x > rightEdge || transform.position.x < leftEdge)
        {
            direction = direction * -1;
            fishy.flipX = !fishy.flipX;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] public static Points points;

    [Header("Punto")]
    [SerializeField] float speedRotation;
    [SerializeField] public int pointMore;

    // Start is called before the first frame update
    void Start()
    {
        pointMore = 1;
    }

    // Update is called once per frame
    void Update()
    {
        RotationPoints();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector3(Random.Range(10, 80), Random.Range(0, -2.3f), 0);
        }
    }

    public void RotationPoints()
    {
        transform.Rotate(0, speedRotation * Time.deltaTime, 0);
    }
}

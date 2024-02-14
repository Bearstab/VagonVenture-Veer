using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagonController : MonoBehaviour
{
    public float hiz = 10.0f; // Vagonun hızı
    public Transform raylar; // Rayların transform bileşeni
    public Vector3 yon;

    private void Update()
    {
        // Vagonun ileri gitmesini sağlayan kod
        transform.Translate(yon * hiz * Time.deltaTime);

        // Vagonun raylara bağlı kalmasını sağlayan kod
        transform.position = new Vector3(transform.position.x, raylar.position.y, transform.position.z);

        // Vagonun raylarla aynı yöne bakmasını sağlayan kod
        transform.LookAt(transform.position + yon);
    }
}

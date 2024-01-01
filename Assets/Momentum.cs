using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Momentum : MonoBehaviour
{
    public float moveSpeed = 5f; // Vagonun hızı

    private Vector3 initialPosition; // Başlangıç pozisyonu (sınıfın üyesi olarak tanımlandı)
    private float previousXPosition; // Önceki x pozisyonu (sınıfın üyesi olarak tanımlandı)

    // Start is called before the first frame update
    void Start()
    {
        // Başlangıç pozisyonunu kaydet
        initialPosition = transform.position;

        // Önceki x pozisyonunu kaydet
        previousXPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        // Vagonun -x yönüne doğru hareket etmesi
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Input tuşlarına yanıt verme (örneğin, klavye ok tuşları veya mobil ekran dokunuşları)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Vagonu yatırma işlemi
        if (horizontalInput != 0f)
        {
            // Vagonu sola yatır
            transform.rotation = Quaternion.Euler(-horizontalInput * 30f, 0f, 0f);
        }
        else if (verticalInput != 0f)
        {
            // Vagonu sağa yatır
            transform.rotation = Quaternion.Euler(verticalInput * 30f, 0f, 0f);
        }
        else
        {
            // Eğer tuşa basılmıyorsa vagonu düzelt
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }

    }
}

using UnityEngine;
using System.Collections;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Transform followPoint;

    private GameObject carriedChicken = null;
    private bool hasChicken = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (hasChicken && carriedChicken != null)
        {
            carriedChicken.transform.position = Vector3.Lerp(
                carriedChicken.transform.position,
                followPoint.position,
                Time.deltaTime * 10f
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chicken") && !hasChicken)
        {
            hasChicken = true;
            carriedChicken = collision.gameObject;
        }

        if (collision.CompareTag("Customer") && hasChicken && carriedChicken != null)
        {
            // 손님 위치로 자연스럽게 이동 후 삭제
            StartCoroutine(DeliverChicken(collision.transform.position));
        }
    }

    System.Collections.IEnumerator DeliverChicken(Vector3 customerPosition)
    {
        float t = 0f;
        Vector3 startPos = carriedChicken.transform.position;

        while (t < 1f)
        {
            t += Time.deltaTime * 2f;
            carriedChicken.transform.position = Vector3.Lerp(startPos, customerPosition, t);
            yield return null;
        }

        Destroy(carriedChicken, destroyDelay);
        hasChicken = false;
        carriedChicken = null;

        // GameManager에 알리기
        GameManager.instance.ChickenDelivered();
    }
}

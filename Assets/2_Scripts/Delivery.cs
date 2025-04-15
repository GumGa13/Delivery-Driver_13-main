using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 1f;
    [SerializeField] Color noChickenColor = new Color(1, 1, 1, 1);
    [SerializeField] Color hasChickenColor = new Color(0.9f, 0.5f, 0.0f, 1);

    bool hasChicken = false;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Chicken") && !hasChicken)
        {
            Debug.Log("ġŲ ��!");
            hasChicken = true;
            spriteRenderer.color = hasChickenColor;
            Destroy(collision.gameObject, destroyDelay);
        }
        if (collision.gameObject.CompareTag("Customer") && hasChicken)
        {
            Debug.Log("�� �� ġŲ ��!");
            hasChicken = false;
            spriteRenderer.color = noChickenColor;
        }
    }
}

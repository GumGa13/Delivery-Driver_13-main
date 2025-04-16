using UnityEngine;

public class Chicken : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.RegisterChicken();
    }
}

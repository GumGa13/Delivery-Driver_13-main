using UnityEngine;

public class ChickenFollower : MonoBehaviour
{
    private Transform target;
    [SerializeField] float followSpeed = 5f;

    private bool isFollowing = false;

    public void FollowTarget(Transform newTarget)
    {
        target = newTarget;
        isFollowing = true;
    }

    private void Update()
    {
        if (isFollowing && target != null)
        {
            // 1. 위치만 따라가게 하기 (회전 영향 X)
            Vector3 targetPosition = target.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // 2. 따라가는 동안 회전하지 않도록 유지
            transform.rotation = Quaternion.identity; // 회전 리셋 (필수!)
        }
    }
}

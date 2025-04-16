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
            // 1. ��ġ�� ���󰡰� �ϱ� (ȸ�� ���� X)
            Vector3 targetPosition = target.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // 2. ���󰡴� ���� ȸ������ �ʵ��� ����
            transform.rotation = Quaternion.identity; // ȸ�� ���� (�ʼ�!)
        }
    }
}

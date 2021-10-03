using UnityEngine;

/// <summary>
/// Move towards target if object "looks" on it
/// </summary>
public class MoveTowardsTarget : TargetDependent
{
    [SerializeField]
    private Rigidbody body = default;

    [SerializeField]
    private float acceleration = 20f;

    [SerializeField]
    private float maxSpeed = 10f;

    [SerializeField]
    [Range(0, 180)]
    private float towardsAngle = 180f;

    private bool isActive = true;

	private void OnEnable()
	{
        isActive = true;
	}

	private void FixedUpdate()
    {
        if (isActive == false)
		{
            return;
		}

        if (target == false)
        {
            return;
        }

        MoveTowards();
    }

    private void MoveTowards()
    {
        Vector3 direction = target.position - transform.position;

        if (Vector3.Angle(transform.forward, direction) < towardsAngle)
        {
            Move(direction.normalized);
        }
    }

    private void Move(Vector3 normalizedDirection)
    {
        body.velocity = normalizedDirection * GetSpeed();
    }

    private float GetSpeed()
    {
        float speed = body.velocity.magnitude;

        if (speed < maxSpeed)
        {
            speed += acceleration * Time.fixedDeltaTime;

            speed = Mathf.Min(speed, maxSpeed);
        }

        return speed;
    }

    public void Stop()
	{
        body.velocity = Vector3.zero;

        isActive = false;
    }
}
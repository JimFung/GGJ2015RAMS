using UnityEngine;

/// <summary>
/// Allow a 2D Character to walk in either direction using physics
/// </summary>
public class WalkComponent : MonoBehaviour
{
    [SerializeField]    string      _inputAxis;

    [SerializeField]    Animator    _animator;
    [SerializeField]    string      _animationBool;
	[SerializeField]    float       _speed = 500.0f;
    [SerializeField]    float       _maxSpeed = 2000.0f;
    [SerializeField]    Rigidbody2D   _rigidBody;
    [SerializeField]    float       _stopMultiplier = 0.98f;

    private float       _ignoreUntil;


    /// <summary>
    /// We should be in *FixedUpdate* not in Update because we're modifying Rigidbody
    /// </summary>
    void FixedUpdate()
    {
        float axis = Input.GetAxis(_inputAxis);

        // Are we trying to move in the opposite direction (or stopping?)
        if ( axis == 0.0f || (Mathf.Sign(_rigidBody.velocity.x) != Mathf.Sign(axis)) )
        {
            Vector3 velocity = _rigidBody.velocity;
            velocity.x *= _stopMultiplier;

            _rigidBody.velocity = velocity;
        }

        if ( axis != 0.0f )
        {
            float xMovement = axis * _speed * Time.deltaTime;
            Vector2 moveVector = new Vector2( xMovement, 0.0f );

            // Turn to face the right direction...
            if ( axis > 0.0f )
                _rigidBody.transform.localRotation = Quaternion.AngleAxis( 180.0f, Vector3.up );
            else
                _rigidBody.transform.localRotation = Quaternion.AngleAxis( 0.0f, Vector3.up );

            _rigidBody.AddForce( moveVector );
            _rigidBody.velocity = Vector2.ClampMagnitude( _rigidBody.velocity, _maxSpeed );
        }

		_animator.SetBool("isRunning",axis!=0.0f);
     
    }


}

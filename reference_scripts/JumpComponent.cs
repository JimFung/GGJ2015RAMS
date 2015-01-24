using UnityEngine;

/// <summary>
/// Allow a 2D Character to walk in either direction using physics
/// </summary>
public class JumpComponent : MonoBehaviour
{
    [SerializeField]    string      _inputAxis;

    [SerializeField]    Animator    _animator;
    [SerializeField]    string      _animationTrigger;
    [SerializeField]    float       _force = 10.0f;
    [SerializeField]    Rigidbody2D   _rigidBody;

    private float       _ignoreJumpUntil;

    private bool isGrounded
    {
        get
        {
            foreach ( var hit in Physics2D.RaycastAll( _rigidBody.position, -Vector2.up, 0.1f ) )
            {
                if ( hit.rigidbody != _rigidBody )
                    return true;
            }

            return false;
        }
    }

    /*
     * This is a debugging trick
     */
    /*
    void OnGUI()
    {
        GUI.Label( new Rect( 0.0f, 0.0f, 200.0f, 200.0f), "IsGrounded: " + isGrounded );
    }
     */

    void Update()
    {
        if ( Time.time < _ignoreJumpUntil || !isGrounded )
            return;

        float axis = Input.GetAxis(_inputAxis);
        if ( axis > 0.0f )
        {
            float yMovement = axis * _force;
            Vector2 moveVector = new Vector2( 0.0f, yMovement );

            _rigidBody.AddForce( moveVector, ForceMode2D.Impulse );
            _ignoreJumpUntil = Time.time + 0.01f;

            if ( _animator && !string.IsNullOrEmpty(_animationTrigger) )
                _animator.SetTrigger(_animationTrigger);
        }
    }
}

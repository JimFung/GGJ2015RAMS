using UnityEngine;

/// <summary>
/// Allow a 2D Character to walk in either direction using physics
/// </summary>
public class AttackComponent : MonoBehaviour
{
    [SerializeField]    string      _inputButton;

    [SerializeField]    Animator    _animator;
    [SerializeField]    string      _animationTrigger;

    [SerializeField]    float       _attackSpeed = 100.0f;
    [SerializeField]    Rigidbody2D   _rigidBody;

    private float       _ignoreUntil;

    /// <summary>
    /// We should be in *FixedUpdate* not in Update because we're modifying Rigidbody
    /// </summary>
    void FixedUpdate()
    {
        if ( Time.time <= _ignoreUntil )
            return;

        if ( !Input.GetButton( _inputButton) )
            return;

        Vector2 attackVector = -_rigidBody.transform.right * _attackSpeed;
        _rigidBody.AddForce( attackVector, ForceMode2D.Impulse );
        _rigidBody.velocity = Vector2.ClampMagnitude( _rigidBody.velocity, _attackSpeed );

        _ignoreUntil = Time.time + 1.0f;
        SendMessage( "StopWalking", Time.time + 0.25f, SendMessageOptions.DontRequireReceiver );

        if ( _animator && !string.IsNullOrEmpty(_animationTrigger) )
            _animator.SetTrigger(_animationTrigger);
    }

    void OnCollisionEnter2D( Collision2D info )
    {
        bool bWeAreAttacking = Time.time < _ignoreUntil;
        if ( !bWeAreAttacking )
            return;

        // Did we collide with a non-static collider?
        if ( info.rigidbody )
        {
            bool bWeAreMovingFaster = _rigidBody.velocity.sqrMagnitude > info.rigidbody.velocity.sqrMagnitude;
            if ( bWeAreMovingFaster )
                info.rigidbody.SendMessage( "TakeDamage", SendMessageOptions.DontRequireReceiver );
        }
    }
}

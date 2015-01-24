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

    void FixedUpdate()
    {


		// method one for platform jumping
		if (_rigidBody.velocity.y > 0) {
			
			this.gameObject.layer = 10; // goat passiable layer
		} else {
			this.gameObject.layer = 9; // goat passiable layer
		}



        if ( Time.time < _ignoreJumpUntil || !isGrounded )
            return;



        float axis = Input.GetAxis(_inputAxis);
        if ( axis > 0.0f )
        {

			float direction = Mathf.Ceil(axis);
			Debug.Log (direction);

			float yMovement = direction * _force;
            Vector2 moveVector = new Vector2( 0.0f, yMovement );

            _rigidBody.AddForce( moveVector, ForceMode2D.Impulse );
            _ignoreJumpUntil = Time.time + 0.25f;

            if ( _animator && !string.IsNullOrEmpty(_animationTrigger) )
                _animator.SetTrigger(_animationTrigger);
        }




	


		// method 2
		/**
		 * 
		 * 
		 * l a better way to check for isGrounded is to have code in your
		 * OnCollisionEnter that checks the ContactPoint.normal. See if its 
		 * Y is positive, if so, that means your player collided with something 
		 * below it. http://docs.unity3d.com/Documentation/ScriptReference/ContactPoint-normal.html
		 * 
		 **/

	}
}

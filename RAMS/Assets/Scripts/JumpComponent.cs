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
	[SerializeField]    BoxCollider2D   _boxCollider;

    private float       _ignoreJumpUntil;

	private bool isGrounded = false;



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

			isGrounded = false;
            _ignoreJumpUntil = Time.time + 0.25f;

            if ( _animator && !string.IsNullOrEmpty(_animationTrigger) )
                _animator.SetTrigger(_animationTrigger);
        }




	



	}

	void OnCollisionEnter2D (Collision2D hit) {
		Debug.Log("at collision");
		var hitLayer = hit.gameObject.layer;
		// 8 terrain, 9 goat, 10 goatpassableterrain layer
		if (hitLayer ==8 || hitLayer ==9 || hitLayer ==10  ){


		

			foreach(ContactPoint2D contact in hit.contacts)
			{
				if (contact.normal.y >= 1) {
					isGrounded = true;
					break;
				}
				
			}

		}

	}

}

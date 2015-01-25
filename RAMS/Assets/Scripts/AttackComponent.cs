using UnityEngine;

/// <summary>
/// Allow a 2D Character to walk in either direction using physics
/// </summary>
public class AttackComponent : MonoBehaviour
{
	[SerializeField]    string      _inputAxis;

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


		var _inputButton = Input.GetAxis(_inputAxis);
        if ( Time.time <= _ignoreUntil )
            return;


		if ( _inputButton > 0.0f )
		{ 
			
			Debug.Log("Play Attacking");
			_ignoreUntil = Time.time + 1.0f;

			//Attack(); // attack is handled in the animation as a animation event


			_animator.SetTrigger("isAttacking");
		}



      
 
    }

	void Attack(){


		Debug.Log(this._rigidBody.transform.localRotation  *Vector2.right*-1.0f);
		float dirX = (this._rigidBody.transform.localRotation  *Vector2.right*-1.0f).x;
		Vector2 attackVector2 = new Vector2 (dirX, 0f);

		Vector3 rawCenter = this.gameObject.renderer.bounds.center;
		Vector2 centerPosition = new Vector2 (rawCenter.x,rawCenter.y);



		foreach ( var hit in Physics2D.RaycastAll( centerPosition, attackVector2, 1.2f ) )
		{
			var hitLayer = hit.collider.gameObject.layer;
			if ( hit.rigidbody != _rigidBody && (hitLayer== 9||hitLayer== 10) ){
				hit.rigidbody.SendMessage( "TakeDamage");
				Debug.Log("At Attacking");

			}


		}
		
	

	}

   

	void TakeDamage(){

		Debug.Log ("Taken Damage");
		this.gameObject.SetActive (false);
	}
}

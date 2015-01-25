using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSoundManager : MonoBehaviour {


	[SerializeField] AudioClip sfxAttack1;
	[SerializeField] AudioClip sfxAttack2;
	[SerializeField] AudioClip sfxAttack3;

	[SerializeField] AudioClip sfxHit1;
	[SerializeField] AudioClip sfxHit2;
	[SerializeField] AudioClip sfxHit3;

	[SerializeField] AudioClip sfxJump1;
	[SerializeField] AudioClip sfxJump2;
	[SerializeField] AudioClip sfxJump3;

	[SerializeField] AudioClip sfxLand1;
	[SerializeField] AudioClip sfxLand2;
	[SerializeField] AudioClip sfxLand3;

	[SerializeField] AudioClip sfxWalk1;
	[SerializeField] AudioClip sfxWalk2;
	[SerializeField] AudioClip sfxWalk3;
	[SerializeField] AudioClip sfxWalk4;
	[SerializeField] AudioClip sfxWalk5;

	[SerializeField] AudioClip sfxGrunt1;
	[SerializeField] AudioClip sfxGrunt2;
	[SerializeField] AudioClip sfxGrunt3;
	[SerializeField] AudioClip sfxGrunt4;
	[SerializeField] AudioClip sfxGrunt5;

	[SerializeField] AudioClip sfxIdle1;
	[SerializeField] AudioClip sfxIdle2;
	[SerializeField] AudioClip sfxIdle3;
	[SerializeField] AudioClip sfxIdle4;
	[SerializeField] AudioClip sfxIdle5;


	
	static System.Random rnd = new System.Random();
	private List<AudioClip> attackClips =  new List<AudioClip>();
	private List<AudioClip> hitClips =  new List<AudioClip>();

	private List<AudioClip> jumpClips =  new List<AudioClip>();
	private List<AudioClip> landClips =  new List<AudioClip>();

	private List<AudioClip> walkClips =  new List<AudioClip>();


	private List<AudioClip> gruntClips =  new List<AudioClip>();
	private List<AudioClip> idleClips =  new List<AudioClip>();


	
	// Use this for initialization
	void Start () {
		attackClips.Add (sfxAttack1);
		attackClips.Add (sfxAttack2);
		attackClips.Add (sfxAttack3);

		hitClips.Add (sfxHit1);
		hitClips.Add (sfxHit2);
		hitClips.Add (sfxHit3);

		jumpClips.Add (sfxJump1);
		jumpClips.Add (sfxJump2);
		jumpClips.Add (sfxJump3);

		landClips.Add (sfxLand1);
		landClips.Add (sfxLand2);
		landClips.Add (sfxLand3);

		walkClips.Add (sfxWalk1);
		walkClips.Add (sfxWalk2);
		walkClips.Add (sfxWalk3);
		walkClips.Add (sfxWalk4);
		walkClips.Add (sfxWalk5);

		gruntClips.Add (sfxGrunt1);
		gruntClips.Add (sfxGrunt2);
		gruntClips.Add (sfxGrunt3);
		gruntClips.Add (sfxGrunt4);
		gruntClips.Add (sfxGrunt5);

		idleClips.Add (sfxIdle1);
		idleClips.Add (sfxIdle2);
		idleClips.Add (sfxIdle3);
		idleClips.Add (sfxIdle4);
		idleClips.Add (sfxIdle5);
		
	}
	


	void PlayAttackSound(){
		int r = rnd.Next(attackClips.Count);
		audio.PlayOneShot (attackClips [r]);
	}

	public void PlayHitSound(){
		int r = rnd.Next(hitClips.Count);
		audio.PlayOneShot (hitClips [r]);
	}

	public void PlayJumpSound(){
		int r = rnd.Next(jumpClips.Count);
		audio.PlayOneShot (jumpClips [r]);
	}

	public void PlayLandSound(){
		int r = rnd.Next(landClips.Count);
		audio.PlayOneShot (landClips [r]);
	}

	public void PlayWalkSound(){
		int r = rnd.Next(walkClips.Count);
		audio.PlayOneShot (walkClips [r]);
	}
	public void PlayGruntSound(){
		int r = rnd.Next(gruntClips.Count);
		audio.PlayOneShot (gruntClips [r]);
	}

	public void PlayRandomIdleSound(){
		int chance = rnd.Next(20);
		// chance == 0 for 5% chance of running
		if ( chance != 0){
			return;
		}
		int r = rnd.Next(idleClips.Count);
		audio.PlayOneShot (idleClips [r]);
	}
}

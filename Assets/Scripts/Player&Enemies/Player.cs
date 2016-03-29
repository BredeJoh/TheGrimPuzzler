using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	[System.Serializable]
	public class PlayerStats{
		public int PlayerHealth = 3;
	}

    Text healthText;
    bool invunrable = false;
    Rigidbody2D body2D;

	public PlayerStats playerStats = new PlayerStats ();

	// Use this for initialization
	void Start () {
        body2D = gameObject.GetComponent<Rigidbody2D>();
        healthText = GameObject.Find("Health").GetComponent<Text>();
        healthText.text = "Health: " + playerStats.PlayerHealth;

	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = "Health: " + playerStats.PlayerHealth;
    }

	public void DamagePlayer(int damage){
        if (invunrable == false)
        {
            playerStats.PlayerHealth -= damage;
            invunrable = true;
            StartCoroutine(invunrableState());
        }
		if (playerStats.PlayerHealth <= 0) {
			GameMaster.KillPlayer(this);
		}
	}
    IEnumerator invunrableState()
    {
        yield return new WaitForSeconds(1);
        invunrable = false;
    }
	void OnCollisionEnter2D (Collision2D other){
		
		if(other.gameObject.tag == "spikes")
        {			
			DamagePlayer (3);		
		}
        if (other.gameObject.tag == "enemySkele")
        {
            DamagePlayer(1);
        }
        if (other.gameObject.tag == "enemyBrute")
        {
            DamagePlayer(1);
        }
		if (other.gameObject.tag == "enemyBanshee")
		{
			DamagePlayer(1);
		}
        if (other.gameObject.tag == "projectile")
        {
            DamagePlayer(1);
        }
    }

	IEnumerator OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.name == "Goal"){
			float fadeTime = GameObject.Find("Goal").GetComponent<Fading> ().BeginFade(1);
			yield return new WaitForSeconds (fadeTime);
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}

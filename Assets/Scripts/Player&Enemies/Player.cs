using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	[System.Serializable]
	public class PlayerStats{
		public int PlayerHealth = 3;
	}

    //Text healthText;
    bool invunrable = false;
    Rigidbody2D body2D;

	public Sprite[] healthBar;

	public Sprite[] healthUI;

	Image health;

	public GameObject playerDeathParticle;
	GameObject player;



	public PlayerStats playerStats = new PlayerStats ();

	// Use this for initialization
	void Start () {
		player = this.gameObject;

        body2D = gameObject.GetComponent<Rigidbody2D>();
        //healthText = GameObject.Find("Health").GetComponent<Text>();
        //healthText.text = "Health: " + playerStats.PlayerHealth;
		//health = GameObject.Find ("Health_image");
		//health.GetComponent<SpriteRenderer>().sprite = healthBar[0];
		health = GameObject.Find ("SoulBar").GetComponent<Image> ();
	}
		
	// Update is called once per frame
	void Update () {

		if (playerStats.PlayerHealth == 3){
			health.sprite = healthUI [0];
			//health.GetComponent<SpriteRenderer>().sprite = healthBar[0];
		} else if (playerStats.PlayerHealth == 2){
			health.sprite = healthUI [1];
			//health.GetComponent<SpriteRenderer>().sprite = healthBar[1];
		} else if (playerStats.PlayerHealth ==1){
			health.sprite = healthUI [2];
			//health.GetComponent<SpriteRenderer>().sprite = healthBar[2];
		} else if (playerStats.PlayerHealth == 0){
			health.sprite = healthUI [3];
			//health.GetComponent<SpriteRenderer>().sprite = healthBar[3];
		} else if (playerStats.PlayerHealth < 0){
			health.sprite = healthUI [3];
			//health.GetComponent<SpriteRenderer>().sprite = healthBar[3];
		}

        //healthText.text = "Health: " + playerStats.PlayerHealth;
    }

	public void DamagePlayer(int damage){
        if (invunrable == false)
        {
            playerStats.PlayerHealth -= damage;
            invunrable = true;
            StartCoroutine(invunrableState());
        }
		if (playerStats.PlayerHealth <= 0) {

			Instantiate (playerDeathParticle, player.transform.position, player.transform.rotation);
			health.sprite = healthUI [3];
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
            Instantiate(playerDeathParticle, player.transform.position, player.transform.rotation);
            GameMaster.KillPlayer(this);
        }
        else if (other.gameObject.tag == "enemySkele")
        {
			DamagePlayer (1);
        }
        else if (other.gameObject.tag == "enemyBrute")
        {
			DamagePlayer (1);
        }
		else if (other.gameObject.tag == "enemyBanshee")
		{
			DamagePlayer (1);
		}
        else if (other.gameObject.tag == "projectile")
        {
			DamagePlayer (1);
        }
    }

	/*void PlayerIsDamaged (int damageIn){

		health.GetComponent<SpriteRenderer>().sprite = healthBar[i+1];
		i++;
		DamagePlayer (damageIn);
	}*/

	IEnumerator OnTriggerEnter2D (Collider2D other){

		if (other.gameObject.tag == "collectable"){
			playerStats.PlayerHealth += 1;
		}

		if (other.gameObject.name == "Goal"){
			float fadeTime = GameObject.Find("Goal").GetComponent<Fading> ().BeginFade(1);
			yield return new WaitForSeconds (fadeTime);
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}

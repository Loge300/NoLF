using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyMovement : MonoBehaviour
{
    //Variables in order.  Speed of enemy, where the enemy is going, the health of the enemy, the game object that will drop when the enemy is killed
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector2 _targetPosition;
    [SerializeField] private int health = 1;
    [SerializeField] public int enemyID;

    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioClip hitSound;
    [SerializeField] EnemySpawner spawner;

    //[SerializeField] private GameObject scrap;
    public Score score;
    public Boards boards;
    public Wires wires;
    public Plastic plastic;
    public NailsMaterial nails;

    Animator animator_B;
    SpriteRenderer sprite_Renderer;

    private void Start()
    {
        GameObject scoreObject = GameObject.Find("ScoreDisplay");
        GameObject boardObject = GameObject.Find("BoardCount");
        GameObject wireObject = GameObject.Find("WireCount");
        GameObject nailsObject = GameObject.Find("NailCount");
        GameObject plasticObject = GameObject.Find("PlasticCount");
        GameObject spawnerObject = GameObject.Find("EnemySpawner");
        score = scoreObject.GetComponent<Score>();
        boards = boardObject.GetComponent<Boards>();
        wires = wireObject.GetComponent<Wires>();
        nails = nailsObject.GetComponent<NailsMaterial>();
        plastic = plasticObject.GetComponent<Plastic>();
        spawner = spawnerObject.GetComponent<EnemySpawner>();
        //Sets the target of the enemy to the center of the scene
        _targetPosition = Vector2.zero;

        animator_B = gameObject.GetComponent<Animator>();
        sprite_Renderer = gameObject.GetComponent<SpriteRenderer>();

        sfxSource = GetComponent<AudioSource>();
    }

    /*I dont know why this code is here but it might be useful later.  Keep it for now then remove it for the final project if not needed.  
     * private void MoveTo(Vector2 position)
    {
        _targetPosition = position;
    }*/

    private void Update() {
        //moves the enemy toward the center every frame at the enemies speed variable
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);

        if (transform.position.y < 0 && transform.position.x > 0 && !this.name.Contains("Formork")) //represents bottom right quad and doesn't affect formork
        {
            animator_B.SetBool("MoveUp", true);
            sprite_Renderer.flipX = true;
        }
        else if (transform.position.y < 0 && !this.name.Contains("Formork")) //represents bottom left quad and doesn't affect formork
        {
            animator_B.SetBool("MoveUp", true);
            sprite_Renderer.flipX = false;
        }
        else if (transform.position.y < 0 && transform.position.x < 0 && this.name.Contains("Formork")) //formork specific code for bottom left quad
        {
            sprite_Renderer.flipX = true;
        }
        else if (transform.position.y > 0 && transform.position.x < 0 && !this.name.Contains("Formork")) //represents top left quad and doesn't affect formork
        {
            animator_B.SetBool("MoveUp", false);
            sprite_Renderer.flipX = true;
        }
        else if (transform.position.y > 0 && transform.position.x < 0 && this.name.Contains("Formork")) //formork specific code for top left quad
        {
            sprite_Renderer.flipX = true;
        }
        else //represents top right quad
        {
            animator_B.SetBool("MoveUp", false);
        }
        // Use this code for testing decreasing helth related code
    }

    //method for taking damage
    public void TakeDamage(int dmg) {
        health -= dmg;
        if (health <= 0)
        {
            //Instantiate(scrap, transform.position, transform.rotation);
            score.increaseScore(10);
            if (!sfxSource.isPlaying)
            {
                sfxSource.Play();
            }

            //check if it'll drop stuff
            if (spawner.waveCount > 0) {
                float dropOdds = 200.0f / spawner.waveCount;
                float willDrop = Random.Range(0.0f, 100.0f);
                if (willDrop < dropOdds) {
                    Debug.Log("This enemy dropped items");
                    if (enemyID == 0)
                    {
                        boards.increaseBoards(1);
                        nails.increaseNails(2);
                    }
                    if (enemyID == 1)
                    {
                        wires.increaseWires(2);
                        plastic.increasePlastic(1);
                    }
                } else {
                    Debug.Log("This enemy won't drop anything");
                }
            }

            //Moves the enemy very far off screen to allow the sound to play first but also still appear that the enemy was killed
            transform.position = Vector3.one * 9999f;
            GameObject.Destroy(gameObject, hitSound.length);
        }
        else 
        {
            sfxSource.Play();
        }
    }
}

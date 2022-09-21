using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    private int scoreValue = 0;
    private int livesValue = 3;
    public TextMeshProUGUI score;

    public TextMeshProUGUI winText;

    public TextMeshProUGUI livesText;

    public Animator anim;
    public SpriteRenderer rend;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        livesText.text = livesValue.ToString() + " Lives";
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }
    public bool movingLeft = false;
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        rb2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));

        if(isGrounded && rb2d.velocity != Vector2.zero)
        {
            anim.SetInteger("state", 1);
        }
        if (isGrounded && rb2d.velocity == Vector2.zero)
        {
            anim.SetInteger("state", 0);
        }

        if (hozMovement < 0f && !movingLeft)
        {
            rend.flipX = !rend.flipX;
            movingLeft = true;
        }
        else if(hozMovement > 0f && movingLeft)
        {
            rend.flipX = !rend.flipX;
            movingLeft = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            scoreValue++;
            score.text = scoreValue.ToString();
            if (scoreValue == 4)
                transform.position = new Vector3(110, 0, 0);

            if (scoreValue == 8)
            {
                winText.gameObject.SetActive(true);
                AudioManager.instance.PlayWinMusic();

                Destroy(gameObject);
            }
        }

        if(collision.tag == "Bounds" || collision.tag == "Enemy")
        {
            livesValue--;
            livesText.text = livesValue.ToString() + " Lives";

            if (livesValue == 0)
            {
                winText.text = "You Lose!";
                winText.gameObject.SetActive(true);
                AudioManager.instance.PlayLoseMusic();

                Destroy(gameObject);
            }
            if (scoreValue <= 4)
                transform.position = Vector3.zero;
            else
                transform.position = new Vector3(110, 0, 0);
        }
    }
    bool isGrounded = true;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Floor")
        {
            if (!isGrounded && rb2d.velocity.y == 0f)
                isGrounded = true;
            if(Input.GetKey(KeyCode.W))
            {
                rb2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
                anim.SetInteger("state", 2);
                isGrounded = false;
                return;
            }

        }


    }

}

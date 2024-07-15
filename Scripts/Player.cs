using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.SocialPlatforms.Impl;
using System.IO.Compression;
using JetBrains.Annotations;
using Unity.Android.Types;
using System.Linq;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed,runspeed,isGround,score,s=0,count=0;
    public Text TimerText,ScoreText;
    bool moveright=true,moveleft;//FOR android touch controls
    Vector2 pos;
    float timee;
    public float jumpSpeed,health;
    public Image helth;
    Animator animator;
    public GameObject over,clos,a1,a2,a3,a4,a5,next,a6,a7,a8,player;
    void Start()
    {
        animator = GetComponent<Animator>();
        timee=100;
        score=0;
        health=100;
        over.SetActive(false);
        clos.SetActive(false);
         Soundhandler.playtheAudio("Bark");
    }

    // Update is called once per frame
    void Update()
    {
        if(health==0)
        {
            animator.SetBool("Run",false);
            animator.SetBool("Idle",false);
            animator.SetBool("Jump",false);
            animator.SetBool("Walk",false);
            animator.SetBool("Dizzy",false);
            animator.SetBool("Dead",true);
            over.SetActive(true);
            clos.SetActive(true);
            
            s+=1;
        }
        if(timee>0)
        {
        timee-=Time.deltaTime;
        TimerText.text="Time : "+Mathf.Round(timee).ToString();
        }
        if(Mathf.Round(timee)==0)
        {
            over.SetActive(true);
            clos.SetActive(true);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(1f * speed * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX=false;
            animator.SetBool("Run",false);
            animator.SetBool("Idle",false);
            animator.SetBool("Jump",false);
            animator.SetBool("Walk",true);
            animator.SetBool("Dizzy",false);
            animator.SetBool("Dead",false);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(1f * speed * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX=false;
            animator.SetBool("Run",false);
            animator.SetBool("Idle",true);
            animator.SetBool("Jump",false);
            animator.SetBool("Walk",false);
            animator.SetBool("Dizzy",false);
            animator.SetBool("Dead",false);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-1f * speed * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX=true;
            animator.SetBool("Run",false);
            animator.SetBool("Idle",false);
            animator.SetBool("Jump",false);
            animator.SetBool("Walk",true);
            animator.SetBool("Dizzy",false);
            animator.SetBool("Dead",false);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-1f * speed * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX=true;
            animator.SetBool("Run",false);
            animator.SetBool("Idle",true);
            animator.SetBool("Jump",false);
            animator.SetBool("Walk",false);
            animator.SetBool("Dizzy",false);
            animator.SetBool("Dead",false);
        }
        if(Input.GetKey(KeyCode.UpArrow) && isGround<2)
        {
            Soundhandler.playtheAudio("Jump");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 3000 * jumpSpeed * Time.deltaTime));
            isGround+=1;
            animator.SetBool("Run",false);
            animator.SetBool("Idle",false);
            animator.SetBool("Jump",true);
            animator.SetBool("Walk",false);
            animator.SetBool("Dizzy",false);
            animator.SetBool("Dead",false);
        }
        if(Input.GetKeyUp(KeyCode.UpArrow) && isGround<2)
        {
           GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 3000 * jumpSpeed * Time.deltaTime));
            isGround+=1;
            animator.SetBool("Run",false);
            animator.SetBool("Idle",true);
            animator.SetBool("Jump",false);
            animator.SetBool("Walk",false);
            animator.SetBool("Dizzy",false);
            animator.SetBool("Dead",false);
        }
        if(Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(1f * runspeed * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX=false;
            animator.SetBool("Run",true);
            animator.SetBool("Idle",false);
            animator.SetBool("Jump",false);
            animator.SetBool("Walk",false);
            animator.SetBool("Dizzy",false);
            animator.SetBool("Dead",false);
        }
        if(Input.GetKeyUp(KeyCode.RightShift) && Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(1f * runspeed * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX=false;
            animator.SetBool("Run",false);
            animator.SetBool("Idle",true);
            animator.SetBool("Jump",false);
            animator.SetBool("Walk",false);
            animator.SetBool("Dizzy",false);
            animator.SetBool("Dead",false);
        }
        if(Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-1f * runspeed * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX=true;
            animator.SetBool("Run",true);
            animator.SetBool("Idle",false);
            animator.SetBool("Jump",false);
            animator.SetBool("Walk",false);
            animator.SetBool("Dizzy",false);
            animator.SetBool("Dead",false);
        }
        if(Input.GetKeyUp(KeyCode.RightShift) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-1f * runspeed * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX=true;
            animator.SetBool("Run",false);
            animator.SetBool("Idle",true);
            animator.SetBool("Jump",false);
            animator.SetBool("Walk",false);
            animator.SetBool("Dizzy",false);
            animator.SetBool("Dead",false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Collider"))
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("FSpike"))
        {
            pos=transform.position;
            pos.x=pos.x+2;
            transform.position=pos;
            animator.SetBool("Run",false);
            animator.SetBool("Idle",false);
            animator.SetBool("Jump",false);
            animator.SetBool("Walk",false);
            animator.SetBool("Dizzy",false);
            animator.SetBool("Dead",true);
             over.SetActive(true);
             clos.SetActive(true);
             s+=1;
            
        }
        if(collision.gameObject.CompareTag("Moving Tile"))
        {
            transform.parent=collision.gameObject.transform;
        }
        if (collision.gameObject.tag == "Road" || collision.gameObject.tag=="Moving Tile")
        {
            isGround = 0;
        }
        if(collision.gameObject.CompareTag("Leaf") || collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Trunk"))
        {
            animator.SetBool("Run",false);
            animator.SetBool("Idle",false);
            animator.SetBool("Jump",false);
            animator.SetBool("Walk",false);
            animator.SetBool("Dizzy",true);
            animator.SetBool("Dead",false);
            if(score>10)
            {
                score-=10;
            }
            ScoreText.text="Score : "+score;
            if(health>10)
            {
            health-=10;
            helth.fillAmount=health/100;
            }
        }
        if(collision.gameObject.CompareTag("pop1"))
        {
            a6.SetActive(true);
            Destroy(collision.gameObject);
            next.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Moving Tile"))
        {
            transform.parent=null;
        }
        if(other.gameObject.CompareTag("Leaf"))
        {
            animator.SetBool("Run",false);
            animator.SetBool("Idle",false);
            animator.SetBool("Jump",false);
            animator.SetBool("Walk",false);
            animator.SetBool("Dizzy",true);
            animator.SetBool("Dead",false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Food"))
        {
            score+=10;
            ScoreText.text="Score : "+score;
            if(health<100)
            {
            health+=10;
            helth.fillAmount=health/100;
            }
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag=="pop")
        {
            player.GetComponent<SpriteRenderer>().flipX=true;
            a1.SetActive(true);
            count+=1;
            next.SetActive(true);
            Destroy(other.gameObject);
        }
    }
    public void Close()
    {
        SceneManager.LoadScene("second Panel");
    }
    public void Next()
    {
        count+=1;
        switch(count)
        {
            case 2:
                Destroy(a1);
                a2.SetActive(true);
                break;
            case 3:
                Destroy(a2);
                a3.SetActive(true);
                break;
            case 4:
                Destroy(a3);
                a4.SetActive(true);
                break;
            case 5:
                Destroy(a4);
                a5.SetActive(true);
                break;
            case 6:
                Destroy(a5);
                next.SetActive(false);
                break;
            case 7:
                Destroy(a6);
                a7.SetActive(true);
                break;
            case 8:
                Destroy(a7);
                a8.SetActive(true);
                break;
            case 9:
                Destroy(a8);
                next.SetActive(false);
                break;

        }
    }
    //TOUCH CONTROLS FOR ANDROID
    //add bottons in the scene and add event trigrer component to that and add event pointerdown and pointerup
    //and after that add player script and functions methods for player movememnts
    public void right()
    {
        moveright=false;
        Debug.Log("0");
    }
    public void rightdown()
    {
        moveright=true;
        Debug.Log("1");
    }
    public void left()
    {
        moveleft=false;
        Debug.Log("0");
    }
    public void leftdown()
    {
        moveleft=true;
        Debug.Log("1");
    }
}

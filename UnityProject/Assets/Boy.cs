using UnityEngine;
using UnityEngine.UI;

public class Boy : MonoBehaviour
{
    public bool isGroud;
    public AudioClip Jump;
    public AudioSource audio;
    public Animator ani;
    public Rigidbody Rgi;
    public CapsuleCollider cc;
    [Header("移動速度"), Range(0f, 100f)]
    public float speed = 1.5f;
    [Header("跳躍高度"), Range(100, 1500)]
    public int jump = 100;

    private void Update()
    {
        Move();
        ani = GetComponent<Animator>();
        cc = GetComponent<CapsuleCollider>();
        audio = GetComponent<AudioSource>();
        Rgi = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "地板")
        {
            isGroud = true;
        }
    }

    private void Move()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    public void Jump_()
    {
        if (isGroud == true)
        {
            ani.SetBool("跳躍開關", true);
            Rgi.AddForce(new Vector2(0, jump));
            audio.PlayOneShot(Jump, 0.7f);
            isGroud = false;
        }
    }
    public void ResetAnimator()
    {
        ani.SetBool("跳躍開關", false);
    }
}

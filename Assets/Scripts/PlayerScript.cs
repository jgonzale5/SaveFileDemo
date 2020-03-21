using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;

    public KeyCode jumpKey = KeyCode.Space;
    public float jumpForce = 5;
    public float fallingVelocity = 5;
    public bool jumpinAllowed;
    private Rigidbody reggiebody;

    public float cooldown = 0.25f;
    float cooldownCount = 0;

    public Transform explosion;
    public Vector3 feetOffset;
    public Transform landing;

    // Start is called before the first frame update
    void Start()
    {
        reggiebody = GetComponent<Rigidbody>();
        jumpinAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = speed * Time.deltaTime;

        this.transform.position = new Vector3(this.transform.position.x + xMov, this.transform.position.y, this.transform.position.z);

        cooldownCount += Time.deltaTime;

        if (Input.GetKeyUp(jumpKey))
        {
            Vector3 tempVector = reggiebody.velocity;
            tempVector.y = -fallingVelocity;
            reggiebody.velocity = tempVector;
        }

        if (Physics.Raycast(this.transform.position, -Vector3.up, 1.4f))
        {
            if (!jumpinAllowed)
            {
                LandingParticles();
            }

            jumpinAllowed = true;
        }
        else
        {
            jumpinAllowed = false;

            cooldownCount = 0;
        }

        if (Input.GetKeyDown(jumpKey) && jumpinAllowed && cooldownCount >= cooldown)
        {
            reggiebody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpinAllowed = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            ManagerScript.Instance.Lose();
        }

        if (collision.gameObject.tag == "Victory")
        {
            ManagerScript.Instance.Win();
        }
    }

    public void Explode()
    {
        Instantiate(explosion, this.transform.position, explosion.rotation);
    }

    public void LandingParticles()
    {

        Instantiate(landing, this.transform.position + feetOffset, explosion.rotation);
    }
}

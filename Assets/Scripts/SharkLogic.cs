using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SharkLogic : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float detectionDistance;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float playerDamage;

    [SerializeField]
    private int biteDelay;

    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip clip;

    private NavMeshAgent agent;
    private bool foundPlayer;
    private int frameCount;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerDamage *= -1;
        frameCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= detectionDistance)
        {
            foundPlayer = true;
        }

        if (foundPlayer)
        {
            agent.SetDestination(target.position);
            Vector3 direction = target.position - transform.position;
            direction.y = 0;
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<pHealth>().UpdateHealth(playerDamage);
            source.PlayOneShot(clip);
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("STAY");
            ++frameCount;
            if (frameCount > biteDelay)
            {
                frameCount = 0;
                other.gameObject.GetComponent<pHealth>().UpdateHealth(playerDamage);
                source.PlayOneShot(clip);
            }
            
        }
    }
}

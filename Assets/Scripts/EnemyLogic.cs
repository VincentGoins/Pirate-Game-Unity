using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float detectionDistance;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float fireDistance;

    [SerializeField]
    private GameObject leftCannons;

    [SerializeField]
    private GameObject rightCannons;

    [SerializeField]
    private GameObject cannonBall;

    [SerializeField]
    private float launchSpeed;

    [SerializeField]
    private float fireDelay;

    [SerializeField]
    private AudioSource leftSource;

    [SerializeField]
    private AudioSource rightSource;

    [SerializeField]
    private AudioClip clip;

    private NavMeshAgent agent;
    private bool foundPlayer;
    private int frameCounter;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        frameCounter = 0;
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
            if (Vector3.Distance(transform.position, target.position) <= fireDistance)
            {
                transform.rotation = transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, rotationSpeed * 2 * Time.deltaTime);

                float leftDistance = Vector3.Distance(leftCannons.transform.position, target.position);
                float rightDistance = Vector3.Distance(rightCannons.transform.position, target.position);

                if (transform.rotation == target.rotation)
                {
                    if (leftDistance < rightDistance && (frameCounter % fireDelay) == 0)
                    {
                        foreach (Transform child in leftCannons.transform)
                        {
                            GameObject projectile = Instantiate(cannonBall, child.position, child.rotation);
                            projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchSpeed, 0));
                            Object.Destroy(projectile, 3.0f);
                        }
                        leftSource.PlayOneShot(clip);
                    }
                    else if (rightDistance < leftDistance && (frameCounter % fireDelay) == 0)
                    {
                        foreach (Transform child in rightCannons.transform)
                        {
                            GameObject projectile = Instantiate(cannonBall, child.position, child.rotation);
                            projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchSpeed, 0));
                            Object.Destroy(projectile, 3.0f);
                        }
                        rightSource.PlayOneShot(clip);
                    }
                }

                ++frameCounter;

                if (frameCounter > 6000)
                {
                    frameCounter = 0;
                }
            } 
            else
            {
                agent.SetDestination(target.position);
                Vector3 targetDirection = new Vector3(target.position.x, 0, target.position.z);
                Vector3 currentDirection = new Vector3(transform.position.x, 0, transform.position.z);
                Vector3 direction = targetDirection - currentDirection;

                Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    
}

using System;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;
using Unity.MLAgents.Sensors;
using UnityEngine;
using UnityEngine.AI;

public class MLPlayer : Agent
{
    public float Force = 15f;
    public Transform orig = null;

    private Rigidbody rb = null;

    //Initialiseer functie die opgeroepen zal worden wanneer de agent wordt geïnitialiseerd
    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();   
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ; //Bevries rotatie en beweging in X- en Z-assen
    }

    //Functie die opgeroepen wordt wanneer de agent een actie ontvangt
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        if (actionBuffers.DiscreteActions[0] == 1)
        {
            Thrust();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            discreteActionsOut[0] = 1; 
        }
    }

    //Functie die opgeroepen bij een nieuwe episode
    public override void OnEpisodeBegin()
    {
        ResetPlayer();  //Reset de speler
    }

    //Functie die wordt opgeroepen wanneer een botsing zich plaatsvindt
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            AddReward(-0.5f);   //negatieve beloning
            Destroy(collision.gameObject);
            EndEpisode();   //Beëindig de episode
        }
        if (collision.gameObject.CompareTag("walltop"))
        {
            AddReward(-1f);    //negatieve beloning
            EndEpisode();   //Beëindig de huidige episode
        }
    }

    //Functie die opgeropen wordt wanneer een trigger-collider wordt geactiveerd
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wallreward"))
        {
            AddReward(1.0f);    //positieve beloning
        }
    }

    private void Thrust()
    {
        rb.AddForce(Vector3.up * Force, ForceMode.Acceleration);   //Voeg kracht toe in de Y-richting
    }

    //Reset de player
    private void ResetPlayer()
    {
        transform.position = orig.position;
    }
}
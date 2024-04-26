using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float MoveSpeed = 3.5f;

    private void Update()
    {
        this.transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime);  //Beweeg obstakel achteren
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wallend") == true)
        {
            Destroy(this.gameObject);
        }
    }
}

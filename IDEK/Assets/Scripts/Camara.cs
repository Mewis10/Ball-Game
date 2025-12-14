using UnityEngine;

public class Camara : MonoBehaviour
{
	public Transform player;
	private Vector3 distancia = new Vector3(0, 10, -20);
	private float speed = 5f;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = Vector3.Lerp(transform.position, player.position + distancia, speed * Time.deltaTime);
	}
}

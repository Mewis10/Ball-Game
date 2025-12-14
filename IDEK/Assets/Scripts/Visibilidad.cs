using UnityEngine;

public class Visibilidad : MonoBehaviour
{
	public Transform player;
	private Vector3 posicionInicial;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		posicionInicial = transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= transform.position.y)
		{
			transform.position = posicionInicial;
		} else
		{
			transform.position = new Vector3(10000, transform.position.y, transform.position.z);
		}
    }
}

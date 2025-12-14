using UnityEngine;
using System.Collections;

public class Plataforma : MonoBehaviour
{

    private Vector3 posicionInicial;
	private bool contacto = false;

	private Rigidbody rb;
	private Renderer render;

	[Header("Texturas")]
	public Material texturaBase;
	public Material textura1;
	public Material textura2;
	public Material textura3;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		render = GetComponent<Renderer>();
		render.material = texturaBase;
		rb = GetComponent<Rigidbody>();
		posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Colision con " +  collision.gameObject);
		if (contacto)
		{
			return;
		}

		StartCoroutine(Desaparecer());
		contacto = true;
	}

	IEnumerator Desaparecer()
	{
		yield return new WaitForSeconds(1f);
		render.material = textura1;
		yield return new WaitForSeconds(2f);
		render.material = textura2;
		yield return new WaitForSeconds(2f);
		render.material = textura3;
		yield return new WaitForSeconds(2f);
		transform.position = new Vector3 (10000, transform.position.y, transform.position.z);
		render.material = texturaBase;
		yield return new WaitForSeconds(3f);
		contacto = false;
		transform.position = posicionInicial;
	}
}

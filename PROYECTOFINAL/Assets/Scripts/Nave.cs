using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    public float Gravity = 30f;
    public float Jump = 10f;
    public float VelocidadHorizontal = 5f;

    private float VerticalSpeed;

    void Update()
    {
        // Aplicar gravedad
        VerticalSpeed += -Gravity * Time.deltaTime;

        // Saltar con espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            VerticalSpeed = Jump;
        }

        // Movimiento vertical
        Vector3 movimientoVertical = Vector3.up * VerticalSpeed * Time.deltaTime;

        // Movimiento horizontal con flechas
        float entradaHorizontal = Input.GetAxisRaw("Horizontal");
        Vector3 movimientoHorizontal = Vector3.right * entradaHorizontal * VelocidadHorizontal * Time.deltaTime;

        // Mover la nave
        transform.position += movimientoVertical + movimientoHorizontal;
    }

    // Detectar colisiones
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor") // Asegúrate que el objeto se llama exactamente "Floor"
        {
            Debug.Log("Perdiste"); // Mostrar mensaje en consola
            gameObject.SetActive(false); // Desactivar la nave
        }
    }
}

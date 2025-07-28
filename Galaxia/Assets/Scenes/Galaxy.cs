using UnityEngine;

public class GalaxyController : MonoBehaviour
{
    public float speed = 1f;  // Velocidade de simulação inicial
    public float speedChangeAmount = 0.1f;  // Quanto a velocidade vai mudar por vez
    public bool rotateToRight = true;  // Se true, gira para a direita (horário), se false, gira para a esquerda (anti-horário)
    private ParticleSystem[] particleSystems;

    void Start()
    {
        // Pega todos os Particle Systems filhos do GameObject pai
        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    void Update()
    {
        // Aumenta ou diminui a velocidade com as teclas ↑ e ↓
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed += speedChangeAmount;
            UpdateParticleSystemsSpeed();
            Debug.Log("Velocidade Aumentada: " + speed);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed = Mathf.Max(0, speed - speedChangeAmount);  // Impede que a velocidade fique negativa
            UpdateParticleSystemsSpeed();
            Debug.Log("Velocidade Diminuída: " + speed);
        }

        // Determina a direção da rotação (horária ou anti-horária) com base no valor de rotateToRight
        float rotationDirection = rotateToRight ? 1f : -1f;

        // Aplica a rotação no eixo Z (geralmente usado para rotação 2D)
        transform.Rotate(0, 0, speed * rotationDirection * Time.deltaTime);
    }

    // Atualiza a velocidade de simulação de todos os sistemas de partículas
    private void UpdateParticleSystemsSpeed()
    {
        foreach (ParticleSystem ps in particleSystems)
        {
            var mainModule = ps.main;
            mainModule.simulationSpeed = speed;
        }
    }
}

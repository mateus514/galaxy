using UnityEngine;

public class Galaxy : MonoBehaviour
{
    public float speed = 1f;  // Velocidade de simulação inicial
    public float speedChangeAmount = 0.1f;  // Quanto a velocidade vai mudar por vez
    private ParticleSystem[] particleSystems;

    void Start()
    {
        // Pega todos os Particle Systems filhos do GameObject pai
        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    void Update()
    {
        // Aumenta a velocidade com a tecla ↑
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed += speedChangeAmount;
            UpdateParticleSystemsSpeed();
            Debug.Log("Velocidade Aumentada: " + speed);
        }

        // Diminui a velocidade com a tecla ↓
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed = Mathf.Max(0, speed - speedChangeAmount);  // Impede que a velocidade fique negativa
            UpdateParticleSystemsSpeed();
            Debug.Log("Velocidade Diminuída: " + speed);
        }
    }

    // Atualiza a velocidade de simulação de todos os sistemas de partículas
    private void UpdateParticleSystemsSpeed()
    {
        foreach (ParticleSystem ps in particleSystems)
        {
            var mainModule = ps.main;  // Acessa o módulo principal de cada ParticleSystem
            mainModule.simulationSpeed = speed;  // Altera a velocidade de simulação
        }
    }
}
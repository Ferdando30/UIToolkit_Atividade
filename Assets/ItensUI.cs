using UnityEngine;
using UnityEngine.UIElements;

public class ItensUI : MonoBehaviour
{
    private VisualElement Estus;
    private VisualElement Humanity;
    private Button NextBtn;
    private ProgressBar healthBar;
    private ProgressBar staminaBar;
    private Button UseEstus;
    private Button Roll;

    private bool IsEstus;


    private float staminaAtual = 100f;
    private float staminaMaxima = 100f;
    private float custoRoll = 30f;
    private float regeneracao = 20f; // pontos por segundo
    private bool regenerando = false;

    private float vidaAtual = 30f;
    private float vidaMaxima = 100f;
    private float curaEstus = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Estus = root.Q<VisualElement>("Estus");
        Humanity = root.Q<VisualElement>("Humanity");
        NextBtn = root.Q<Button>("NtxItem");
        healthBar = root.Q<ProgressBar>("HealthBar");
        staminaBar = root.Q<ProgressBar>("StaminaBar");
        UseEstus = root.Q<Button>("UseEstus");
        Roll = root.Q<Button>("Roll");

        NextBtn.RegisterCallback<ClickEvent>(NxtItem);
        Roll.RegisterCallback<ClickEvent>(Rolar);
        UseEstus.RegisterCallback<ClickEvent>(UsarEstus);

        VisualElement progressFill = healthBar.Q(className: ProgressBar.progressUssClassName);
        progressFill.style.backgroundColor = Color.red;

        VisualElement staminaFill = staminaBar.Q(className: ProgressBar.progressUssClassName);
        staminaFill.style.backgroundColor = Color.green;

        Estus.visible = true;
        UseEstus.visible = true;
        Humanity.visible = false;
        IsEstus = true;

        staminaBar.value = staminaAtual;
        staminaBar.highValue = staminaMaxima;

        healthBar.lowValue = 0;
        healthBar.highValue = vidaMaxima;
        healthBar.value = vidaAtual;
    }

    void NxtItem(ClickEvent clickEvent)
    {
        if(IsEstus == true)
        {
            Estus.visible = false;
            UseEstus.visible = false;
            Humanity.visible = true;
            IsEstus = false;
        }

        else if (IsEstus == false)
        {
            Estus.visible = true;
            UseEstus.visible = true;
            Humanity.visible = false;
            IsEstus = true;
        }
    }

    void Rolar(ClickEvent clickEvent)
    {
        if (staminaAtual >= custoRoll)
        {
            staminaAtual -= custoRoll;
            staminaBar.value = staminaAtual;
            regenerando = true;
        }
    }

    void UsarEstus(ClickEvent clickEvent)
    {
        vidaAtual += curaEstus;

        if (vidaAtual > vidaMaxima)
        {
            vidaAtual = vidaMaxima;
        }

        healthBar.value = vidaAtual;
    }

    void Update()
    {
        if (regenerando && staminaAtual < staminaMaxima)
        {
            staminaAtual += regeneracao * Time.deltaTime;

            if (staminaAtual >= staminaMaxima)
            {
                staminaAtual = staminaMaxima;
                regenerando = false;
            }

            staminaBar.value = staminaAtual;
        }
    }
}

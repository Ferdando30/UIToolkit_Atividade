using UnityEngine;
using UnityEngine.UIElements;


public class telas : MonoBehaviour
{
    private VisualElement TelaInicio;
    private Button StartBtn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        StartBtn = root.Q<Button>("StartBtn");
        TelaInicio = root.Q<VisualElement>("BackgroundColor");

        StartBtn.RegisterCallback<ClickEvent>(StartGame);

        TelaInicio.visible = true;
    }

    void StartGame(ClickEvent clickEvent)
    {
        TelaInicio.visible = false;
    }
}

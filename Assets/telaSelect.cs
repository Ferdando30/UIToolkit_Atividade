using UnityEngine;
using UnityEngine.UIElements;

public class telaSelect : MonoBehaviour
{
    private VisualElement TelaInicio;
    private Button SelectBtn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        SelectBtn = root.Q<Button>("SelectBtn");
        TelaInicio = root.Q<VisualElement>("BackgroundColor");

        SelectBtn.RegisterCallback<ClickEvent>(SelectCharacter);

        TelaInicio.visible = true;
    }

    void SelectCharacter(ClickEvent clickEvent)
    {
        TelaInicio.visible = false;
    }
}

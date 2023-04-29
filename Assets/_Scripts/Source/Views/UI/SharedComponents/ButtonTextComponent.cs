using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public record ButtonTextComponentProps
{
  public Action OnClick { get; init; }
  public Action OnMouseEnter { get; init; }
  public Action OnMouseExit { get; init; }
  public string Text { get; init; }
  public bool IsEnabled { get; init; } = true;
}

public class ButtonTextComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IUIComponent<ButtonTextComponentProps>
{
  [SerializeField] TMP_Text _text;
  [SerializeField] Button _button;


  ButtonTextComponentProps _currentProps;

  void Awake()
  {
    _button.onClick.AddListener(() => _currentProps?.OnClick?.Invoke());
  }

  public void OnPointerEnter(PointerEventData eventData)
  {
    _currentProps?.OnMouseEnter?.Invoke();
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    _currentProps?.OnMouseExit?.Invoke();
  }

  public void SetProps(ButtonTextComponentProps props)
  {
    _text.text = props.Text;
    _button.interactable = props.IsEnabled;
    _currentProps = props;
  }
}

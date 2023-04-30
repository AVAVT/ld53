using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public record TextComponentProps
{
  public string Text { get; init; }

  public TextComponentProps(string text)
  {
    Text = text;
  }
}

public class TextComponent : MonoBehaviour, IUIComponent<TextComponentProps>
{
  [SerializeField] TMP_Text _text;

  TextComponentProps _currentProps;

  public void SetProps(TextComponentProps props)
  {
    _text.text = props.Text;
    _currentProps = props;
  }
}
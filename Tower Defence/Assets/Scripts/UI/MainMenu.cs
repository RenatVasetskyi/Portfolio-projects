using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(UIDocument))]
    public class MainMenu : MonoBehaviour
    {
        private const string MenuContainerName = "menu-container";
        private const string MenuButtonName = "menu-button";
        private const string LabelName = "label";

        [SerializeField] private List<MainMenuItem> _menuItems;

        [Header("Settings")]

        [SerializeField] private VisualTreeAsset _itemTemplate;

        [SerializeField] private float _transitionDuration;
        [SerializeField] private float _itemAppearanceDelay;

        [SerializeField] private float _buttonMoveDistance;

        [SerializeField] private EasingMode _easing;

        private VisualElement _container;

        private void Start() =>
            StartCoroutine(CreateMainMenu());

        private IEnumerator CreateMainMenu()
        {
            _container = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>(MenuContainerName);

            foreach (MainMenuItem item in _menuItems)
            {
                VisualElement newElement = GetVisualElement();
                Button button = GetButton(newElement);

                ConstructItem(newElement);
                ConstructButton(button, item);

                _container.Add(newElement);

                SetMargin(newElement, _buttonMoveDistance);
                yield return null;
                SetMargin(newElement, 0);

                yield return new WaitForSeconds(_itemAppearanceDelay);
            }
        }

        private void ConstructItem(VisualElement item)
        {
            item.style.transitionDuration = new List<TimeValue>() { new TimeValue(_transitionDuration, TimeUnit.Second) };
            item.style.transitionTimingFunction = new StyleList<EasingFunction>(new List<EasingFunction>() { new EasingFunction(_easing) });
        }

        private void ConstructButton(Button button, MainMenuItem item)
        {
            button.Q<Label>(LabelName).text = item.Name;
            button.clicked += () => OnClick(item);
        }

        private TemplateContainer GetVisualElement() =>
            _itemTemplate.CloneTree();

        private Button GetButton(VisualElement newElement) =>
            newElement.Q<Button>(MenuButtonName);

        private void SetMargin(VisualElement element, float moveDistance) =>
            element.style.marginRight = moveDistance;

        private void OnClick(MainMenuItem item) =>
            item.OnClick.Invoke();
    }
}
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Architecture.Factories;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(UIDocument))]
    public class MainMenu : MonoBehaviour
    {
        private const string MenuContainerName = "menu-container";
        private const string MenuButtonName = "menu-button";
        private const string LabelName = "label";

        [SerializeField] private List<ButtonType> _menuItems;

        [Header("Settings")]

        [SerializeField] private VisualTreeAsset _itemTemplate;

        [SerializeField] private float _transitionDuration;
        [SerializeField] private float _itemAppearanceDelay;

        [SerializeField] private float _buttonMoveDistance;

        [SerializeField] private EasingMode _easing;

        private VisualElement _container;

        private IUIFactory _uiFactory;

        [Inject]
        public void Construct(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        private void Start() =>
            StartCoroutine(CreateMainMenu());

        private IEnumerator CreateMainMenu()
        {
            _container = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>(MenuContainerName);

            foreach (ButtonType type in _menuItems)
            {
                yield return new WaitForSeconds(_itemAppearanceDelay);

                VisualElement newElement = GetVisualElement();
                Button button = GetButton(newElement);

                ConstructItem(newElement);
                ConstructButton(button, type);

                _container.Add(newElement);

                SetMargin(newElement, _buttonMoveDistance);
                yield return null;
                SetMargin(newElement, 0);

            }
        }

        private void ConstructItem(VisualElement item)
        {
            item.style.transitionDuration = new List<TimeValue>() { new TimeValue(_transitionDuration, TimeUnit.Second) };
            item.style.transitionTimingFunction = new StyleList<EasingFunction>(new List<EasingFunction>() { new EasingFunction(_easing) });
        }

        private void ConstructButton(Button button, ButtonType type)
        {
            button.Q<Label>(LabelName).text = type.ToString();

            switch (type)
            {
                case ButtonType.Play:
                    button.clicked += () => _uiFactory.CreateLevelSelectionWindow();
                    break;
                case ButtonType.Settings:
                    button.clicked += () => Debug.Log("Settings")/*_uiFactory.CreateSettingsWindow()*/;
                    break;
                case ButtonType.Exit:
                    button.clicked += () => Application.Quit();
                    break;
            }
        }

        private TemplateContainer GetVisualElement() =>
            _itemTemplate.CloneTree();

        private Button GetButton(VisualElement newElement) =>
            newElement.Q<Button>(MenuButtonName);

        private void SetMargin(VisualElement element, float moveDistance) =>
            element.style.marginRight = moveDistance;
    }
}
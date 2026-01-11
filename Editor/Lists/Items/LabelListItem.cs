using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using Aarthificial.Typewriter.Editor.Extensions;

namespace Aarthificial.Typewriter.Editor.Lists.Items
{
    public class LabelListItem : EditableListItem
    {
        protected readonly Label Label;
        protected readonly VisualElement Root;
        protected readonly TextField Text;
        protected readonly Label Type;

        private bool Hovered => Root.worldBound.Contains(Event.current.mousePosition);

        public LabelListItem()
        {
            Root = new VisualElement();
            Root.AddToClassList("editable-item");

            Label = new Label();
            Label.AddToClassList("editable-item__label");
            Text = new TextField { style = { display = DisplayStyle.None } };
            Text.AddToClassList("editable-item__field");

            Type = new Label();
            Type.AddToClassList("editable-item__type");

            Label.RegisterCallback<MouseDownEvent>(HandleMouseDown);
            Text.RegisterCallback<FocusOutEvent>(HandleFocusOut);

            Add(Root);
            Root.Add(Label);
            Root.Add(Text);
            Root.Add(Type);
        }

        protected void SetLabel(string text) => Label.text = string.IsNullOrEmpty(text) ? "<empty>" : text;

        protected virtual void HandleFocusOut(FocusOutEvent evt)
        {
            // Check if we selected something else outside of this item
            if (Hovered) return;

            // Show the label
            Label.style.display = DisplayStyle.Flex;

            // Update the label
            SetLabel(Text.value);

            // Hide the text field
            Text.style.display = DisplayStyle.None;
        }

        private void HandleMouseDown(MouseDownEvent evt)
        {
            // Double click - enter edit mode
            if (evt.clickCount == 2)
            {
                // Hide the label field
                Label.style.display = DisplayStyle.None;

                // Show the text field
                Text.style.display = DisplayStyle.Flex;

                // Focus the text field
                Text.ElementAt(0).Focus();

                // Select the text
                Text.SelectAll();
            }
        }

        public override void BindProperty(SerializedProperty property)
        {
            var child = property.FirstString();
            if (child != null)
            {
                SetLabel(child.stringValue);
                Text.BindProperty(child);
            }
        }

        public override void Unbind()
        {
            SetLabel("");
            Text.Unbind();
        }
    }
}


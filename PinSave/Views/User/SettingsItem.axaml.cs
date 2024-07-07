using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using PinSave.Models.Auxiliary—lasses;

namespace PinSave.Views.User
{
    public partial class SettingsItem : UserControl
    {


        public static readonly StyledProperty<string> TextHeaderProperty = AvaloniaProperty.Register<SettingsItem, string>(nameof(TextHeader));
        public static readonly StyledProperty<string> TextHintProperty = AvaloniaProperty.Register<SettingsItem, string>(nameof(TextHint));
        public static readonly StyledProperty<bool> IsCheckedProperty = AvaloniaProperty.Register<SettingsItem, bool>(nameof(IsChecked));
        public static readonly StyledProperty<string> UserTagProperty = AvaloniaProperty.Register<SettingsItem, string>(nameof(UserTag));


        public string TextHeader
        {
            get => this.GetValue(TextHeaderProperty);
            set => SetValue(TextHeaderProperty, value);
        }

        public string TextHint
        {
            get => this.GetValue(TextHintProperty);
            set => SetValue(TextHintProperty, value);
        }

        public bool IsChecked
        {
            get => this.GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public string UserTag
        {
            get => this.GetValue(UserTagProperty);
            set => SetValue(UserTagProperty, value);
        }

        public SettingsItem()
        {
            InitializeComponent();
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            switch (UserTag)
            {
                case "VariableFolder":
                    {
                        IsChecked = !IsChecked;
                        new GetSetSettingsApp().SetVariableFolder(IsChecked);
                        break;
                    }
                case "VariableTheme":
                    {
                        IsChecked = !IsChecked;
                        new GetSetSettingsApp().SetTheme(IsChecked);
                        break;
                    }
            }
        }
    }
}

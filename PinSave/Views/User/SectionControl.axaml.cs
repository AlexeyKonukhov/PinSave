using Avalonia;
using Avalonia.Controls;

namespace PinSave;

public partial class SectionControl : UserControl
{



    public static readonly StyledProperty<string> CaptionProperty = AvaloniaProperty.Register<SectionControl, string>(nameof(Caption));
    public static readonly StyledProperty<string> CountProperty = AvaloniaProperty.Register<SectionControl, string>(nameof(Count));
    public static readonly StyledProperty<string> PinProperty = AvaloniaProperty.Register<SectionControl, string>(nameof(Pin));


    public string Caption
    {
        get => this.GetValue(CaptionProperty);
        set => SetValue(CaptionProperty, value);
    }
    public string Count
    {
        get => this.GetValue(CountProperty);
        set => SetValue(CountProperty, value);
    }

    public string Pin
    {
        get => this.GetValue(PinProperty);
        set => SetValue(PinProperty, value);
    }

    public SectionControl()
    {
        InitializeComponent();
    }
}
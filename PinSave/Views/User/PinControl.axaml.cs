using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;

namespace PinSave.Views.User;

public sealed partial class PinControl : UserControl
{
    private const double ScaleImage = 1.2;

    public static readonly StyledProperty<string> DominantColorProperty =
        AvaloniaProperty.Register<PinControl, string>(nameof(DominantColor));

    public static readonly StyledProperty<string> TypeProperty =
        AvaloniaProperty.Register<PinControl, string>(nameof(Type));

    public static readonly StyledProperty<string> DescriptionProperty =
        AvaloniaProperty.Register<PinControl, string>(nameof(Description));

    public static readonly StyledProperty<string> UrlProperty =
        AvaloniaProperty.Register<PinControl, string>(nameof(Url));

    public static readonly StyledProperty<bool> SelectProperty =
        AvaloniaProperty.Register<PinControl, bool>(nameof(Select));

    public PinControl()
    {
        InitializeComponent();
    }


    public string DominantColor
    {
        get => GetValue(DominantColorProperty);
        set => SetValue(DominantColorProperty, value);
    }

    public string Type
    {
        get => GetValue(TypeProperty);
        set => SetValue(TypeProperty, value);
    }

    public string Description
    {
        get => GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public string Url
    {
        get => GetValue(UrlProperty);
        set => SetValue(UrlProperty, value);
    }

    public bool Select
    {
        get => GetValue(SelectProperty);
        set => SetValue(SelectProperty, value);
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        Select = !Select;
    }

    protected override void OnPointerEntered(PointerEventArgs e)
    {
        base.OnPointerEntered(e);
        ImgScale(true);
    }

    protected override void OnPointerExited(PointerEventArgs e)
    {
        base.OnPointerExited(e);
        ImgScale(false);
    }

    private void ImgScale(bool scale)
    {
        switch (scale)
        {
            case true:
                {
                    Img.Width *= ScaleImage;
                    Img.Height *= ScaleImage;
                    break;
                }
            case false:
                {
                    Img.Width /= ScaleImage;
                    Img.Height /= ScaleImage;
                    break;
                }
        }
    }
}
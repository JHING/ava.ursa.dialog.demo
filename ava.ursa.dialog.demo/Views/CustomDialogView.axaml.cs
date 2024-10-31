using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;

namespace ava.ursa.dialog.demo.Views;

public partial class CustomDialogView : UserControl
{
    private bool _isDragging = false;
    private Point _lastPosition;

    /// <summary>
    /// 需要更新的坐标点
    /// </summary>
    private PixelPoint _targetPosition;

    public CustomDialogView()
    {
        InitializeComponent();

        var title = this.PART_Title;
        if (title != null)
        {
            title.PointerPressed += TitlePointerPressed;
            title.PointerMoved += TitlePointerMoved;
            title.PointerReleased += TitlePointerReleased;
        }
    }

    private void TitlePointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        if (!_isDragging) return;
        // 停止拖动
        _isDragging = false;
        e.Handled = true;
    }

    private void TitlePointerMoved(object? sender, PointerEventArgs e)
    {
        if (!e.GetCurrentPoint(this).Properties.IsLeftButtonPressed) return;

        // 如果没有启动拖动，则不执行
        if (!_isDragging) return;

        var currentMousePosition = e.GetPosition(this);
        var offset = currentMousePosition - _lastPosition;

        var window = this.FindAncestorOfType<Window>();
        if (window != null)
        {
            // 记录当前坐标
            _targetPosition = new PixelPoint(window.Position.X + (int)offset.X,
                window.Position.Y + (int)offset.Y);

            if (window.Position != _targetPosition)
            {
                // 更新坐标
                window.Position = _targetPosition;
            }
        }
    }

    private void TitlePointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!e.GetCurrentPoint(this).Properties.IsLeftButtonPressed) return;
        // 启动拖动
        _isDragging = true;
        // 记录当前坐标
        _lastPosition = e.GetPosition(this);
        e.Handled = true;
    }
}
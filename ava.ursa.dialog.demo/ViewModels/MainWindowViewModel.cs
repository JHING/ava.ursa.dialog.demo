using System.Threading.Tasks;
using ava.ursa.dialog.demo.Views;
using CommunityToolkit.Mvvm.Input;
using Ursa.Controls;

namespace ava.ursa.dialog.demo.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [RelayCommand]
    private async Task ShowDialog()
    {
        await Dialog.ShowCustomModal<CustomDialogView, CustomDialogViewModel, bool>(
            new CustomDialogViewModel(),
            options: new DialogOptions
            {
                IsCloseButtonVisible = false
            });
    }

    [RelayCommand]
    private async Task ShowOverlayDialog()
    {
        await OverlayDialog.ShowCustomModal<CustomDialogView, CustomDialogViewModel, bool>(
            new CustomDialogViewModel(),
            "LocalHost",
            new OverlayDialogOptions
            {
                CanDragMove = false,
                IsCloseButtonVisible = false
            });
    }
}
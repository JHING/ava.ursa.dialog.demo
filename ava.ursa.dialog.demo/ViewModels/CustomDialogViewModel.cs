using System;
using CommunityToolkit.Mvvm.Input;
using Irihi.Avalonia.Shared.Contracts;

namespace ava.ursa.dialog.demo.ViewModels;

public partial class CustomDialogViewModel : IDialogContext
{
    public void Close()
    {
        RequestClose?.Invoke(this, default);
    }

    public event EventHandler<object?>? RequestClose;

    [RelayCommand]
    private void Cancel()
    {
        Close();
    }
}
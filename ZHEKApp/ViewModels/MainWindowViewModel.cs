using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ZHEKApp.Models;

namespace ZHEKApp.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string newName;

    [ObservableProperty]
    private string newPhone;

    [ObservableProperty]
    private string newEmail;

    [ObservableProperty]
    private string searchQuery;

    [ObservableProperty]
    private ObservableCollection<Resident> residents = new();

    public MainWindowViewModel()
    {
        // Приклад даних
        Residents.Add(new Resident { Name = "Іван", Phone = "123", Email = "ivan@example.com" });
    }

    [RelayCommand]
private void AddResident()
{
    if (!string.IsNullOrWhiteSpace(NewName) &&
        !string.IsNullOrWhiteSpace(NewPhone) &&
        !string.IsNullOrWhiteSpace(NewEmail))
    {
        Residents.Add(new Resident
        {
            Name = NewName,
            Phone = NewPhone,
            Email = NewEmail
        });

        // Очищення полів після додавання
        NewName = string.Empty;
        NewPhone = string.Empty;
        NewEmail = string.Empty;
    }
}


    [RelayCommand]
    private void Search()
    {
        // Твоя логіка пошуку
    }

    [RelayCommand]
    private void ReportAllRequests()
    {
        // Побудова звіту для всіх
    }

    [RelayCommand]
    private void ReportNoRequests()
    {
        // Побудова звіту для мешканців без заявок
    }
}

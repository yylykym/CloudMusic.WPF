using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudMusic.WPF.Services
{
    public interface INavigationService
    {
        ObservableObject? CurrentPage { get; }

        bool CanGoBack { get; }

        void NavigateTo(ObservableObject page);

        void GoBack();
    }
}

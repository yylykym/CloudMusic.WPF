using CommunityToolkit.Mvvm.ComponentModel;

namespace CloudMusic.WPF.Services
{
    public partial class NavigationService : ObservableObject, INavigationService
    {

        [ObservableProperty]
        public partial ObservableObject? CurrentPage { get; private set; }


        public bool CanGoBack => throw new NotImplementedException();

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(ObservableObject page)
        {
            CurrentPage = page;
        }
    }
}

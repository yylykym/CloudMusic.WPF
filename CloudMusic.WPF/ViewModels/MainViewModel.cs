
using CloudMusic.WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CloudMusic.WPF.ViewModels
{
    public class MainViewModel(INavigationService navigation) : ObservableObject
    {
        public INavigationService Navigation { get; } = navigation;

        public SidebarViewModel SidebarVM { get; } = new SidebarViewModel(navigation);
    }
}

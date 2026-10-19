
using CloudMusic.WPF.Models;
using CloudMusic.WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CloudMusic.WPF.ViewModels
{
    public partial class SidebarViewModel : ObservableObject
    {
        public List<SidebarItem> SidebarItems { get; private set; }

        [ObservableProperty]
        public partial SidebarItem? SelectedSidebarItem { get; set; }

        public INavigationService NavigationService { get; }

        partial void OnSelectedSidebarItemChanged(SidebarItem? value)
        {
            if (SelectedSidebarItem is not null)
            {
                switch (SelectedSidebarItem.Type)
                {
                    case SidebarItemType.Featured:
                        NavigationService.NavigateTo(new FeaturedViewModel());
                        break;
                    case SidebarItemType.Podcast:
                        NavigationService.NavigateTo(new PodcastViewModel());
                        break;
                }
            }
        }

        public SidebarViewModel(INavigationService navigation)
        {
            NavigationService = navigation;
            SidebarItems =
            [
                new() { Title = "精选", Icon = "pack://application:,,,/Assets/Icons/Navigation/featured.svg", Type = SidebarItemType.Featured },
                new() { Title = "播客", Icon = "pack://application:,,,/Assets/Icons/Navigation/podcast.svg", Type = SidebarItemType.Podcast },
                new() { Title = "关注", Icon = "pack://application:,,,/Assets/Icons/Navigation/following.svg", Type = SidebarItemType.Following },
                new() { Title = "我喜欢的音乐", Icon = "pack://application:,,,/Assets/Icons/Navigation/favorites.svg", Type = SidebarItemType.Favorites },
                new() { Title = "最近播放", Icon = "pack://application:,,,/Assets/Icons/Navigation/recentlyplayed.svg", Type = SidebarItemType.RecentlyPlayed },
                new() { Title = "下载管理", Icon = "pack://application:,,,/Assets/Icons/Navigation/downloads.svg", Type = SidebarItemType.Downloads },
                new() { Title = "本地音乐", Icon = "pack://application:,,,/Assets/Icons/Navigation/localmusic.svg", Type = SidebarItemType.LocalMusic }
            ];
            SelectedSidebarItem = SidebarItems[0];
        }

    }
}

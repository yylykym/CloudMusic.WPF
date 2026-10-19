
namespace CloudMusic.WPF.Models
{
    public class SidebarItem
    {
        public required string Title { get; set; }

        public required string Icon { get; set; }

        public required SidebarItemType Type { get; set; }
    }
}

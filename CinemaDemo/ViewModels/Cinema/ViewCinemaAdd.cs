using System.ComponentModel;

namespace CinemaDemo.ViewModels
{
    public class ViewCinemaAdd
    {
        [DisplayName("电影院名称")]
        public string Name { get; set; }

        [DisplayName("电影院地址")]
        public string Address { get; set; }

        [DisplayName("星级")]
        public int Grade { get; set; }
    }
}

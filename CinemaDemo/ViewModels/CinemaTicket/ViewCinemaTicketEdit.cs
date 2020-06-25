using System;
using System.ComponentModel;

namespace CinemaDemo.ViewModels
{
    public class ViewCinemaTicketEdit
    {
        public int Id { get; set; }
        public int CinemaId { get; set; }
        public string CinemaName { get; set; }

        [DisplayName("名称")]
        public string Name { get; set; }

        [DisplayName("主演")]
        public string Star { get; set; }

        [DisplayName("上映时间")]
        public DateTime ReleaseTime { get; set; }
    }
}

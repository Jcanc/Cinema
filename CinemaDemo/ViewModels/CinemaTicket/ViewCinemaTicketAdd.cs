using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CinemaDemo.ViewModels
{
    public class ViewCinemaTicketAdd
    {
        public int CinemaId { get; set; }

        [DisplayName("名称")]
        public string Name { get; set; }

        [DisplayName("主演")]
        public string Star { get; set; }

        [DisplayName("上映时间")]
        public DateTime ReleaseTime { get; set; }
    }
}

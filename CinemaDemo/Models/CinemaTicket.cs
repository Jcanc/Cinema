using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CinemaDemo.Models
{
    public class CinemaTicket
    {
        [Key]
        [DisplayName("电影Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("电影院Id")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [DisplayName("电影名称")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [DisplayName("主演")]
        public string Star { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [DisplayName("上映时间")]
        public DateTime ReleaseTime { get; set; }
    }
}

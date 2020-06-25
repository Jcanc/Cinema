using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CinemaDemo.Models
{
    public class Cinema
    {
        [Key]
        [DisplayName("电影院Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [DisplayName("电影院名称")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [DisplayName("电影院地址")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [DisplayName("星级")]
        public int Grade { get; set; }
    }
}

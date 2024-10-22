using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Web_App_Store.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(10)]
        [Required(ErrorMessage ="Длина имени не менее 1 символа")]
        public string name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина фамилии не менее 1 символа")]
        public string surname { get; set; }

        [Display(Name = "Введите адрес")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина адреса не менее 1 символа")]
        public string adress { get; set; }

        [Display(Name = "Введите номер телефона")]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера телефона не менее 11 символов")]
        public string phone { get; set; }

        [Display(Name = "Введите email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длина email не менее 1 символа")]
        public string email { get; set; }


        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }

}

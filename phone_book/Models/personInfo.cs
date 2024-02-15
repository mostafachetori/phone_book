using System.ComponentModel.DataAnnotations;

namespace phone_book.Models
{
    public class personInfo
    {
        public int Id { get; set; }

        [Display(Name="نام")]
        [Required(ErrorMessage ="لطفا نام خود را وارد کنید")]
        [StringLength(60,MinimumLength =3,ErrorMessage ="تعداد حروف درست نیست")]
        public string firstName { get; set; }




        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا نام خانوادگی خود را وارد کنید")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "تعداد حروف درست نیست")]
        public string last_name  { get; set; }


        [Display(Name ="  تاریخ تولد")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "لطفا تاریخ تولد را وارد کنید")]
        public DateTime dateCreated { get; set; }


        [Required(ErrorMessage = "لطفاایمیل را وارد کنید")]
        [Display(Name = " ایمیل ")]
        [EmailAddress]
        public string email { get; set; }





        [Required(ErrorMessage = "لطفا شماره تلفن را وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$", ErrorMessage = "لطفا شماره تلفن را درست وارد کنید")]
        [Display(Name = " شماره تلفن ")]
        public string phoneNumber { get; set; }





        [Display(Name = " نام شهر ")]
        [Required(ErrorMessage = "لطفا نام شهر خود را وارد کنید")]

        public string city { get; set; }


        
        [Display(Name = " آدرس ")]
        public string address { get; set; }




    }


}

using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "필수항목입니다."), StringLength(10, ErrorMessage = "10자 이내로 작성하세요")]  //cshtml 에서 input 에 해당 길이만큼만 입력된다. 
        public String Name { get; set; }
    }
}
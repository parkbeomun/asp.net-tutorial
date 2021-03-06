using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; } //ID 필드는 데이터베이스에서 기본 키 대신 필요
        public String Title { get; set; }

        
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)] //특정 데이터 형식 지정
        public DateTime ReleaseDate { get; set; }
        public String Genre { get; set; }
        
        [Column(TypeName = "decimal(18.2)")]
        public decimal Price { get; set; }

    }
}

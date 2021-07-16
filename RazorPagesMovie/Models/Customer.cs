using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(10)] 
        public String Name { get; set; }
    }
}
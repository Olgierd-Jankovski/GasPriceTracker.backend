﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gas.DB
{
    public class Savings
    {
        [Key]
        public int Id { get; set; }
        public float Amount { get; set; }

        public int TypeId {  get; set; }

        [ForeignKey("TypeId")]
        public Type? Type { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace AnticevicApi.Model.Database.Main.Security
{
    [Table("AccessToken", Schema = "Security")]
    public class AccessToken : UserEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public string Token { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}

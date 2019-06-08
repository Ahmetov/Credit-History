namespace Course.Models.Util
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Пользователи
    {
        [Key]
        public int Номер_Пользователя { get; set; }

        [StringLength(20)]
        public string Логин { get; set; }

        [StringLength(20)]
        public string Пароль { get; set; }
    }
}

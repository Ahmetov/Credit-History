namespace Course
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Кредитный_Договор
    {
        [Key]
        public int ИД_Договора { get; set; }

        [Column(TypeName = "money")]
        public decimal? Сумма_Кредита { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Дата_Заключения { get; set; }

        [StringLength(20)]
        public string Форм_Кредита { get; set; }

        public float? Процентная_Ставка { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Дата_Погашения { get; set; }

        public bool? Произведена_Выплата { get; set; }

        public int? ИД_Банка { get; set; }

        public int? ИД_Заёмщика { get; set; }

        public virtual Банк Банк { get; set; }

        public virtual Заёмщик Заёмщик { get; set; }
    }
}

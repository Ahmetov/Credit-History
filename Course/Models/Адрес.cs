namespace Course
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Адрес
    {
        [Key]
        public int ИД_Адреса { get; set; }

        [StringLength(20)]
        public string Город { get; set; }

        [StringLength(20)]
        public string Улица { get; set; }

        public int? Номер_Улицы { get; set; }

        public int? Квартира { get; set; }

        public int? Индекс { get; set; }

        public virtual Банк Банк { get; set; }

        public virtual Заёмщик Заёмщик { get; set; }
    }
}

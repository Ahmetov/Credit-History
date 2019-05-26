namespace Course
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Заёмщик
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Заёмщик()
        {
            Кредитный_Договор = new HashSet<Кредитный_Договор>();
        }

        [Key]
        public int ИД_Заёмщика { get; set; }

        [StringLength(20)]
        public string Имя { get; set; }

        [StringLength(20)]
        public string Фамилия { get; set; }

        [StringLength(20)]
        public string Отчество { get; set; }

        public int? Телефон { get; set; }

        public int? Возраст { get; set; }

        [Column(TypeName = "money")]
        public decimal? Средняя_ЗП { get; set; }

        public int? Номер_Паспорта { get; set; }

        public int? Серия_Паспорта { get; set; }

        [StringLength(30)]
        public string Кем_Выдан_Паспорт { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Дата_Выдачи { get; set; }

        public int? ИД_Адреса { get; set; }

        public int? ИД_Кредитной_Истории { get; set; }

        [Required]
        public virtual Адрес Адрес { get; set; }

        public virtual Кредитная_История Кредитная_История { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Кредитный_Договор> Кредитный_Договор { get; set; }
    }
}

namespace Course
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Кредитная_История
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Кредитная_История()
        {
            Заёмщик = new HashSet<Заёмщик>();
        }

        [Key]
        public int ИД_Кредитной_Истории { get; set; }

        public int? Количество_Счетов { get; set; }

        public int? Закрытые_Счета { get; set; }

        public int? Открытые_Счета { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Открыт_Последний { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Открыт_Первый { get; set; }

        public int? Количество_Заявок { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Последний_Запрос { get; set; }

        public int? Отказы_В_Кредите { get; set; }

        public int? Одобренные_Кредиты { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заёмщик> Заёмщик { get; set; }
    }
}

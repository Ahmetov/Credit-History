namespace Course
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Адрес
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Адрес()
        {
            Банк = new HashSet<Банк>();
            Заёмщик = new HashSet<Заёмщик>();
        }

        [Key]
        public int ИД_Адреса { get; set; }

        [StringLength(20)]
        public string Город { get; set; }

        [StringLength(20)]
        public string Улица { get; set; }

        public int? Номер_Улицы { get; set; }

        public int? Квартира { get; set; }

        public int? Индекс { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Банк> Банк { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заёмщик> Заёмщик { get; set; }

        public override string ToString()
        {
            return "Город: " + Город + "\n" +
                   "Улица: " + Улица + "\n" +
                   "Номер улицы: " + Номер_Улицы + "\n" +
                   "Квартира: " + Квартира + "\n" +
                   "Индекс: " + Индекс;
        }
    }
}

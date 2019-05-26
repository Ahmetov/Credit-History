namespace Course
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Банк
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Банк()
        {
            Кредитный_Договор = new HashSet<Кредитный_Договор>();
        }

        [Key]
        public int ИД_Банка { get; set; }

        [StringLength(30)]
        public string Название { get; set; }

        public int? ИД_Адреса { get; set; }

        [Required]
        public virtual Адрес Адрес { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Кредитный_Договор> Кредитный_Договор { get; set; }
    }
}

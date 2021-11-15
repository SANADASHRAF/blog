namespace plog_project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("admeen")]
    public partial class admeen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public admeen()
        {
            news = new HashSet<news>();
        }
        [Required(ErrorMessage ="*")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string username { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ,ErrorMessage ="invalied email")]
        public string email { get; set; }

        
       
        public string password { get; set; }

        //[NotMapped]
        //[Compare("password",ErrorMessage ="password not match")]
        //public string cconfirmpassword { get; set; }
        [Range(20,40,ErrorMessage ="age must be between 20 :40 years old")]

        public int? age { get; set; }

        public string address { get; set; }

        public string photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<news> news { get; set; }
    }
}

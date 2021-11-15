namespace plog_project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
      //  [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

       
        public string titel { get; set; }

       
        public string pref { get; set; }

        public string dec { get; set; }

        [StringLength(150)]
        public string photo { get; set; }

        public DateTime? datetime { get; set; }

        public int? cat_id { get; set; }

        public int? user_id { get; set; }

        public virtual admeen admeen { get; set; }

        public virtual catalog catalog { get; set; }
    }
}

namespace console
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Schedule")]
    public partial class Schedule
    {
        public int id { get; set; }

        public int? idClassRoom { get; set; }

        public int? idTeacher { get; set; }

        public int? idSubjects { get; set; }

        public int? idStudGroup { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }

        public virtual StudGroup StudGroup { get; set; }

        public virtual Subjects Subjects { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}

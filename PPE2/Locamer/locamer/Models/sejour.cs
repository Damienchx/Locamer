//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace locamer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class sejour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sejour()
        {
            this.locations = new HashSet<location>();
        }
    
        public int Id_sejour { get; set; }
        public System.DateTime debut_sejour { get; set; }
        public System.DateTime fin_sejour { get; set; }
        public int id_client { get; set; }
        public int code_mobilhome { get; set; }
        public int Id_loc { get; set; }
        public Nullable<int> id_typesejour { get; set; }
    
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<location> locations { get; set; }
        public virtual mobil_home mobil_home { get; set; }
        public virtual type_sejour type_sejour { get; set; }
    }
}

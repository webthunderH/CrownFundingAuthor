//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository.Global
{
    using System;
    using System.Collections.Generic;
    
    public partial class TypeDeContrat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeDeContrat()
        {
            this.Contrat_Utilisateur = new HashSet<Contrat_Utilisateur>();
        }
    
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Limite_Projet { get; set; }
        public Nullable<int> Prix { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrat_Utilisateur> Contrat_Utilisateur { get; set; }
    }
}

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
    
    public partial class Participations
    {
        public int Id { get; set; }
        public Nullable<int> IdUtilisateur { get; set; }
        public Nullable<int> IdMontant { get; set; }
        public System.DateTime DateParticipation { get; set; }
        public string Communication { get; set; }
    
        public virtual Montant Montant { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}

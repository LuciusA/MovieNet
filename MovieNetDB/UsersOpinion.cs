//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieNetDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsersOpinion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Comments { get; set; }
        public double Rating { get; set; }
    
        public virtual User User { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EBoutique.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class iBoutiqureDBEntities2 : DbContext
    {
        public iBoutiqureDBEntities2()
            : base("name=iBoutiqureDBEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<Marque> Marques { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int deleteCmd(Nullable<int> idCommande)
        {
            var idCommandeParameter = idCommande.HasValue ?
                new ObjectParameter("idCommande", idCommande) :
                new ObjectParameter("idCommande", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteCmd", idCommandeParameter);
        }
    
        public virtual ObjectResult<displaycmd_Result> displaycmd()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<displaycmd_Result>("displaycmd");
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<Commande> fundisplay()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Commande>("fundisplay");
        }
    
        public virtual ObjectResult<Commande> fundisplay(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Commande>("fundisplay", mergeOption);
        }
    
        public virtual ObjectResult<Commande> deletecmd1(Nullable<int> idCommande)
        {
            var idCommandeParameter = idCommande.HasValue ?
                new ObjectParameter("idCommande", idCommande) :
                new ObjectParameter("idCommande", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Commande>("deletecmd1", idCommandeParameter);
        }
    
        public virtual ObjectResult<Commande> deletecmd1(Nullable<int> idCommande, MergeOption mergeOption)
        {
            var idCommandeParameter = idCommande.HasValue ?
                new ObjectParameter("idCommande", idCommande) :
                new ObjectParameter("idCommande", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Commande>("deletecmd1", mergeOption, idCommandeParameter);
        }
    
        public virtual ObjectResult<Commande> supprimer(Nullable<int> idCommande)
        {
            var idCommandeParameter = idCommande.HasValue ?
                new ObjectParameter("idCommande", idCommande) :
                new ObjectParameter("idCommande", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Commande>("supprimer", idCommandeParameter);
        }
    
        public virtual ObjectResult<Commande> supprimer(Nullable<int> idCommande, MergeOption mergeOption)
        {
            var idCommandeParameter = idCommande.HasValue ?
                new ObjectParameter("idCommande", idCommande) :
                new ObjectParameter("idCommande", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Commande>("supprimer", mergeOption, idCommandeParameter);
        }
    
        public virtual ObjectResult<Commande> supp(Nullable<int> idCommande)
        {
            var idCommandeParameter = idCommande.HasValue ?
                new ObjectParameter("idCommande", idCommande) :
                new ObjectParameter("idCommande", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Commande>("supp", idCommandeParameter);
        }
    
        public virtual ObjectResult<Commande> supp(Nullable<int> idCommande, MergeOption mergeOption)
        {
            var idCommandeParameter = idCommande.HasValue ?
                new ObjectParameter("idCommande", idCommande) :
                new ObjectParameter("idCommande", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Commande>("supp", mergeOption, idCommandeParameter);
        }
    }
}
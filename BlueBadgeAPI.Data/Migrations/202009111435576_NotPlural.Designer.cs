﻿// <auto-generated />
namespace BlueBadgeAPI.Data.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
<<<<<<< HEAD:BlueBadgeAPI.Data/Migrations/202009111435576_NotPlural.Designer.cs
    public sealed partial class NotPlural : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(NotPlural));
        
        string IMigrationMetadata.Id
        {
            get { return "202009111435576_NotPlural"; }
=======
    public sealed partial class UserIdToString : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(UserIdToString));
        
        string IMigrationMetadata.Id
        {
            get { return "202009111332390_UserIdToString"; }
>>>>>>> b0cf4a535134e1b684734b2a81dd01e59503c1c1:BlueBadgeAPI.Data/Migrations/202009111332390_UserIdToString.Designer.cs
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}

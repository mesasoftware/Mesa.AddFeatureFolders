namespace Mesa.AddFeatureFolders.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using Controllers;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Project.Name.Features;
    using Project.Name.Features.Admin.ManageGolfers;
    using Project.Name.Features.Foo.Bar.Baz;

    public class FeatureControllerModelConventionTests
    {
        [Theory]
        [InlineData ( typeof ( ManageGolfersController ) , @"Features\Admin\ManageGolfers" )]
        [InlineData ( typeof ( ManageUsersController ) , @"Features\Foo\Bar\Baz" )]
        [InlineData ( typeof ( HomeController ) , @"Features" )]
        [InlineData ( typeof ( AboutController ) , @"" )]
        public void CanBuildPathFromControllerNamespace ( Type controller , string expected )
        {
            expected = expected.Replace ( '\\' , Path.DirectorySeparatorChar );

            var options = new FeatureFolderOptions ( );
            var service = new FeatureControllerModelConvention ( options );
            var controllerType = controller.GetTypeInfo ( );
            var attributes = new List<string> ( );
            var model = new ControllerModel ( controllerType , attributes );

            service.Apply ( model );

            Assert.Equal ( expected , model.Properties [ "feature" ] );
        }

        [Fact]
        public void CanUseCustomDerivationStrategy ( )
        {
            var options = new FeatureFolderOptions ( )
            {
                DeriveFeatureFolderName = c => @$"Features{Path.DirectorySeparatorChar}Foo"
            };
            var service = new FeatureControllerModelConvention ( options );
            var controllerType = typeof ( ManageUsersController ).GetTypeInfo ( );
            var attributes = new List<string> ( );
            var model = new ControllerModel ( controllerType , attributes );

            service.Apply ( model );

            Assert.Equal ( @$"Features{Path.DirectorySeparatorChar}Foo" , model.Properties [ "feature" ] );
        }
    }
}

#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace Project.Name.Features.Admin.ManageGolfers
{
    internal class ManageGolfersController
    {
    }
}

namespace Project.Name.Features.Foo.Bar.Baz
{
    internal class ManageUsersController
    {
    }
}

namespace Project.Name.Features
{
    internal class HomeController
    {
    }
}

namespace Controllers
{
    internal class AboutController
    {

    }
}

#pragma warning restore IDE0130 // Namespace does not match folder structure
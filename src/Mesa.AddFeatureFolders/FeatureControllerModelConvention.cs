namespace Mesa.AddFeatureFolders
{
    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;

    public class FeatureControllerModelConvention : IControllerModelConvention
    {
        private readonly string folderName;
        private readonly Func<ControllerModel , string> nameDerivationStrategy;

        public FeatureControllerModelConvention ( FeatureFolderOptions options )
        {
            ArgumentNullException.ThrowIfNull ( options );

            this.folderName = options.FeatureFolderName;
            this.nameDerivationStrategy = options.DeriveFeatureFolderName ?? this.DeriveFeatureFolderName;
        }

        public void Apply ( ControllerModel model )
        {
            ArgumentNullException.ThrowIfNull ( model );

            string featureName = this.nameDerivationStrategy ( model );
            model.Properties.Add ( "feature" , featureName );
        }

        private string DeriveFeatureFolderName ( ControllerModel model )
        {
            string? controllerNamespace = model.ControllerType.Namespace;

            ArgumentNullException.ThrowIfNull ( controllerNamespace );

            string result = controllerNamespace.Split ( '.' )
                .SkipWhile ( s => s != this.folderName )
                .Aggregate ( "" , Path.Combine );

            return result;
        }
    }
}

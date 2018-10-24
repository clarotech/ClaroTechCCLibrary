using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using ClaroTechCCLibrary.Utilities;
using Hl7.Fhir.Model;

namespace ClaroTechCCLibrary.ExtensionMethods
{
    public static class LocationMethods
    {
        public static Location CCInit(this Location thisLocation)
        {
            Collection<String> profiles = new Collection<String>();
            profiles.Add(Constants.ProfileCCOrganization);

            thisLocation.Meta = new Meta
            {
                Profile = profiles
            };

            return thisLocation;
        }


        public static Location CCAddOdsSiteCode(this Location thisLocation, string code)
        {
            Identifier id = new Identifier()
            {
                System = Constants.SystemNHSOdsSiteCode,
                Value = code
            };

            thisLocation.Identifier.Add(id);

            return thisLocation;
        }
    }
}

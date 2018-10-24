using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using ClaroTechCCLibrary.Utilities;
using Hl7.Fhir.Model;

namespace ClaroTechCCLibrary.ExtensionMethods
{
    public static class OrganiszationMethods
    {
        public static Organization CCInit(this Organization org)
        {
            Collection<String> profiles = new Collection<String>();
            profiles.Add(Constants.ProfileCCOrganization);

            org.Meta = new Meta
            {
                Profile = profiles
            };

            TypeInfo xx = org.GetType().GetTypeInfo();


            return org;
        }

        public static Organization CCSetPeriod(this Organization org, Period period)
        {
            Extension ext = new Extension(Constants.ProfileHl7OrganizationPeriod, period);
            org.Extension.Add(ext);

            return org;
        }

        public static Organization CCSetMainLocation(this Organization org, ResourceReference fhirRef)
        {
            Extension ext = new Extension(Constants.ExtensionCCMainLocation, fhirRef);
            org.Extension.Add(ext);

            return org;
        }

        public static Organization CCAddOdsOrganisationCode(this Organization org, string code)
        {
            Identifier id = new Identifier()
            {
                System = Constants.SystemNHSOdsOrganisationCode,
                Value = code
            };

            org.Identifier.Add(id);

            return org;
        }

        public static Organization CCAddOdsSiteCode(this Organization org, string code)
        {
            Identifier id = new Identifier()
            {
                System = Constants.SystemNHSOdsSiteCode,
                Value = code
            };

            org.Identifier.Add(id);

            return org;
        }
    }
}

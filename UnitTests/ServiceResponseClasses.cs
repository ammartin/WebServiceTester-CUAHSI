using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests {
    public class ServiceResponseClasses {
        public struct MappedVariable {
            public string variableName;
            public string variableCode;
            public string servCode;
            public string WSDL;
            public string conceptKeyword;
            public string conceptCode;
        }

        public struct SeriesRecord {
            public string ServCode;
            public string ServURL;
            public string location;
            public string VarCode;
            public string VarName;
            public string beginDate;
            public string endDate;
            public string authtoken;
            public int ValueCount;
            public string Sitename;
            public double latitude;
            public double longitude;
            public string datatype;
            public string valuetype;
            public string samplemedium;
            public string timeunits;
            public string conceptKeyword;
            public string genCategory;
            public string TimeSupport;
        }

        public struct ServiceInfo {
            public string servURL;
            public string Title, ServiceDescriptionURL;
            public string name, Email, phone;
            public string organization, orgwebsite, citation, aabstract;
            public int valuecount;
            public int variablecount, sitecount;
            public int ServiceID;
            public string NetworkName;
            public double minx, miny, maxx, maxy;
            public string serviceStatus;
        }

        public struct Site {
            public string SiteName;
            public string SiteCode;
            public double Latitude;
            public double Longitude;
            public string HUC;
            public int HUCnumeric;
            public string servCode;
            public string servURL;
        }


    }
}

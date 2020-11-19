using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace OCR.Facultad.Ingenieria.Reportes
{
    public static class ConfiguracionReportes
    {
        public static void GuardarConfiguracion(string cadenaconexion)
        {


            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                config.ConnectionStrings.ConnectionStrings["OCR.Facultad.Ingenieria.ManagerBases.Properties.Settings.ocrConnectionString"].ConnectionString = cadenaconexion;
                config.ConnectionStrings.ConnectionStrings["OCR.Facultad.Ingenieria.ManagerBases.Properties.Settings.ocrConnectionString"].ProviderName = "MySql.Data.MySqlClient";
                config.Save(ConfigurationSaveMode.Modified, true);
                config.Save(ConfigurationSaveMode.Full, true);
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            else
            {

                config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(
                                                              "OCR.Facultad.Ingenieria.ManagerBases.Properties.Settings.ocrConnectionString",
                                                              cadenaconexion, "MySql.Data.MySqlClient"
                                                                             ));
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");
            }

        }
    }
}

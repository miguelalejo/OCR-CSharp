using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace OCR.Facultad.Ingenieria.Batch
{
    public class ClassAppAplicacion
    {
        public static string GetPathLang()
        {
            return ConfigurationManager.AppSettings.Get("PathLang");
        }
        public static string GetLanguage()
        {
            return ConfigurationManager.AppSettings.Get("Language");
        }
        public static string GetEnablePerformance()
        {
            return ConfigurationManager.AppSettings.Get("EnablePerformance");
        }
        public static string GetEnableMODI()
        {
            return ConfigurationManager.AppSettings.Get("EnableMODI");
        }
        public static string PMemoriaCacheCategoryName()
        {
            return ConfigurationManager.AppSettings.Get("pMemoriaCacheCategoryName");
        }
        public static string PMemoriaCacheCounterName()
        {
            return ConfigurationManager.AppSettings.Get("pMemoriaCacheCounterName");
        }
        public static string PMemoriaDisponibleCategoryName()
        {
            return ConfigurationManager.AppSettings.Get("pMemoriaDisponibleCategoryName");
        }
        public static string PMemoriaDisponibleCounterName()
        {
            return ConfigurationManager.AppSettings.Get("pMemoriaDisponibleCounterName");
        }
        public static string PMemoriaTotalCategoryName()
        {
            return ConfigurationManager.AppSettings.Get("pMemoriaTotalCategoryName");
        }
        public static string PMemoriaTotalCounterName()
        {
            return ConfigurationManager.AppSettings.Get("pMemoriaTotalCounterName");
        }
        public static string PMemKernelPaginadoCategoryName()
        {
            return ConfigurationManager.AppSettings.Get("pMemKernelPaginadoCategoryName");
        }
        public static string PMemKernelPaginadoCounterName()
        {
            return ConfigurationManager.AppSettings.Get("pMemKernelPaginadoCounterName");
        }
        public static string PMemKernelNoPaginadoCategoryName()
        {
            return ConfigurationManager.AppSettings.Get("pMemKernelNoPaginadoCategoryName");
        }
        public static string PMemKernelNoPaginadoCounterName()
        {
            return ConfigurationManager.AppSettings.Get("pMemKernelNoPaginadoCounterName");
        }
        public static string PIdentificadoresCategoryName()
        {
            return ConfigurationManager.AppSettings.Get("pIdentificadoresCategoryName");
        }
        public static string PIdentificadoresCounterName()
        {
            return ConfigurationManager.AppSettings.Get("pIdentificadoresCounterName");
        }
        public static string PSubprocesosCategoryName()
        {
            return ConfigurationManager.AppSettings.Get("pSubprocesosCategoryName");
        }
        public static string PSubprocesosCounterName()
        {
            return ConfigurationManager.AppSettings.Get("pSubprocesosCounterName");
        }
        public static string PPorcentajeUsoCPUCategoryName()
        {
            return ConfigurationManager.AppSettings.Get("pPorcentajeUsoCPUCategoryName");
        }
        public static string PPorcentajeUsoCPUCounterName()
        {
            return ConfigurationManager.AppSettings.Get("PPorcentajeUsoCPUCounterName");
        }
        public static string PPorcentajeUsoCPUInstanceName()
        {
            return ConfigurationManager.AppSettings.Get("pPorcentajeUsoCPUInstanceName");
        }
        public static string PPromedioLecuraDiscoCategoryName()
        {
            return ConfigurationManager.AppSettings.Get("pPromedioLecuraDiscoCategoryName");
        }
        public static string PPromedioLecuraDiscoCounterName()
        {
            return ConfigurationManager.AppSettings.Get("pPromedioLecuraDiscoCounterName");
        }
        public static string PPromedioLecuraDiscoInstanceName()
        {
            return ConfigurationManager.AppSettings.Get("pPromedioLecuraDiscoInstanceName");
        }
        public static string PPromedioEscrituraDiscoCategoryName()
        {
            return ConfigurationManager.AppSettings.Get("pPromedioEscrituraDiscoCategoryName");
        }
        public static string PPromedioEscrituraDiscoCounterName()
        {
            return ConfigurationManager.AppSettings.Get("pPromedioEscrituraDiscoCounterName");
        }
        public static string PPromedioEscrituraDiscoInstanceName()
        {
            return ConfigurationManager.AppSettings.Get("pPromedioEscrituraDiscoInstanceName");
        } 

    }
}

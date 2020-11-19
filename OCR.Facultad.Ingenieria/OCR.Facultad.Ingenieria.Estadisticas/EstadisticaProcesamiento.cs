using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
namespace OCR.Facultad.Ingenieria.Estadisticas
{
    public class EstadisticaProcesamiento
    {
        [XmlElement("MemoriaTotal")]
        public long MemoriaTotal
        {
            get;
            set;
        }
        [XmlElement("MemoriaCache")]
        public long MemoriaCache
        {
            get;
            set;
        }
        [XmlElement("MemoriaDisponible")]
        public long MemoriaDisponible
        {
            get;
            set;
        }
        [XmlElement("MemoriaLibre")]
        public long MemoriaLibre
        {
            get;
            set;
        }
        [XmlElement("MemKernelPaginado")]
        public long MemKernelPaginado
        {
            get;
            set;
        }
        [XmlElement("MemKernelNoPaginado")]
        public long MemKernelNoPaginado
        {
            get;
            set;
        }
        [XmlElement("Identificadores")]
        public long Identificadores
        {
            get;
            set;
        }
        [XmlElement("Subprocesos")]
        public long Subprocesos
        {
            get;
            set;
        }
        [XmlElement("PorcentajeUsoCPU")]
        public long PorcentajeUsoCPU
        {
            get;
            set;
        }
        
        [XmlElement("PromedioLecuraDisco")]
        public long PromedioLecuraDisco
        {
            get;
            set;
        }
        [XmlElement("PromedioEscrituraDisco")]
        public long PromedioEscrituraDisco
        {
            get;
            set;
        }
        [XmlElement("FechaProsesamiento")]
        public DateTime FechaProsesamiento
        {
            get;
            set;
        }
        [XmlElement("HoraProcesamiento")]
        public TimeSpan HoraProcesamiento
        {
            get;
            set;
        }
        [XmlElement("EspacioEnDisco")]
        public long EspacioEnDisco
        {
            get;
            set;
        }
        [XmlElement("TamanioDisco")]
        public long TamanioDisco
        {
            get;
            set;
        }
        public EstadisticaProcesamiento(long umemoriatotal,long umemoriacache,long umemoriadisponible,long umemorialibre,long umemkernelpaginado,
               long umemkernelnopaginado, long uidentificadores, long usubprocesos, long uporcentajeusocpu, long upromediolecuradisco,
               long upromedioescrituradisco,DateTime ufechaprosesamiento,TimeSpan uhoraprocesamiento,long uespacioendisco,long utamaniodisco
              )
        {
            this.MemoriaTotal = umemoriatotal;
            this.MemoriaCache = umemoriacache;
            this.MemoriaDisponible = umemoriadisponible;
            this.MemoriaLibre = umemorialibre;
            this.MemKernelPaginado = umemkernelpaginado;
            this.MemKernelNoPaginado = umemkernelnopaginado;
            this.Identificadores = uidentificadores;
            this.Subprocesos = usubprocesos;
            this.PorcentajeUsoCPU = uporcentajeusocpu;
            this.PromedioLecuraDisco = upromediolecuradisco;
            this.PromedioEscrituraDisco = upromedioescrituradisco;
            this.FechaProsesamiento = ufechaprosesamiento;
            this.HoraProcesamiento = uhoraprocesamiento;
            this.EspacioEnDisco = uespacioendisco;
            this.TamanioDisco = utamaniodisco;
            

        }
        public EstadisticaProcesamiento(long umemoriatotal, long umemoriacache)
        {
            this.MemoriaTotal = umemoriatotal;
            this.MemoriaCache = umemoriacache;           
        }
        public EstadisticaProcesamiento()
        { }


    }
}
